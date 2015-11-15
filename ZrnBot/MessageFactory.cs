namespace ZrnBot
{
    class MessageFactory : IMessageFactory
    {
        public IMessage BuildMessage(string message)
        {
            return new Message(message, '%');
        }
    }
}
