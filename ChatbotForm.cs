using System;
using System.Drawing;
using System.Windows.Forms;

namespace CybersecurityChatbotGUI
{
    public partial class ChatbotForm : Form
    {
        private ChatBot chatBot = new ChatBot();
        private VoiceGreeting voiceGreeting = new VoiceGreeting();
        private MemoryStore memory = new MemoryStore();
        private bool userNameCaptured = false;
        private int emptyQuestionCount = 0;

        public ChatbotForm()
        {
            InitializeComponent();

            // Set form to fill entire screen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Cybersecurity Awareness Chatbot - Part 1";

            // Remove auto-docking to have manual control
            rtbChatHistory.Dock = DockStyle.None;
            txtUserInput.Dock = DockStyle.None;
            btnSend.Dock = DockStyle.None;

            // Configure chat history RichTextBox (fills most of form)
            rtbChatHistory.Font = new Font("Courier New", 11, FontStyle.Regular);
            rtbChatHistory.BackColor = Color.White;
            rtbChatHistory.ForeColor = Color.Black;
            rtbChatHistory.ReadOnly = true;
            rtbChatHistory.Location = new Point(10, 10);
            rtbChatHistory.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 100);
            rtbChatHistory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Configure input TextBox (bottom left)
            txtUserInput.Font = new Font("Arial", 12, FontStyle.Regular);
            txtUserInput.BackColor = Color.White;
            txtUserInput.ForeColor = Color.Black;
            txtUserInput.Multiline = false;
            txtUserInput.Location = new Point(10, this.ClientSize.Height - 80);
            txtUserInput.Size = new Size(this.ClientSize.Width - 130, 35);
            txtUserInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUserInput.AcceptsTab = false;
            txtUserInput.AcceptsReturn = false;

            // Configure send button (bottom right)
            btnSend.Font = new Font("Arial", 12, FontStyle.Bold);
            btnSend.BackColor = Color.FromArgb(0, 120, 215);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(this.ClientSize.Width - 110, this.ClientSize.Height - 80);
            btnSend.Size = new Size(100, 35);
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSend.Cursor = Cursors.Hand;
            btnSend.Text = "Send";

            // Add label for input prompt
            Label lblPrompt = new Label();
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Text = "Enter your name:";
            lblPrompt.Font = new Font("Arial", 11, FontStyle.Bold);
            lblPrompt.ForeColor = Color.Black;
            lblPrompt.Location = new Point(10, this.ClientSize.Height - 110);
            lblPrompt.Size = new Size(200, 25);
            lblPrompt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.Controls.Add(lblPrompt);

            // Set focus to input
            txtUserInput.Focus();
            txtUserInput.TabIndex = 1;
            btnSend.TabIndex = 2;
            rtbChatHistory.TabIndex = 0;

            // The delegate points to the method that displays chatbot output.
            chatBot.ResponseHandler = DisplayBotResponse;

            // Display ASCII art header
            DisplayAsciiArtHeader();

            // Play voice greeting (without blocking UI)
            try
            {
                voiceGreeting.PlayWelcome();
            }
            catch (Exception ex)
            {
                rtbChatHistory.AppendText($"[Voice greeting unavailable: {ex.Message}]" + Environment.NewLine);
            }
        }

        /// <summary>
        /// Displays the ASCII art banner and Part 1 identity in the chat history.
        /// </summary>
        private void DisplayAsciiArtHeader()
        {
            string asciiArt = @"
╔══════════════════════════════════════════════════════════╗
║    CYBERSECURITY AWARENESS CHATBOT                       ║
╚══════════════════════════════════════════════════════════╝

  ______   ______  _____ ____  ____  _____ ____ 
 / ___\ \ / / __ )| ____|  _ \/ ___|| ____/ ___|
| |    \ V /|  _ \|  _| | |_) \___ \|  _|| |    
| |___  | | | |_) | |___|  _ < ___) | |__| |___ 
 \____| |_| |____/|_____|_| \_\____/|_____\____| 

────────────────────────────────────────────────────────────

Welcome to the Cybersecurity Awareness Chatbot!

Please enter your name to get started.

────────────────────────────────────────────────────────────

";
            rtbChatHistory.AppendText(asciiArt);
            rtbChatHistory.AppendText(Environment.NewLine);
        }

        private void DisplayBotResponse(string message)
        {
            rtbChatHistory.AppendText("BOT: " + message + Environment.NewLine + Environment.NewLine);
            rtbChatHistory.ScrollToCaret();
        }

        private void DisplayWelcomeMessage(string userName)
        {
            string welcomeMsg = $@"
════════════════════════════════════════════════════════════

BOT: Welcome, {userName}! 👋

I'm your Cybersecurity Awareness Assistant.

You can ask me about:
  • Password Safety
  • Phishing
  • Scams
  • Privacy
  • Malware
  • Safe Browsing
  • Two-Factor Authentication

════════════════════════════════════════════════════════════

";
            rtbChatHistory.AppendText(welcomeMsg);
            rtbChatHistory.AppendText(Environment.NewLine);
            rtbChatHistory.ScrollToCaret();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtUserInput.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                // BEFORE NAME IS CAPTURED: Ask for name
                if (!userNameCaptured)
                {
                    rtbChatHistory.AppendText("BOT: Please enter your name to continue..." + Environment.NewLine + Environment.NewLine);
                    txtUserInput.Focus();
                    return;
                }

                // AFTER NAME IS CAPTURED: Check for quit if no questions
                emptyQuestionCount++;

                if (emptyQuestionCount >= 2)
                {
                    DialogResult result = MessageBox.Show(
                        $"You haven't asked any questions, {memory.UserName}. Would you like to quit?",
                        "No Questions Asked",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        rtbChatHistory.AppendText(Environment.NewLine + "BOT: Thank you for using the Cybersecurity Awareness Chatbot, " + memory.UserName + ". Stay safe online!" + Environment.NewLine);
                        System.Threading.Thread.Sleep(1000);
                        this.Close();
                    }
                    else
                    {
                        rtbChatHistory.AppendText("BOT: I'm ready to help! Ask me about cybersecurity." + Environment.NewLine + Environment.NewLine);
                        emptyQuestionCount = 0;
                    }
                }
                else
                {
                    rtbChatHistory.AppendText("BOT: Please ask me a question..." + Environment.NewLine + Environment.NewLine);
                }

                txtUserInput.Focus();
                return;
            }

            // Reset empty question counter when user enters input
            emptyQuestionCount = 0;

            // CAPTURE USER NAME
            if (!userNameCaptured)
            {
                string userName = input.Trim();
                memory.UserName = userName;
                userNameCaptured = true;

                // Display name entry with username instead of "YOU"
                rtbChatHistory.AppendText(userName + ": " + userName + Environment.NewLine);

                // Display welcome message
                DisplayWelcomeMessage(userName);

                // Update prompt label
                Label lblPrompt = this.Controls["lblPrompt"] as Label;
                if (lblPrompt != null)
                {
                    lblPrompt.Text = "Ask your question:";
                }

                txtUserInput.Clear();
                txtUserInput.Focus();
                return;
            }

            // NORMAL CONVERSATION (after name is captured)
            string userQuestion = input.Trim();

            // Display user input with username instead of "YOU"
            rtbChatHistory.AppendText(memory.UserName + ": " + userQuestion + Environment.NewLine);

            // Check for exit command
            if (userQuestion.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                rtbChatHistory.AppendText(Environment.NewLine + "BOT: Thank you for using the Cybersecurity Awareness Chatbot, " + memory.UserName + ". Stay safe online!" + Environment.NewLine);
                System.Threading.Thread.Sleep(1000);
                this.Close();
                return;
            }

            // Check for help command
            if (userQuestion.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                rtbChatHistory.AppendText("BOT: You can ask me about: password safety, phishing, scams, privacy, malware, safe browsing, or 2FA. Try saying 'I'm interested in phishing' or 'tell me more'." + Environment.NewLine + Environment.NewLine);
                txtUserInput.Clear();
                txtUserInput.Focus();
                rtbChatHistory.ScrollToCaret();
                return;
            }

            // Process normal chatbot response
            string response = chatBot.ProcessInput(userQuestion);
            chatBot.SendResponse(response);

            txtUserInput.Clear();
            txtUserInput.Focus();
            rtbChatHistory.ScrollToCaret();
        }

        // Allow Enter key to submit
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && txtUserInput.Focused)
            {
                btnSend_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}