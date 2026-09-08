using System;

namespace CyberSecurityAwarenessBot
{
    public class ResponseHandler // This class handles responses based on user input
    {
        public string GetResponse(string input, string name)
        {
            name ??= "User.Name";
            if (string.IsNullOrWhiteSpace(input))
                return $"Please ask a question, {name}.";

            string text = input.Trim();
            // Simple response logic based on user input
            if (input.Contains("how are you?"))
                return $"I am great {name}! Ready to keep you safe online.";
            if (input.Contains("what can i ask"))
                return $"You can ask about : Passwords Safety, Phising,Safe Browsing, My Purpose";
            if (input.Contains("Passwords Safety"))
                return $"To keep your passwords safe, use a combination of letters, numbers, and symbols. Avoid using information like birthdays or names as a password.";
            if (input.Contains("Phising"))
                return $"Phishing is a cyber attack that uses disguised email as a weapon. The goal is to trick the email recipient into believing that the message is something they want or need — a request from their bank, for instance, or a note from someone in their company — and to click a link or download an attachment.";
            if (input.Contains("Safe Browsing"))
                return $"Safe browsing is the practice of using the internet in a way that protects your personal information and devices from online threats. This includes using secure websites, avoiding suspicious links, and keeping your software up to date.";
            if (input.Contains(" My Purpose"))
                return "My purpose is to teach South Africans about cybersecurity, {name}.";
            else
                return $"I'm not sure how to respond to that, {name}. Can you ask something else?";
        }
    }
}
           