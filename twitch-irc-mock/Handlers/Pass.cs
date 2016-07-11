using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitch_irc_mock
{
	namespace Handlers
	{
		internal static class Pass
		{
			public static IrcResponse[] Handle(string[] args, IrcSession session)
			{
				if (args.Length != 1)
				{
					session.Open = false;
					return new IrcResponse[] {};
				}

				session.Pass = args[0];
				return new IrcResponse[] {};
			}
		}
	}
}
