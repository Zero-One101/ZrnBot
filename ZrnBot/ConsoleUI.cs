using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZrnBot
{
    class ConsoleUI
    {
        /// <summary>
        /// Gets input from the user
        /// </summary>
        /// <param name="data"></param>
        /// <returns>string</returns>
        public static string GetInput(string data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}: ", data);
            Console.ForegroundColor = ConsoleColor.Red;
            return Console.ReadLine();
        }

        /// <summary>
        /// Displays an error message to the user
        /// </summary>
        /// <param name="error"></param>
        public static void DisplayErrorMessage(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}", error);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Tells the user to press a key to resume the program
        /// </summary>
        public static void DisplayKeyPrompt()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
