using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZrnBot.IO
{
    class MessageReceivedEventArgs : EventArgs
    {
        private readonly IrcMessage message;

        public IrcMessage IrcMessage
        {
            get { return message; }
        }

        public MessageReceivedEventArgs(IrcMessage message)
        {
            this.message = message;
        }
    }
}
