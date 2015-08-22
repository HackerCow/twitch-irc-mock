using twitch_irc_mock.Responses;

namespace twitch_irc_mock.Handlers
{
	internal class Join
	{
		public static IrcResponse[] Handle(string[] args, IrcSession session)
		{
			if (args.Length != 1)
			{
				return new IrcResponse[] {};
			}

			if(!IrcChannel.Channels.ContainsKey(args[0]))
				IrcChannel.Channels.Add(args[0], new IrcChannel(args[0]));
			
			IrcChannel.Channels[args[0]].Users.Add(session);
			session.CurrentChannel = args[0];
			
			return new IrcResponse[]
			{
				new EchoResponse(session, "JOIN " + args[0]),
				new CustomResponse(session, string.Format(":{0}.{1} 353 {0} = {2} :{0}", session.Nick, Config.Hostname, args[0])),
 				new CustomResponse(session, string.Format(":{0}.{1} 366 {0} {2} :End of /NAMES list", session.Nick, Config.Hostname, args[0])),
			};
		}
	}
}