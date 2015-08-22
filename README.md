# twitch-irc-mock
A mock of the twitch.tv IRC servers. Might be useful to bot developers for testing.

## Progress ##

### Done: ###
* Login (static)
* Join channels (static)

### TODO: ###
* Part (leave channel)
* Dynamic stuff (load channels from JSON,...)
* User simulation

## Disclaimer ##

This server is rewritten from scratch. Behaviour was reverse engineered using trial and error (issue a command on the real servers and try to mimick behaviour).

I have never seen nor have I contributed to the source code of any Twitch IRC server applications.

This program is not supposed to be an alternative (or competition) to the Twitch servers, but rather a tool for chatbot developers to assist them in testing their software.