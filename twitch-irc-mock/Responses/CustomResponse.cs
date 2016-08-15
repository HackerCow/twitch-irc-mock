using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitch_irc_mock
{
	namespace Responses
	{
		class CustomResponse : IrcResponse
		{
			public CustomResponse(IrcSession user, string message) : base(IrcResponseCode.Null, user, message)
			{
			}

			public override string ToString() => Message + "\r\n";
		}
	}
}
