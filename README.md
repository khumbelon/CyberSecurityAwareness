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
- **Interactive Responses:** Responds to user queries about:
  - Password safety and best practices
  - Phishing attacks and prevention strategies
  - Safe browsing techniques
  - Chatbot purpose and capabilities
- **Input Validation:** Ensures user queries are non-empty and appropriately handled
- **Colored Console Interface:** Uses ConsoleColor for enhanced visual appeal (Cyan, Green, etc.)
- **Case-Insensitive Matching:** Accepts user input in any case format

## Architecture

### Class Structure
1. **Program.cs** - Entry point; orchestrates initialization of `VoiceGreeting`, `AsciiArt`, and `Chatbot`
2. **VoiceGreeting.cs** - Handles audio playback of `greeting.wav` using `System.Media.SoundPlayer`
3. **AsciiArt.cs** - Displays colored ASCII art banner and application title
4. **Chatbot.cs** - Main conversational loop; manages user interaction and delegates response generation
5. **ResponseHandler.cs** - Generates context-aware responses based on user input using substring matching
6. **UserProfile.cs** - Data model storing user information (Name, FavoriteTopic)

### Program Flow
1.	Program.Main() executes
2.	VoiceGreeting.Play() plays greeting audio
3.	AsciiArt.Display() shows ASCII art banner
4.	Chatbot.Start() begins conversation:
•	Prompts for user name
•	Displays personalized greeting with topics
•	Enters loop: reads input → validates → delegates to ResponseHandler → displays colored output
•	Exits on "exit" command

## How to Run

### Prerequisites
- Visual Studio 2022 or .NET 8 SDK
- `greeting.wav` file (PCM WAV format, 16-bit, 44.1 kHz recommended)

### Setup & Execution
1. Clone or download the repository
2. Open the solution in Visual Studio 2022
3. Place `greeting.wav` in the project root folder (same directory as the `.csproj` file)
4. In Visual Studio, right-click `greeting.wav` → Properties → set **Copy to Output Directory** = **Copy if newer**
5. Build the project: **Build** → **Build Solution** (targets .NET 8)
6. Run the application:
   - **Debug Mode:** Press `F5` or **Debug** → **Start Debugging**
   - **Release Mode:** Press `Ctrl+F5` or **Debug** → **Start Without Debugging**

### User Interaction Example
================================================
CYBERSECURITY AWARENESS BOT
Welcome to the Cybersecurity Awareness Chatbot!
[ASCII Art Display]
Hello! What is your name? Enter your name: Lwazi
Welcome Lwazi ! I'm here to help you stay safer online. You can ask me questions about cybersecurity, and I'll do my best to provide helpful answers.
Lwazi: what can i ask Bot: You can ask about: Password safety, Phishing, Safe browsing, or My purpose.
Lwazi: password safety Bot: To keep your passwords safe, use a combination of letters, numbers, and symbols. Avoid using information like birthdays or names as a password.
Lwazi: exit [Application terminates]

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

## GitHub Actions

<img width="686" height="171" alt="CI" src="https://github.com/user-attachments/assets/780f624a-746e-4d3e-8c66-1df00063e2fb" />

.

## Video Presentation
Unlisted YouTube link:(https://youtu.be/fk-DmRKEFsc)

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

## Contact & Support
For questions or issues, please refer to the project requirements or contact your instructor.
