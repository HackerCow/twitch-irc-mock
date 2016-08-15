using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using twitch_irc_mock.Handlers;

namespace twitch_irc_mock
{
	class Program
	{
		private static int port = 3333;

		private static void Main(string[] args)
		{
			Console.WriteLine("Starting up...");
			TcpListener listener = new TcpListener(IPAddress.Any, port);

			try
			{
				listener.Start();
			}
			catch (SocketException)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Error: failed to start (is port {port} already in use?)");
				Console.ResetColor();
				return;
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("All done. ");
			Console.ResetColor();
			Console.WriteLine($"Serving on port {port}");
			Console.ResetColor();

			while (true)
			{
				Socket client = listener.AcceptSocket();
				HandleClient(client);
			}
		}

		/// <summary>
		/// Handles one IRC command from a TCP connection (already established).
		/// </summary>
		private static void HandleClient(Socket client)
		{
			byte[] buf = new byte[Config.ReceiveBufferSize];
			bool shouldClose = false;
			IrcSession session = new IrcSession();

			while (!shouldClose)
			{
				if (!client.Connected)
					return;
				
				buf.Initialize();
				
				try
				{
					client.Receive(buf);
				}
				catch (SocketException)
				{
					return;
				}

				string request = Encoding.UTF8.GetString(buf).Replace("\0", "");
				string[] lines = request.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
				
				foreach (string line in lines)
				{
					IrcResponse[] responses = Router.HandleCommand(line, session);
					
					if (!session.Open)
						shouldClose = true;

					foreach (IrcResponse response in responses)
					{
						client.Send(Encoding.UTF8.GetBytes(response.ToString()));
					}
				}
			}
			client.Close();
		}
	}
}
