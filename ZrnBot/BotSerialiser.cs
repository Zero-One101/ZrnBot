using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
            var binFormatter = new BinaryFormatter();
            var bot = (Bot) binFormatter.Deserialize(inFile);
            inFile.Close();
            return bot;
        }

        public bool SaveBot(Bot bot)
        {
            try
            {
                var outFile = new FileStream(AppData.ConfigFileName, FileMode.Create, FileAccess.Write);
                var binFormatter = new BinaryFormatter();
                binFormatter.Serialize(outFile, bot);
                outFile.Close();
                return true;
            }
            catch (Exception)
            {
                // TODO: Do this properly, you lazy bastard
                return false;
            }
        }
    }
}
