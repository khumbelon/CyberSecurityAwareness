using System;
using System.Collections.Generic;

namespace CybersecurityChatbotGUI
{
    public class KeywordResponder
    {
        private Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>();
        private System.Random random = new System.Random();
        private string lastTopic = ""; // Tracks current conversation flow

        public KeywordResponder()
        {
            // Password Safety
            responses["password"] = new List<string>
            {
                "Use strong, unique passwords with 12+ characters including uppercase, lowercase, numbers and symbols.",
                "Avoid personal details in passwords like birthdays or pet names. Use a password manager instead.",
                "Change passwords regularly and never reuse them across different websites.",
                "Enable two-factor authentication for extra security on important accounts.",
                "A good password should be at least 16 characters long for maximum protection."
            };

            // Phishing
            responses["phishing"] = new List<string>
            {
                "Phishing is a social engineering attack that tricks you into revealing credentials or running malware.",
                "Phishing emails often have spelling errors and generic greetings like 'Dear Customer' instead of your name.",
                "Hover over email links to see the real URL before clicking. Never click links from unexpected sources.",
                "Never enter your password from a link in an email. Go directly to the official website instead.",
                "Enable two-factor authentication to protect against phishing attacks even if credentials are compromised.",
                "If something seems suspicious, contact the organization directly using a phone number from their official website."
            };

            // Scams
            responses["scam"] = new List<string>
            {
                "Scams use urgent messages asking for personal information or money. Always verify the sender first.",
                "If it sounds too good to be true, it's likely a scam. Be skeptical of unsolicited offers.",
                "Always check official sources before clicking links or providing information.",
                "Common scams include fake prize notifications, inheritance claims, and urgent payment requests.",
                "Never share your passwords, PIN codes, or personal information with anyone, even if they claim to be from your bank.",
                "Report suspected scams to the organization and local authorities immediately."
            };

            // Privacy
            responses["privacy"] = new List<string>
            {
                "Review app permissions regularly and limit location sharing to necessary apps only.",
                "Use privacy-focused browsers and check privacy settings on social media accounts monthly.",
                "Avoid oversharing personal information online. Scammers use it for identity theft and fraud.",
                "Clear cookies and browser history regularly to protect your browsing habits.",
                "Use a VPN when connecting to public Wi-Fi to encrypt your internet traffic.",
                "Read privacy policies before installing apps or creating accounts online."
            };

            // Malware
            responses["malware"] = new List<string>
            {
                "Keep your antivirus software updated and run regular scans to detect malware.",
                "Avoid downloading files from untrusted sources or clicking on suspicious links.",
                "Malware can steal your data, lock your files, or use your computer to attack others.",
                "Keep your operating system and all software up to date with the latest security patches.",
                "Be cautious of email attachments, even from known contacts. Malware can spread this way.",
                "Use strong passwords and two-factor authentication to prevent unauthorized access if malware infects your device."
            };

            // Safe Browsing
            responses["browsing"] = new List<string>
            {
                "Look for the padlock icon in your browser address bar to confirm a secure HTTPS connection.",
                "Avoid clicking on suspicious links or pop-ups, especially on unfamiliar websites.",
                "Keep your browser updated with the latest security patches and extensions.",
                "Use strong, unique passwords for each online account to prevent credential stuffing attacks.",
                "Be wary of unexpected downloads or requests to install plugins or extensions.",
                "Clear your browser cache and cookies regularly to protect your privacy."
            };

            // Two-Factor Authentication
            responses["two-factor"] = new List<string>
            {
                "Two-factor authentication (2FA) adds an extra security layer by requiring a second verification method.",
                "2FA methods include SMS codes, authenticator apps, biometrics (fingerprint/face), or security keys.",
                "Even if your password is compromised, 2FA prevents unauthorized access to your account.",
                "Authenticator apps are more secure than SMS because they can't be intercepted via SIM swap attacks.",
                "Enable 2FA on all important accounts: email, banking, social media, and work accounts.",
                "Save backup codes in a secure location in case you lose access to your 2FA device."
            };
        }

        /// <summary>
        /// Gets the current topic being discussed (for conversation flow).
        /// </summary>
        public string GetCurrentTopic()
        {
            return lastTopic;
        }

        public string GetResponse(string input, MemoryStore memory)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please ask a question about cybersecurity topics like passwords, phishing, scams, privacy, malware, safe browsing, or two-factor authentication.";

            string lower = input.ToLower();                         

            // FOLLOW-UP PHRASES: "tell me more", "give me another tip", "explain more", "what else", "continue", "I do not understand"
            if ((lower.Contains("more") || lower.Contains("another") || lower.Contains("explain") ||
                 lower.Contains("what else") || lower.Contains("continue") || lower.Contains("don't understand") ||
                 lower.Contains("i do not understand")) && !string.IsNullOrEmpty(lastTopic))
            {
                if (responses.ContainsKey(lastTopic) && responses[lastTopic].Count > 0)
                {
                    return responses[lastTopic][random.Next(responses[lastTopic].Count)];
                }
            }

            // INTEREST REGISTRATION: "I'm interested in [topic]"
            if (lower.Contains("interested in") || lower.Contains("interested in learning"))
            {
                foreach (string key in responses.Keys)
                {
                    if (lower.Contains(key))
                    {
                        memory.SaveInterest("user", key);
                        memory.CurrentTopic = key;
                        lastTopic = key;
                        return $"Great! I'll remember you're interested in {key}. {responses[key][random.Next(responses[key].Count)]}";
                    }
                }
            }

            // INTEREST RECALL: "What am I interested in?", "Remember", "What is my interest?"
            if (lower.Contains("what am i interested") || lower.Contains("remember") || lower.Contains("what is my interest"))
            {
                string interest = memory.GetInterest("user");
                if (!string.IsNullOrEmpty(interest))
                {
                    lastTopic = interest;
                    return $"You told me you're interested in {interest}. Since you're interested in {interest}, here's a tip: {responses[interest][random.Next(responses[interest].Count)]}";
                }
                return "You haven't told me your interest yet. Try saying 'I'm interested in [topic]'.";
            }

            // KEYWORD DETECTION: Check all topics
            foreach (string keyword in responses.Keys)
            {
                if (lower.Contains(keyword))
                {
                    lastTopic = keyword;
                    memory.CurrentTopic = keyword;
                    return responses[keyword][random.Next(responses[keyword].Count)];
                }
            }

            // Handle "two-factor" or "2fa" as special case
            if (lower.Contains("2fa") || lower.Contains("two factor") || lower.Contains("2-factor"))
            {
                lastTopic = "two-factor";
                memory.CurrentTopic = "two-factor";
                return responses["two-factor"][random.Next(responses["two-factor"].Count)];
            }

            // Default response for unmatched input
            return "";
        }
    }
}