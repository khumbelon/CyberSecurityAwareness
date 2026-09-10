using System;//imports system namespace for console input and output

namespace CyberSecurityAwarenessBot// name of the project and namespace
{
    public class Chatbot // This class represents the chatbot
    {
        private UserProfile user = new UserProfile(); // This field holds the user's profile information
        private ResponseHandler handler = new ResponseHandler(); // This field handles the chatbot's responses

        public void Start() // This method starts the chatbot interaction
        {
            Console.WriteLine(" Hello! What is your name?\r\n"); // Greet the user
            Console.Write("Enter your name: ");// Prompt the user to enter their name
            string? inputName = Console.ReadLine();// Read the user's input for their name
            user.Name = string.IsNullOrWhiteSpace(inputName) ? "User" : inputName.Trim(); // Read and sanitize the user's name

            Console.WriteLine($"Welcome {user.Name} !"); // Greet the user by name
            Console.WriteLine(" I'm here to help you stay safer online."); // Introduce the chatbot's purpose
            Console.WriteLine("you can ask me questions about cybersecurity, and I'll do my best to provide helpful answers."); 

            while (true) // using the while loop
            {
                Console.Write($"{user.Name}: ");// Prompt the user to enter a question
                string? q = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(q)) // Check if the input is empty or whitespace
                {
                    Console.WriteLine("Bot: Please enter a valid question."); // Prompt the user to enter a valid question
                    continue; // Continue to the next iteration of the loop
                }

                if (q.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                string response = handler.GetResponse(q, user.Name); // Get the chatbot's response to the user's question
                Console.ForegroundColor = ConsoleColor.Green; // Set the console text color to green    
                Console.WriteLine($"Bot: {response}"); // Display the chatbot's response
                Console.ResetColor(); // Reset the console text color to default
            }
        }
    }
}
