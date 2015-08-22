using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitch_irc_mock
{
	internal class IrcSession
	{
		public static List<IrcSession> Sessions = new List<IrcSession>();

		public string Pass;
		public string Nick;
		public bool Open;

		public bool IsLoggedIn()
		{
			return Pass != null && Nick != null;
		}

		public IrcSession()
		{
			Pass = null;
			Nick = null;
			Open = true;
		}
	}
}
