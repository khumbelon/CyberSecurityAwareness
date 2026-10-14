using System;

namespace CybersecurityChatbotGUI
{
    public delegate void BotResponseHandler(string message);

    public class ChatBot
    {
        public BotResponseHandler ResponseHandler;

        private SentimentDetector sentimentDetector = new SentimentDetector();
        private KeywordResponder keywordResponder = new KeywordResponder();
        private MemoryStore memory = new MemoryStore();

        public string ProcessInput(string userInput)
        {
            // STEP 1-2: Read and trim user input
            string trimmedInput = userInput.Trim();

            // STEP 3: Check for blank input
            if (string.IsNullOrWhiteSpace(trimmedInput))
            {
                return "Please type a question about cybersecurity first.";
            }

            // STEP 4: Normalise case for comparisons
            string normalizedInput = trimmedInput.ToLower();

            // STEP 5: Detect sentiment from user input
            Sentiment userSentiment = sentimentDetector.DetectSentiment(normalizedInput);

            // STEP 6-7: Detect topic or follow-up
            string keywordResponse = keywordResponder.GetResponse(trimmedInput, memory);

            // STEP 8: If no response, use default
            if (string.IsNullOrEmpty(keywordResponse))
            {
                keywordResponse = "I'm not sure about that topic. Try asking about: passwords, phishing, scams, privacy, malware, safe browsing, or 2FA.";
            }

            // STEP 9: Update memory with current topic
            memory.CurrentTopic = keywordResponder.GetCurrentTopic();

            // STEP 10: Adjust wording using sentiment
            string finalResponse = keywordResponse;

            if (userSentiment == Sentiment.Worried)
            {
                finalResponse = $"I understand this can feel concerning. {finalResponse}";
            }
            else if (userSentiment == Sentiment.Frustrated)
            {
                finalResponse = $"I hear your frustration. Let's work through this. {finalResponse}";
            }
            else if (userSentiment == Sentiment.Curious)
            {
                finalResponse = $"Great question! {finalResponse}";
            }

            // Add personalization with memory if available
            if (!string.IsNullOrEmpty(memory.UserName))
            {
                finalResponse = $"{finalResponse}";
            }

            if (!string.IsNullOrEmpty(memory.GetInterest("user")))
            {
                string interest = memory.GetInterest("user");
                if (memory.CurrentTopic != interest && !finalResponse.Contains(interest))
                {
                    // Don't force interest into every response, only when relevant
                }
            }

            return finalResponse;
        }

        /// <summary>
        /// Sends the bot response to the UI via the ResponseHandler delegate.
        /// </summary>
        public void SendResponse(string message)
        {
            ResponseHandler?.Invoke(message);
        }
    }
}