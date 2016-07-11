using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using twitch_irc_mock.Responses;

namespace twitch_irc_mock
{
	namespace Handlers
	{
		static class Router
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
					case "JOIN":
						return Join.Handle(args, session);
					case "QUIT":
						return Quit.Handle(session);
					default:
						return new IrcResponse[] {new UnknownCommandResponse(session, cmd)};
				}
			}
		}
	}
}
