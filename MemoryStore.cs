using System;
using System.Text;


namespace CybersecurityChatbotGUI
{
    public class MemoryStore //class for storing memory-related data for the chatbot
    {
        private Dictionary<string, string> userInterests = new Dictionary<string, string>();

        public string UserName { get; set; }
        public string FavouriteTopic { get; set; }
        public string CurrentTopic { get; set; }

        /// <summary>
        /// Saves a user's interest in a specific cybersecurity topic.
        /// </summary>
        public void SaveInterest(string userId, string topic)
        {
            if (userInterests.ContainsKey(userId))
            {
                userInterests[userId] = topic;
            }
            else
            {
                userInterests.Add(userId, topic);
            }
        }
            /// <summary>
            /// Retrieves the user's saved interest topic.
            /// </summary>
        public string GetInterest(string userId)
        {
            if (userInterests.ContainsKey(userId))
            {
                return userInterests[userId];
            }
            return string.Empty;
        }
    }
}
