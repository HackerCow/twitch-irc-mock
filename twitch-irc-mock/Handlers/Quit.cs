namespace twitch_irc_mock.Handlers
{
	internal class Quit
	{
		public static IrcResponse[] Handle(IrcSession session)
		{
			session.Open = false;
			return new IrcResponse[]{};
		}
	}
}