using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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

        private static Bot SetupBot()
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

        /// <summary>
        /// Serialises the bot to a file to be loaded later
        /// </summary>
        public void SaveBot()
        {
            var binFormatter = new BinaryFormatter();
            var outFile = new FileStream(AppData.ConfigFileName, FileMode.Create, FileAccess.Write);
            binFormatter.Serialize(outFile, this);
            outFile.Close();
        }

        /// <summary>
        /// Loads a bot from a config file if one exists, else calls the SetupBot() method
        /// </summary>
        /// <returns></returns>
        public static Bot LoadBot()
        {
            if (!File.Exists(AppData.ConfigFileName)) return SetupBot();
            var binFormatter = new BinaryFormatter();
            var inFile = new FileStream(AppData.ConfigFileName, FileMode.Open, FileAccess.Read);
            var bot = (Bot) binFormatter.Deserialize(inFile);
            inFile.Close();
            return bot;
        }

        public void DisplayConfig()
        {
            Console.WriteLine(BotName);
            Console.WriteLine(Password);
            Console.WriteLine(Server);
            Console.WriteLine(Port);
            Console.WriteLine(User);
            Console.WriteLine(Control);
        }
    }
}
