using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZrnBot.IO
{
    class Connection : IConnection
    {
        public Uri ServerUri { get; }

        private NetworkStream nStream;

        public Connection(Uri serverUri, CancellationToken cancelToken)
        {
            ServerUri = serverUri;
            var socket = new Socket(AddressFamily.Unknown, SocketType.Stream, ProtocolType.IP);
            socket.Connect(ServerUri.Host, ServerUri.Port);
            nStream = new NetworkStream(socket);
        }

        public Task<bool> SendStringAsying(IIrcMessage ircMessage)
        {
            throw new NotImplementedException();
        }
    }
}
