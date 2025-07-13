@echo off
echo Building Steam Online Status as self-contained executable...
dotnet publish .\SteamOnlineStatus\SteamOnlineStatus.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true
echo.
echo Build complete! Executable location:
echo %~dp0SteamOnlineStatus\bin\Release\net9.0\win-x64\publish\SteamOnlineStatus.exe
pause
