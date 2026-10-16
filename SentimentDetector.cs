using System;
using System.Text;


namespace CybersecurityChatbotGUI
{ 
public enum Sentiment
{
    Neutral,
    Worried,
    Curious,
    Frustrated
}
class SentimentDetector
{
    public Sentiment DetectSentiment(string input) //class for detecting sentiment in user input
    {
        if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid"))
        {
            return Sentiment.Worried;
        }
        if (input.Contains("curious") || input.Contains("interested"))
        {
            return Sentiment.Curious;
        }
        if (input.Contains("frustrated") || input.Contains("annoyed"))
        {
            return Sentiment.Frustrated;
        }
        return Sentiment.Neutral;
    }
}
}
