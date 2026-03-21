using System;
using System.IO;
using System.Xml.Serialization;

namespace CPS_Guard
{
    #region 9. Configuration (Classe & Manager)

    public class AppConfig
    {
        public int CeilingCPS { get; set; } = 18;
        public int DebounceMS { get; set; } = 15;
        public bool RunStartup { get; set; } = false;
        public bool StartHidden { get; set; } = false;
        public bool TrayMinimize { get; set; } = false;
        public bool DisableApp { get; set; } = false;
        public bool AlertActive { get; set; } = false;
        public int AlertLimit { get; set; } = 18;
        public bool CheckUpdates { get; set; } = true;
        public bool LeftCount { get; set; } = true;
        public bool RightCount { get; set; } = true;
        public bool EnabledKeybind { get; set; } = false;
        public int KeybindValue { get; set; } = 0;
        public bool SavingLogs { get; set; } = true;
        public bool GuardState { get; set; } = false;
        public int DetectionMode { get; set; } = 0;
        public int ToleranceLevel { get; set; } = 2;
        public bool CeilMode { get; set; } = false;
        public bool SmartActivation { get; set; } = true;
        public int LanguageIndex { get; set; } = 0;
    }

    public static class ConfigManager
    {
        private static string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CPS Guard");
        private static string ConfigPath = Path.Combine(FolderPath, "config.xml");

        public static string GetBaseFolder() { return FolderPath; }

        public static void Save(AppConfig config)
        {
            try
            {
                if (!Directory.Exists(FolderPath)) Directory.CreateDirectory(FolderPath);
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                using (StreamWriter writer = new StreamWriter(ConfigPath)) { serializer.Serialize(writer, config); }
            }
            catch { }
        }

        public static AppConfig Load()
        {
            if (!File.Exists(ConfigPath)) return new AppConfig();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                using (StreamReader reader = new StreamReader(ConfigPath)) { return (AppConfig)serializer.Deserialize(reader); }
            }
            catch { return new AppConfig(); }
        }
    }

    #endregion
}