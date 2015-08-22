using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitch_irc_mock
{
	class IrcChannel
	{
		public static readonly Dictionary<string, IrcChannel> Channels = new Dictionary<string, IrcChannel>();

		public IrcChannel(string name)
		{
			Name = name;
			Users = new List<IrcSession>();
		}

		public string Name { get; set; }
		public List<IrcSession> Users { get; set; }

		public string Names
		{
			get
			{
				string result = "";
				for (int i = 0; i < Users.Count; i++)
				{
					if (i != 0)
						result += " ";
					result += Users[i].Nick;
				}
				return result;
			}
		}
	}
}
