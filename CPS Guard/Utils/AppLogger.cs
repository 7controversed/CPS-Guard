using System;
using System.Diagnostics;
using System.IO;

namespace CPS_Guard
{
    public static class AppLogger
    {
        public static event Action<string> OnLogAdded;
        public static void Log(string message)
        {
            string formattedMessage = $"[{DateTime.Now:HH:mm:ss}] : {message}\r\n";
            OnLogAdded?.Invoke(formattedMessage);
        }

        public static void SaveLogsToFile(string fullLogText)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(fullLogText))
                {
                    string logsFolder = Path.Combine(ConfigManager.GetBaseFolder(), "logs");
                    if (!Directory.Exists(logsFolder)) Directory.CreateDirectory(logsFolder);
                    File.WriteAllText(Path.Combine(logsFolder, $"log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log"), fullLogText);
                }
            }
            catch { }
        }

        public static void OpenLogsFolder()
        {
            try
            {
                string logsFolder = Path.Combine(ConfigManager.GetBaseFolder(), "logs");
                if (!Directory.Exists(logsFolder)) Directory.CreateDirectory(logsFolder);
                Process.Start("explorer.exe", logsFolder);
                Log("Logs folder opened.");
            }
            catch
            {
                Log("Could not open logs folder.");
            }
        }
    }
}