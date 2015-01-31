using System;
using System.Collections.Generic;
using System.Linq;

namespace ZrnBot
{
    /// <summary>
    /// An object containing a channel and a password for the channel
    /// </summary>
    [Serializable]
    class Channel
    {
        public string Chan { get; private set; }
        public string Password { get; private set; }

        public Channel(string chan, string password)
        {
            Password = password;
            Chan = chan;
        }

        /// <summary>
        /// Converts a string into a series of Channel objects
        /// </summary>
        /// <param name="channels"></param>
        /// <returns>A List of Channel objects</returns>
        public static List<Channel> ToChannelList(string channels)
        {
            var chanList = new List<Channel>();
            var chansplit = channels.Split(',');

            foreach (var split in chansplit.Select(channel => channel.Split(' ')))
            {
                if (split.Length == 2)
                {
                    var newChan = new Channel(split[0], split[1]);
                    chanList.Add(newChan);
                }
                else
                {
                    var newChan = new Channel(split[0], "");
                    chanList.Add(newChan);
                }
            }

            return chanList;
        }
    }
}
