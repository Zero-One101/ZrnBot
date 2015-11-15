using ZrnBot.IO;

namespace ZrnBot.Test.IO
{
    class MockNetwork : INetwork
    {
        public event MessageReceivedHandler MessageReceived;

        public void FireMessageReceived(IIrcMessage message)
        {
            if (MessageReceived != null)
            {
                MessageReceived(this, new MessageReceivedEventArgs(message));
            }
        }
    }
}
