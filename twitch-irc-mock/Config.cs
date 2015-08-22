using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitch_irc_mock
{
	static class Config
	{
		public const int ReceiveBufferSize = 512;
		public const string Hostname = "tmi.twitch.tv";
		public static readonly Tuple<IrcResponseCode, string>[] WelcomeText = 
		{
			new Tuple<IrcResponseCode, string>(IrcResponseCode.Welcome,		"Welcome, GLHF!"),
			new Tuple<IrcResponseCode, string>(IrcResponseCode.YourHost,	"Your host is " + Hostname),
			new Tuple<IrcResponseCode, string>(IrcResponseCode.Created,		"This Server is rather new"),
			new Tuple<IrcResponseCode, string>(IrcResponseCode.MyInfo,		"-"),
			new Tuple<IrcResponseCode, string>(IrcResponseCode.MotdStart,	"-"),
			new Tuple<IrcResponseCode, string>(IrcResponseCode.Motd,		"You are in a maze of twisty passages, all alike."), 
			new Tuple<IrcResponseCode, string>(IrcResponseCode.EndOfMotd,	">") 

		};
	}
}
