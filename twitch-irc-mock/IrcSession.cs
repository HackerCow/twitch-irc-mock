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

		public string Pass = null;
		public string Nick = null;
		public bool Open = true;
		public string CurrentChannel = null;
		public List<string> Capabilities = new List<string>();

		public bool IsLoggedIn()
		{
			return Pass != null && Nick != null;
		}
	}
}
