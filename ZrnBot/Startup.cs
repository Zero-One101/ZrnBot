using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using ZrnBot.IO;

namespace ZrnBot
{
    class Startup
    {
        public Startup()
        {
            var botSerialiser = new BotSerialiser();
            Bot bot;
            try
            {
                bot = botSerialiser.LoadBot();
                Console.WriteLine("Bot loaded successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Couldn't find existing config. Creating new one...");
                bot = GetBotData(botSerialiser);
            }
            catch (SerializationException e)
            {
                File.Delete(AppData.ConfigFileName);
                Console.WriteLine("Couldn't load existing config: " + e.Message);
                Console.WriteLine("Creating new one...");
                bot = GetBotData(botSerialiser);
            }
        }

        private Bot GetBotData(BotSerialiser botSerialiser)
        {
            Bot bot;
            var botName = GetName();
            var password = GetPassword();
            var ircUri = GetIrcUri();
            var channels = GetChannels();
            var user = GetUser();
            var control = GetControlChar();

            bot = new Bot(botName, password, ircUri, user, control, "", channels);

            if (botSerialiser.SaveBot(bot))
            {
                Console.WriteLine("Bot saved successfully.");
            }
            else
            {
                ConsoleUI.DisplayErrorMessage("Unable to save bot config!");
            }

            return bot;
        }

        private IrcUri GetIrcUri()
        {
            while (true)
            {
                try
                {
                    var ircUri = new IrcUri(GetServer(), GetPort());
                    return ircUri;
                }
                catch (UriFormatException e)
                {
                    ConsoleUI.DisplayErrorMessage(string.Format("Invalid IRC URI: {0}", e.Message));
                }
            }
        }

        private string GetName()
        {
            while (true)
            {
                var nick = ConsoleUI.GetInput("Bot nickname");
                if (IsValidNick(nick))
                {
                    return nick;
                }

                ConsoleUI.DisplayErrorMessage("Invalid nick!");
                ConsoleUI.DisplayErrorMessage(@"Nick can only contain characters a-z A-Z 0-9 _ - \ [ ] { } ^ ` |");
                ConsoleUI.DisplayErrorMessage("Characters 0-9 and '-' may not be in the first position.");
                ConsoleUI.DisplayKeyPrompt();
            }
        }

        private string GetUser()
        {
            while (true)
            {
                var nick = ConsoleUI.GetInput("User nickname");
                if (IsValidNick(nick))
                {
                    return nick;
                }

                ConsoleUI.DisplayErrorMessage("Invalid nick!");
                ConsoleUI.DisplayErrorMessage(@"Nick can only contain characters a-z A-Z 0-9 _ - \ [ ] { } ^ ` |");
                ConsoleUI.DisplayErrorMessage("Characters 0-9 and '-' may not be in the first position.");
                ConsoleUI.DisplayKeyPrompt();
            }

        }

        private static bool IsValidNick(string nick)
        {
            var r = new Regex(AppData.ValidCharacters);
            return (!r.IsMatch(nick) && !Char.IsDigit(nick, 0));
        }

        private string GetPassword()
        {
            while (true)
            {
                var password = ConsoleUI.GetInput("Nickserv Password");
                if (IsValidPassword(password))
                {
                    return password;
                }

                ConsoleUI.DisplayErrorMessage("Invalid password!");
                ConsoleUI.DisplayErrorMessage("A password may not contain spaces.");
                ConsoleUI.DisplayKeyPrompt();
            }
        }

        private static bool IsValidPassword(string pass)
        {
            return (!pass.Contains(' '));
        }

        private string GetServer()
        {
            var server = ConsoleUI.GetInput("Server (e.g. irc.esper.net)");
            return server;
        }

        private int GetPort()
        {
            while (true)
            {
                var portString = ConsoleUI.GetInput("Port (Usually 6667)");
                if (IsValidPort(portString))
                {
                    return Convert.ToInt32(portString);
                }

                ConsoleUI.DisplayErrorMessage("Invalid port!");
                ConsoleUI.DisplayErrorMessage("Port must be an integer number. Range: 0 - 65535");
                ConsoleUI.DisplayKeyPrompt();
            }
        }

        private static bool IsValidPort(string portString)
        {
            int port;
            if (Int32.TryParse(portString, out port))
            {
                if (port >= 0 && port <= 65535)
                {
                    return true;
                }
            }
            return false;
        }

        private List<Channel> GetChannels()
        {
            while (true)
            {
                var channels = ConsoleUI.GetInput("Channels (Format: #channel1 password1,&channel2 password2,...)");
                if (IsValidChannelList(channels))
                {
                    return Channel.ToChannelList(channels);
                }

                ConsoleUI.DisplayErrorMessage("Invalid channel detected!");
                ConsoleUI.DisplayErrorMessage("Make sure the channel name starts with a '#' or a '&'");
            }
        }

        private static bool IsValidChannelList(string chanString)
        {
            var channels = chanString.Split(',');
            return !channels.Any(channel => channel[0] != '#' && channel[0] != '&');
        }

        private static char GetControlChar()
        {
            while (true)
            {
                var controlString = ConsoleUI.GetInput("Control key (single character)");
                if (IsValidControl(controlString))
                {
                    var control = Convert.ToChar(controlString);
                    return control;
                }

                ConsoleUI.DisplayErrorMessage("Key can only be a single character!");
            }
        }

        private static bool IsValidControl(string control)
        {
            return control.Length == 1;
        }
    }
}