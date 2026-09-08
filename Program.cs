using System;

namespace CyberSecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            VoiceGreeting voice = new VoiceGreeting();
            voice.Play();

            AsciiArt art = new AsciiArt();
            art.Display();

            Chatbot bot = new Chatbot();
            bot.Start();

        }
    }
}
