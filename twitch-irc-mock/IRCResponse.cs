using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitch_irc_mock
{
	internal class IrcResponse
	{
		public static readonly IrcResponse Empty = new IrcResponse(IrcResponseCode.Null, null, null);

		public string Message { get; private set; }
		public IrcResponseCode Code { get; private set; }
		public string User { get; private set; }

		public IrcResponse(IrcResponseCode code, string user, string message)
		{
			User = user;
			Code = code;
			Message = message;
		}

		private static string CodeToString(IrcResponseCode code)
		{
			if (code == IrcResponseCode.Notice)
				return "NOTICE";
			return ((int) code).ToString("D3");
		}

		public override string ToString()
		{
			return string.Format(":{0} {1} {2} :{3}\r\n", Config.Hostname, CodeToString(Code), User, Message);
		}
	}

}
