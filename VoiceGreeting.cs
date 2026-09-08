using System;
using System.IO;
using System.Media;

namespace CyberSecurityAwarenessBot
{
    public class VoiceGreeting
    {
        public void Play()
        {
            try
            {
                string soundPath = Path.Combine(AppContext.BaseDirectory, "greeting.wav");
                if (!File.Exists(soundPath))
                {
                    Console.WriteLine($"Greeting sound not found: {soundPath}");
                    return;
                }

              using SoundPlayer player = new SoundPlayer(soundPath);
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
    }
}