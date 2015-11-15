using System;
using System.Collections.Generic;
using ZrnBot.IO;

namespace ZrnBot
{
    /// <summary>
    /// A bot object containing all of the information required to connect to a server and join channels
    /// </summary>
    [Serializable]
    class Bot
    {
        public string BotName { get; private set; }
        public string Password { get; private set; }
        public IrcUri IrcServerUri { get; private set; }
        private readonly List<Channel> channels;
        public string User { get; private set; }
        public char Control { get; private set; }
        public string Welcome { get; private set; }

        public IReadOnlyList<Channel> Channels
        {
            get { return channels.AsReadOnly(); }
        }

        public Bot(string botName, string password, IrcUri ircServerUri, string user, char control, string welcome, List<Channel> chanList)
        {
            Welcome = welcome;
            Control = control;
            User = user;
            Password = password;
            BotName = botName;
            channels = chanList;
            IrcServerUri = ircServerUri;
        }

        public void DisplayConfig()
        {
            Console.WriteLine(BotName);
            Console.WriteLine(Password);
            Console.WriteLine(IrcServerUri.NetworkUri.Host);
            Console.WriteLine(IrcServerUri.NetworkUri.Port);
            Console.WriteLine(User);
            Console.WriteLine(Control);
        }
    }
}
