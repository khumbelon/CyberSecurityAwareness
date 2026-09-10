using System;// imports system namespace for console input and output

namespace CyberSecurityAwarenessBot// name of the project and namespace
{
    public class AsciiArt // This class is responsible for displaying ASCII art and the chatbot's logo
    {
        public void Display()
        {
            DisplayLogo();// display the Logo

        }

        public void DisplayLogo()// This method displays the ASCII art logo of the chatbot
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

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine(@"  ______   ______  _____ ____  ____  _____ ____ 
 / ___\ \ / / __ )| ____|  _ \/ ___|| ____/ ___|
| |    \ V /|  _ \|  _| | |_) \___ \|  _|| |    
| |___  | | | |_) | |___|  _ < ___) | |__| |___ 
 \____| |_| |____/|_____|_| \_\____/|_____\____| ");
            Console.ResetColor();

            Console.WriteLine();
        }
    }
}
