using ZrnBot.IO;

namespace ZrnBot
{
    internal delegate void MessageReceivedHandler(object sender, MessageReceivedEventArgs e);

    static class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
        }
    }
}
