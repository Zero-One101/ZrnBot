using System;

namespace ZrnBot.IO
{
    class MessageReceivedEventArgs : EventArgs
    {
        public IIrcMessage IrcMessage { get; }

        public MessageReceivedEventArgs(IIrcMessage message)
        {
            this.IrcMessage = message;
        }
    }
}
