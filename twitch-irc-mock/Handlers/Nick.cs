using System;
using System.Collections.Generic;

namespace twitch_irc_mock.Handlers
{
	internal class Nick
	{
		public static IrcResponse[] Handle(string[] args, IrcSession session)
		{
			if(args.Length != 1)
			{
				session.Open = false;
				return new[] {new IrcResponse(IrcResponseCode.Notice, "*", "Invalid NICK")};
			}

			if (session.Pass == null)
			{
				session.Open = false;
				return new[] {new IrcResponse(IrcResponseCode.Notice, "*", "Error logging in")};
			}

			session.Nick = args[0];

			List<IrcResponse> responses = new List<IrcResponse>();
			foreach (Tuple<IrcResponseCode, string> line in Config.WelcomeText)
			{
				responses.Add(new IrcResponse(line.Item1, session.Nick, line.Item2));
			}

			return responses.ToArray();
		}
	}
}