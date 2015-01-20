using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Server { get; private set; }
        public int Port { get; private set; }
        private readonly List<Channel> channels;
        public string User { get; private set; }
        public char Control { get; private set; }
        public string Welcome { get; private set; }

        public IReadOnlyList<Channel> Channels
        {
            get { return channels.AsReadOnly(); }
        }

        public Bot(string botName, string password, string server, int port, string user, char control, string welcome, List<Channel> chanList)
        {
            Welcome = welcome;
            Control = control;
            User = user;
            Port = port;
            Server = server;
            Password = password;
            BotName = botName;
            channels = chanList;
        }

        /// <summary>
        /// Configures a new Bot object
        /// </summary>
        /// <returns></returns>
        public static Bot SetupBot()
        {
            var botName = InputUtils.GetName();
            var password = InputUtils.GetPassword();
            var server = InputUtils.GetServer();
            var port = InputUtils.GetPort();
            var channels = InputUtils.GetChannels();
            var user = InputUtils.GetUser();
            var control = InputUtils.GetControlChar();

            var bot = new Bot(botName, password, server, port, user, control, "", channels);
            return bot;
        }
    }
}
