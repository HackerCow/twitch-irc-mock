using twitch_irc_mock.Responses;

namespace twitch_irc_mock
{
	namespace Handlers
	{
		internal static class Join
		{
			public static IrcResponse[] Handle(string[] args, IrcSession session)
			{
				if (args.Length != 1)
				{
					return new IrcResponse[] {};
				}

			if (!IrcChannel.Channels.ContainsKey(args[0]))
			{
				IrcChannel.Channels.Add(args[0], new IrcChannel(args[0]));
			}

			IrcChannel.Channels[args[0]].Users.Add(session);
			session.CurrentChannel = args[0];
			
			return new IrcResponse[]
			{
				new EchoResponse(session, "JOIN " + args[0]),
				new CustomResponse(session, $":{session.Nick}.{Config.Hostname} 353 {session.Nick} = {args[0]} :{session.Nick}"),
 				new CustomResponse(session, $":{session.Nick}.{Config.Hostname} 366 {session.Nick} {args[0]} :End of /NAMES list"),
			};
		}
	}
}