using System;
using System.Collections.Generic;
using twitch_irc_mock.Responses;

namespace twitch_irc_mock
{
	namespace Handlers
	{
		internal static class Nick
		{
			public static IrcResponse[] Handle(string[] args, IrcSession session)
			{
				if(args.Length != 1)
				{
					session.Open = false;
					return new IrcResponse[] {new NoticeResponse(session, "Invalid NICK")};
				}

				if (session.Pass == null)
				{
					session.Open = false;
					return new IrcResponse[] {new NoticeResponse(session, "Error logging in")};
				}

				session.Nick = args[0];

				List<IrcResponse> responses = new List<IrcResponse>();
				foreach (Tuple<IrcResponseCode, string> line in Config.WelcomeText)
				{
					responses.Add(new IrcResponse(line.Item1, session, line.Item2));
				}

				return responses.ToArray();
			}
		}
	}
}