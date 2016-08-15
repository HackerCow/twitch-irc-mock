using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitch_irc_mock
{
	namespace Responses
	{
		class NoticeResponse : IrcResponse
		{
			public NoticeResponse(IrcSession user, string message) : base(IrcResponseCode.Null, user, message)
			{
			}

			public override string ToString() => $":{Config.Hostname} NOTICE * :{Message}\r\n";
		}
	}
}
