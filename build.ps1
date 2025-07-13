# Steam Online Status Helper - Build Script
# This script builds the project as a self-contained executable

Write-Host "Building Steam Online Status Helper..." -ForegroundColor Green
Write-Host ""

# Build the project
dotnet publish .\SteamOnlineStatus\SteamOnlineStatus.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "✅ Build completed successfully!" -ForegroundColor Green
    Write-Host ""
    Write-Host "📁 Executable location:" -ForegroundColor Yellow
    Write-Host "   $PWD\SteamOnlineStatus\bin\Release\net9.0\win-x64\publish\SteamOnlineStatus.exe"
    Write-Host ""
    Write-Host "🚀 Ready to run! Just execute the .exe file to install and start the service." -ForegroundColor Cyan
}
else {
    Write-Host ""
    Write-Host "❌ Build failed!" -ForegroundColor Red
    Write-Host "Please check the error messages above."
}

Write-Host ""
Write-Host "Press any key to continue..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
