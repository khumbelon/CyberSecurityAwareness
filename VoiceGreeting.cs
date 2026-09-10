using System;//// imports system namespace for console input and output
using System.IO;
using System.Media;// imports system namespace for playing sound files

namespace CyberSecurityAwarenessBot// name of the project and namespace
{
    public class VoiceGreeting
    {
        public void Play()// This method plays a greeting sound when the chatbot starts
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string soundPath = Path.Combine(baseDirectory, "greeting.wav");

            if (File.Exists(soundPath))
            {
                soundPath= Path.Combine(baseDirectory,"greeting.wav");
            }
                if (File.Exists(soundPath))
            {
                using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundPath)) 
                {
                    player.PlaySync();
                }
            }
            else
            {
                Console.WriteLine("Greeting sound file not found.");
            }
        }
    }
}
