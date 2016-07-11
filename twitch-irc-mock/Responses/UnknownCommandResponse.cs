using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitch_irc_mock
{
	namespace Responses
	{
		class UnknownCommandResponse : IrcResponse
		{
			public string Command;
			public UnknownCommandResponse(IrcSession user, string cmd) : base(IrcResponseCode.ErrorUnknownCommand, user, "")
			{
				Command = cmd;
			}

			public override string ToString()
			{
				return string.Format(":{0} {1} {2} {3} :Unknown Command", Config.Hostname, IrcResponseCode.ErrorUnknownCommand,
					User.IsLoggedIn() ? User.Nick : "you", Command);
			}
		}
	}
}
