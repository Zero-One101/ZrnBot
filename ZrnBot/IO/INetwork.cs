namespace ZrnBot.IO
{
    /// <summary>
    /// Provides a method of notifying on incoming data, and a method of sending data
    /// </summary>
    interface INetwork
    {
        event MessageReceivedHandler MessageReceived;

        void FireMessageReceived(IIrcMessage message);
    }
}