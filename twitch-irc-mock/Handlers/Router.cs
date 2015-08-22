using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitch_irc_mock.Handlers
{
	class Router
	{
		public static IrcResponse[] HandleCommand(string req, IrcSession session)
		{
			string[] parts = req.Split(' ');
			string cmd = parts[0].ToUpper();
			string[] args = parts.Skip(1).ToArray();
			switch (cmd)
			{
				case "PASS":
					return Pass.Handle(args, session);
				case "NICK":
					return Nick.Handle(args, session);
				case "QUIT":
					return Quit.Handle(session);
				default:
					// TODO: ugly hack: appends cmd to username
					return new[] {new IrcResponse(
						IrcResponseCode.ErrorUnknownCommand,
						(session.IsLoggedIn() ? session.Nick : "you ") + cmd,
						string.Format("Unknown command", cmd))};
			}
		}
	}
}
