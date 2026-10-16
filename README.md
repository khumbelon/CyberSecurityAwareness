# Cybersecurity Awareness Chatbot

## Student
**Name:** Nelwamondo Khumbelo  
**Student Number:** ST10498633  

## Project Description
The Cybersecurity Awareness Chatbot is an interactive console application designed to educate users about essential cybersecurity practices. It engages users through personalized conversations, providing information on critical topics such as password safety, phishing awareness, and safe browsing habits. The chatbot utilizes voice greetings, ASCII art, and a colored console interface to enhance user experience and promote retention of cybersecurity knowledge.

## Features
- **Voice Greeting:** Plays a welcome audio greeting (`greeting.wav`) using System.Media.SoundPlayer
- **ASCII Art Display:** Displays an engaging visual banner using colored console output
- **Personalized Greeting:** Captures user name and displays a friendly, customized welcome message
- **Interactive Responses
- **Input Validation:** Ensures user queries are non-empty and appropriately handled
- **Colored Console Interface:** Uses ConsoleColor for enhanced visual appeal (Cyan, Green, etc.)
- **Case-Insensitive Matching:** Accepts user input in any case format
- chat history displayed in form
- user type in bottom textbox + clicksend
- 

## Architecture
Part1
### Class Structure
1. **Program.cs** - Entry point; orchestrates initialization of `VoiceGreeting`, `AsciiArt`, and `Chatbot`
2. **VoiceGreeting.cs** - Handles audio playback of `greeting.wav` using `System.Media.SoundPlayer`
3. **AsciiArt.cs** - Displays colored ASCII art banner and application title
4. **Chatbot.cs** - Main conversational loop; manages user interaction and delegates response generation
5. **ResponseHandler.cs** - Generates context-aware responses based on user input using substring matching
6. **UserProfile.cs** - Data model storing user information (Name, FavoriteTopic)

Part 2
1. **Program.cs** - Entry: `Application.Run(new ChatbotForm());`
2. **ChatbotForm.cs** - Main GUI, chat display, Send button, RichTextBox history
3. **ChatbotForm.Designer.cs** - UI layout
4. **Chatbot.cs** - Reused logic, now called by Form, not console
5. **KeyWordRespondder.cs** -returns string to Form
6. **Assets/greeting.wav**
7. Sentiment- new part feature
8. MemoryStore.cs

### Program Flow
part1
1.	Program.Main() executes
2.	VoiceGreeting.Play() plays greeting audio
3.	AsciiArt.Display() shows ASCII art banner
4.	Chatbot.Start() begins conversation:
•	Prompts for user name
•	Displays personalized greeting with topics
•	Enters loop: reads input → validates → delegates to ResponseHandler → displays colored output
•	Exits on "exit" command

part2
- Program.Main() Application.run(chatbotform)
- ChatbotForm-load- Voicegreeting.play() +Display ASCII in label
- user type in a bottom textbox- click send
- exit form-close
## How to Run

### Prerequisites
- Visual Studio 2022 or .NET 8 SDK
- `greeting.wav` file (PCM WAV format, 16-bit, 44.1 kHz recommended)

### User Interaction Example
Part 1
================================================
CYBERSECURITY AWARENESS BOT
Welcome to the Cybersecurity Awareness Chatbot!
[ASCII Art Display]
Hello! What is your name? Enter your name: Lwazi
Welcome Lwazi ! I'm here to help you stay safer online. You can ask me questions about cybersecurity, and I'll do my best to provide helpful answers.
Lwazi: what can i ask Bot: You can ask about: Password safety, Phishing, Safe browsing, or My purpose.
Lwazi: password safety Bot: To keep your passwords safe, use a combination of letters, numbers, and symbols. Avoid using information like birthdays or names as a password.
Lwazi: exit [Application terminates]

part2

#### Part 2 - WFA GUI 
Form_Load Event
- VoiceGreeting.Play() -> greeting.wav plays
- RichTextBox shows:
  Welcome! I'm your Cybersecurity Awareness Assistant.
  You can ask me about:
  • Password Safety
  • Phishing
  • Scams
  • Privacy
  • Malware
  • Safe Browsing
  • Two-Factor Authentication

User Interaction - GUI
User types in bottom TextBox: "How can I protect my privacy?"
Clicks [Send] button
Bot displays in RichTextBox:
  YOU: How can I protect my privacy?
  BOT: Use a VPN when connecting to public Wi-Fi...

User types: "add task - remind me to check passwords"
Bot: Task added! Reminder set.

User types: "start quiz"
Bot: [Quiz Window Opens - 10 Cybersecurity Questions]

User types: "exit" or clicks X -> [Application closes, chat log saved]

## Requirements
- **Visual Studio 2022** (Community, Professional, or Enterprise edition)
- **.NET 8 SDK** (or later)
- **System.Windows.Extensions NuGet Package** (for `SoundPlayer` support):
- **Windows Audio Support** (for voice greeting playback)
- **C# 12.0** compiler

## Dependencies
| Package | Version | Purpose |
|---------|---------|---------|
| System.Windows.Extensions | 8.0.0 | Provides System.Media.SoundPlayer for audio playback |
| .NET Runtime | 8.0+ | Base runtime for .NET 8 console application |

## Technology Stack
- **Language:** C# 12.0
- **Framework:** .NET 8
- **IDE:** Visual Studio 2022
- **Audio:** System.Media.SoundPlayer (Windows)
- **Console UI:** System.Console with color support
- **WFA UI(part2)

## GitHub Actions

<img width="686" height="171" alt="CI" src="https://github.com/user-attachments/assets/780f624a-746e-4d3e-8c66-1df00063e2fb" />
<img width="674" height="146" alt="image" src="https://github.com/user-attachments/assets/fe49b8a8-b9f5-4dcf-b222-164862437771" />
3 tags: v0.5-alpha, v0.9-beta,v1.0

## Video Presentation
YouTube link:(https://youtu.be/fk-DmRKEFsc)

## References

### Cybersecurity Educational Resources
1. **Microsoft Security Documentation**
 - [Secure coding guidelines](https://docs.microsoft.com/en-us/dotnet/standard/security/)
 - [Password security best practices](https://docs.microsoft.com/en-us/windows/security/threat-protection/security-policy-settings/password-policy)

2. **OWASP (Open Worldwide Application Security Project)**
 - [Password Storage Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Password_Storage_Cheat_Sheet.html)
 - [Phishing Prevention Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Phishing_Prevention_Cheat_Sheet.html)
 - [Secure Coding Practices](https://owasp.org/www-project-secure-coding-practices-quick-reference-guide/)

3. **US-CERT (Cybersecurity and Infrastructure Security Agency)**
 - [Avoiding Social Engineering and Phishing Attacks](https://www.cisa.gov/phishing)
 - [Cybersecurity Tips and Alerts](https://us-cert.cisa.gov/ncas/tips)

4. **NIST (National Institute of Standards and Technology)**
 - [NIST Cybersecurity Framework](https://www.nist.gov/cyberframework/)
 - [SP 800-63B: Authentication and Lifecycle Management](https://pages.nist.gov/800-63-3/sp800-63b.html)

5. **.NET Documentation**
 - [System.Media.SoundPlayer Class](https://docs.microsoft.com/en-us/dotnet/api/system.media.soundplayer)
 - [Console Class - Console Output and Colors](https://docs.microsoft.com/en-us/dotnet/api/system.console)
 - [String.Contains() Method](https://docs.microsoft.com/en-us/dotnet/api/system.string.contains)

6. **C# Language Reference**
 - [String Interpolation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated-strings)
 - [Nullable Reference Types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references)
 - [Pattern Matching](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching)

7. **Phishing & Email Security**
 - [Anti-Phishing Working Group (APWG)](https://www.apwg.org/)
 - [FBI: Internet Crime Report - Phishing](https://www.fbi.gov/investigate/cyber/phishing)

8. **Password Security Resources**
 - [Have I Been Pwned - Password Database](https://haveibeenpwned.com/)
 - [NCSC Password Guidance](https://www.ncsc.gov.uk/collection/mobile-device-guidance/using-built-in-platform-features/managing-built-in-platform-features)

9. **Safe Browsing Best Practices**
 - [Google Safe Browsing](https://safebrowsing.google.com/)
 - [Mozilla Firefox: Protecting Your Privacy](https://www.mozilla.org/en-US/privacy/)

10. **Academic & Industry Standards**
  - [RFC 3394: NIST Recommended Elliptic Curves](https://tools.ietf.org/html/rfc3394)
  - [ISO/IEC 27001: Information Security Management](https://www.iso.org/isoiec-27001-information-security-management.html)

## License
This project is for educational purposes as part of the PROG6221 assessment.

## Author
Nelwamondo Khumbelo (ST10498633)

### Acknowledgments
- Inspired by OWASP and NIST cybersecurity standards
- Built with .NET 8 and C# 12.0
- Educational content sourced from official cybersecurity organizations
