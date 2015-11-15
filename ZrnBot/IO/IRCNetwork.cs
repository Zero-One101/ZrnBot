using System;
using System.Net.Sockets;
using System.Threading;

namespace ZrnBot.IO
{
    class IrcNetwork : INetwork
    {
        public event MessageReceivedHandler MessageReceived;
        private IConnection connection;

        public IrcNetwork(Uri networkUri, CancellationToken cancelToken)
        {
            connection = new Connection(networkUri, cancelToken);
        }

        public void FireMessageReceived(IIrcMessage message)
        {
            if (MessageReceived != null)
            {
                MessageReceived(this, new MessageReceivedEventArgs(message));
            }
        }
    }
}
