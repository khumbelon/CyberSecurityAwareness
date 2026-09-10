using System;//imports system namespace for console input and output

namespace CyberSecurityAwarenessBot// name of the project and namespace
{
    public class ResponseHandler // This class handles responses based on user input
    {
        public string GetResponse(string input, string name) // This method generates a response based on user input and name
        {
            name = string.IsNullOrWhiteSpace(name) ? "User" : name;
            if (string.IsNullOrWhiteSpace(input))
            {
                return $"Bot: Please ask a question, {name}.";
            }
            string cleanedInput = input.Trim().ToLower();

            // Case-insensitive checks using StringComparison for consistency
            if (cleanedInput.Contains("how are you", StringComparison.OrdinalIgnoreCase))
            {
                return $"I am great, {name}! Ready to keep you safe online.";
            }
            if (cleanedInput.Contains("purpose", StringComparison.OrdinalIgnoreCase))
            {
                return $"My purpose is to teach South Africans about cybersecurity, {name}.";
            }
            if (cleanedInput.Contains("what can i ask", StringComparison.OrdinalIgnoreCase) ||
                cleanedInput.Contains("what can i do", StringComparison.OrdinalIgnoreCase))
            {
                return "You can ask about: Password safety, Phishing, Safe browsing, or My purpose.";
            }

            if (cleanedInput.Contains("password safety", StringComparison.OrdinalIgnoreCase))
            {
                return "To keep your passwords safe, use a combination of letters, numbers, and symbols. Avoid using information like birthdays or names as a password.";
            }

            if (cleanedInput.Contains("phishing", StringComparison.OrdinalIgnoreCase))
            {
                return "Phishing is a cyber attack that uses disguised email as a weapon. The goal is to trick the email recipient into believing that the message is something they want or need — a request from their bank, for instance, or a note from someone in their company — and to click a link or download an attachment.";
            }
            if (cleanedInput.Contains("safe browsing", StringComparison.OrdinalIgnoreCase) ||
                cleanedInput.Contains("browsing", StringComparison.OrdinalIgnoreCase))
            {
                return "Safe browsing is the practice of using the internet in a way that protects your personal information and devices from online threats. This includes using secure websites, avoiding suspicious links, and keeping your software up to date.";
            }
        
            return $"Bot >I'm not sure how to respond to that, {name}. Can you ask something else?";
        }
    }
}
