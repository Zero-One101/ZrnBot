using System;

namespace ZrnBot.IO
{
    class IrcUri
    {
        public Uri NetworkUri { get; }

        public IrcUri(string server, int port)
        {
            try
            {
                if (!server.StartsWith("irc://"))
                {
                    server = "irc://" + server;
                }

                NetworkUri = new Uri(server + ":" + port);
            }
            catch (UriFormatException e)
            {
                throw;
            }
        }
    }
}
