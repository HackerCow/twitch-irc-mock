namespace twitch_irc_mock
{
	namespace Handlers
	{
		internal static class Quit
		{
			public static IrcResponse[] Handle(IrcSession session)
			{
				session.Open = false;
				return new IrcResponse[]{};
			}
		}
	}
}