namespace ZrnBot
{
    public class Message
    {
        public string Nick { get; private set; }
        public string Hostmask { get; private set; }
        public MessageType Type { get; private set; }
        public string Channel { get; private set; }
        public string Input { get; private set; }
        public string RawString { get; private set; }
        public bool isCommand { get; private set; }

        public enum MessageType
        {
            PRIVMSG,
            JOIN,
            PART,
            QUIT,
            KICK,
            PING
        };

        public Message(string rawString, char controlChar)
        {
            RawString = rawString;
        }

        private void SetProperties(char controlChar)
        {
            var parts = RawString.Split(' ');
        }
    }
}
