# Steam Online Status Helper

A lightweight, self-contained Windows application that automatically keeps your Steam status set to "Online" to fix games that incorrectly set your status to "Offline".

## 🎮 Problem Solved

Some games have a bug where they automatically set your Steam status to "Offline" while you're playing, making you appear offline to your friends. This tool runs silently in the background and periodically resets your Steam status to "Online" every minute - but only when Steam is actually running.

## ✨ Features

- **🔄 Automatic Status Management**: Sets your Steam status to "Online" every minute
- **🎯 Smart Detection**: Only runs when Steam is detected (won't accidentally launch Steam)
- **📦 Self-Installing**: Automatically installs to Windows Startup folder on first run
- **🤫 Silent Operation**: Runs completely in the background with no UI or notifications
- **🚀 Self-Contained**: Single executable file with no external dependencies
- **🔒 Safe**: No registry modifications, no admin rights required

## 📋 How It Works

1. **First Run**: When you run the executable for the first time:
   - Copies itself to your Windows Startup folder
   - Starts the background service
   - Deletes the original executable (self-cleanup)

2. **Background Operation**: Once installed:
   - Checks every minute if Steam is running
   - If Steam is detected, sends `steam://friends/status/online` command
   - Continues running silently in the background

## 🚀 Quick Start

### Download & Run
1. Download the latest `SteamOnlineStatus.exe` from the [Releases](../../releases) page
2. Run the executable - it will automatically install and start working
3. That's it! Your Steam status will now stay online automatically

### Build from Source
```bash
# Clone the repository
git clone https://github.com/yourusername/Steam-Online-Status.git
cd Steam-Online-Status

# Build as self-contained executable
dotnet publish .\SteamOnlineStatus\SteamOnlineStatus.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true

# Or use the build scripts
build.bat       # Windows Batch script
build.ps1       # PowerShell script
```

The executable will be located at: `SteamOnlineStatus\bin\Release\net9.0\win-x64\publish\SteamOnlineStatus.exe`

## 🔍 Steam Process Detection

The application detects Steam by monitoring these processes:
- `steam.exe` - Main Steam client
- `Steam.exe` - Alternative Steam process name
- `steamwebhelper.exe` - Steam web helper process

## ✅ Verification

To verify the application is working:

1. **Check Installation**: Look for `SteamOnlineStatus.exe` in your Windows Startup folder:
   ```
   %APPDATA%\Microsoft\Windows\Start Menu\Programs\Startup
   ```

2. **Check Process**: Open Task Manager and look for `SteamOnlineStatus` in the processes list

3. **Test Steam Status**: With Steam running, your status should remain "Online" even if a game tries to set it to "Offline"

## 🗑️ Uninstallation

To remove the application:

1. **Stop the Process**: 
   - Open Task Manager
   - Find `SteamOnlineStatus` process
   - End the process

2. **Delete from Startup**:
   - Navigate to: `%APPDATA%\Microsoft\Windows\Start Menu\Programs\Startup`
   - Delete `SteamOnlineStatus.exe`

## 🛠️ Technical Details

- **Framework**: .NET 9.0
- **Target Platform**: Windows x64
- **Deployment**: Self-contained single-file executable
- **File Size**: ~12.8 MB (includes entire .NET runtime)
- **Dependencies**: None (fully self-contained)
- **Requirements**: Windows 10/11 (x64)

## 🎯 Perfect for Gamers

This application is designed specifically for gamers who:
- Want to stay online without manual intervention
- Experience games that incorrectly set Steam status to offline
- Need automated Steam status management without UI clutter
- Want a "set it and forget it" solution

## 🔧 Development

### Project Structure
```
Steam-Online-Status/
├── SteamOnlineStatus/           # Main C# project
│   ├── Program.cs               # Main application logic
│   └── SteamOnlineStatus.csproj # Project configuration
├── build.bat                    # Windows Batch build script
├── build.ps1                    # PowerShell build script
└── README.md                    # This file
```

### Contributing
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## ⚠️ Disclaimer

This tool uses Steam's official protocol (`steam://friends/status/online`) to change your status. It does not modify Steam files or use any unofficial APIs. Use at your own discretion.

---

**Made with ❤️ for the gaming community**
