using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZrnBot
{
    static class InputUtils
    {
        /// <summary>
        /// Asks the User to input a name and then checks for illegal characters
        /// </summary>
        /// <returns>A string containing the bot name</returns>
        public static string GetName()
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

        public static string GetUser()
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

        /// <summary>
        /// Asks the User to input a password
        /// </summary>
        /// <returns>A string containing the bot password</returns>
        public static string GetPassword()
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

        /// <summary>
        /// Asks the User to input a server
        /// </summary>
        /// <returns>A string containing the server</returns>
        public static string GetServer()
        {
            var server = ConsoleUI.GetInput("Server (e.g. irc.esper.net)");
            return server;
        }

        /// <summary>
        /// Asks the User to input a port
        /// </summary>
        /// <returns>An int containing the port</returns>
        public static int GetPort()
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

        /// <summary>
        /// Asks the User to input a list of comma separated channels, with or without passwords
        /// </summary>
        /// <returns>A list of Channel objects</returns>
        public static List<Channel> GetChannels()
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

        public static char GetControlChar()
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