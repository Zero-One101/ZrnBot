using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace ZrnBot
{
    class BotSerialiser
    {
        public Bot LoadBot()
        {
            if (!File.Exists(AppData.ConfigFileName))
            {
                var notFoundException = new FileNotFoundException();
                throw notFoundException;
            }

            var inFile = new FileStream(AppData.ConfigFileName, FileMode.Open, FileAccess.Read);

            try
            {
                var binFormatter = new BinaryFormatter();
                var bot = (Bot) binFormatter.Deserialize(inFile);
                inFile.Close();
                return bot;
            }
            catch (SerializationException)
            {
                inFile.Close();
                throw;
            }
        }

        public bool SaveBot(Bot bot)
        {
            var outFile = new FileStream(AppData.ConfigFileName, FileMode.Create, FileAccess.Write);
            try
            {
                var binFormatter = new BinaryFormatter();
                binFormatter.Serialize(outFile, bot);
                outFile.Close();
                return true;
            }
            catch (Exception)
            {
                // TODO: Do this properly, you lazy bastard
                outFile.Close();
                return false;
            }
        }
    }
}
