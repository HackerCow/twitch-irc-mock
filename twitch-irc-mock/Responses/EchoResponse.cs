﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitch_irc_mock
{
	namespace Responses
	{
		class EchoResponse : IrcResponse
		{
			public string Command;

			public EchoResponse(IrcSession user, string command) : base(IrcResponseCode.Null, user, "")
			{
				Command = command;
			}

			public override string ToString() => $":{User}!{User}@{User}.{Config.Hostname} {Command}\r\n";
		}
	}
}
