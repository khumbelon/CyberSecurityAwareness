using System;

namespace CyberSecurityAwarenessBot
{
    public class AsciiArt
    {
        public void Display()
        {
            DisplayLogo();
        }

        public void DisplayLogo()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================================");
            Console.WriteLine("     CYBERSECURITY AWARENESS BOT");
            Console.WriteLine("======================================");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Cybersecurity Awareness Chatbot!");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine(@"__   __                               
__  _  __ ____ |  | |  |   ____   ____   _____   ____  
\ \/ \/ // __ \|  | |  | _/ ___\ / __ \ /     \_/ __ \ 
 \     /\  ___/_  |__  |__  \___(  \_\ )  | |  \  ___/_
  \/\_/  \___  /____/____/\___  /\____/|__|_|  /\___  /
             \/               \/             \/     \/ ");

            Console.Write("You > ");
        }
    }
}