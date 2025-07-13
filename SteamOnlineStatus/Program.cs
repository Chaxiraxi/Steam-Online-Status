using System.Diagnostics;
using System.Reflection;

namespace SteamStatusHelper
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                // Get current executable path - use Process.GetCurrentProcess().MainModule.FileName for self-contained apps
                string currentPath = Process.GetCurrentProcess().MainModule?.FileName ?? Environment.ProcessPath ?? throw new InvalidOperationException("Unable to determine current executable path");
                string exeName = Path.GetFileName(currentPath);
                string startupPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                    exeName
                );

                // If not running from Startup, install and start the new one
                if (!currentPath.Equals(startupPath, StringComparison.OrdinalIgnoreCase))
                {
                    InstallToStartup(currentPath, startupPath);
                    return;
                }

                // Main loop: run only if in startup location
                while (true)
                {
                    try
                    {
                        if (IsSteamRunning())
                        {
                            SetSteamStatusOnline();
                        }
                    }
                    catch
                    {
                        // Ignore errors and continue
                    }

                    // Check every minute
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                }
            }
            catch
            {
                // Wait a bit before potentially restarting
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
        }

        private static void InstallToStartup(string currentPath, string startupPath)
        {
            try
            {
                // Copy to startup path first
                File.Copy(currentPath, startupPath, true);

                // Start the new copy
                Process.Start(new ProcessStartInfo
                {
                    FileName = startupPath,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                });

                // Self-destruct with a delay if not in startup location
                if (!currentPath.Equals(startupPath, StringComparison.OrdinalIgnoreCase))
                {
                    string cmd = $"/C timeout /t 3 & del \"{currentPath}\"";
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = cmd,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    });
                }
            }
            catch
            {
                // Ignore installation errors
            }
        }

        private static bool IsSteamRunning()
        {
            try
            {
                // Check for multiple Steam process names
                string[] steamProcessNames = { "steam", "Steam", "steamwebhelper" };

                foreach (string processName in steamProcessNames)
                {
                    if (Process.GetProcessesByName(processName).Length > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private static void SetSteamStatusOnline()
        {
            try
            {
                Process.Start(new ProcessStartInfo("steam://friends/status/online")
                {
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                });
            }
            catch
            {
                // Ignore errors
            }
        }
    }
}
