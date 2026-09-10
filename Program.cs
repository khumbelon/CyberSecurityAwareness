using System;//imports system namespace for console input and output

namespace CyberSecurityAwarenessBot// name of the project and namespace
{
    class Program //declares the program that starts the chatbot application
    {
        static void Main(string[] args) // The main entry point of the application
        {
            VoiceGreeting voice = new VoiceGreeting();//creates an instance of the VoiceGreeting class
            voice.Play();

            AsciiArt art = new AsciiArt();//creates an instance of the AsciiArt class
            art.Display();

            Chatbot bot = new Chatbot();//creates an instance of the Chatbot class
            bot.Start();

        }
    }
}

