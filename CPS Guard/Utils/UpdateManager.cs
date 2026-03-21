using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace CPS_Guard
{
    public static class UpdateManager
    {
        private static readonly HttpClient _httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(5) };

        private const string REMOTE_VERSION_URL = "https://raw.githubusercontent.com/7controversed/CPS-Guard/refs/heads/settings/version";
        public const string DOWNLOAD_URL = "https://github.com/7controversed/CPS-Guard/releases";
        private const string URL_SRC_TIKTOK = "https://raw.githubusercontent.com/7controversed/CPS-Guard/refs/heads/settings/tiktoklnk";
        private const string URL_SRC_YOUTUBE = "https://raw.githubusercontent.com/7controversed/CPS-Guard/refs/heads/settings/youtubelnk";
        private const string URL_SRC_DISCORD = "https://raw.githubusercontent.com/7controversed/CPS-Guard/refs/heads/settings/discordlnk";
        public const string CURRENT_VERSION = "1.3";
        public static string LinkTikTok { get; private set; } = "";
        public static string LinkYoutube { get; private set; } = "";
        public static string LinkDiscord { get; private set; } = "";

        public static async Task<(bool hasUpdate, string newVersion)> CheckForUpdatesAsync()
        {
            try
            {
                string rawVersion = await _httpClient.GetStringAsync(REMOTE_VERSION_URL);
                Version currentVer = new Version(CURRENT_VERSION);
                Version remoteVer = new Version(rawVersion.Trim());

                if (remoteVer > currentVer)
                {
                    return (true, remoteVer.ToString());
                }
            }
            catch
            {
                
            }
            return (false, "");
        }

        public static async Task FetchSocialLinksAsync()
        {
            try
            {
                Task<string> taskTk = _httpClient.GetStringAsync(URL_SRC_TIKTOK);
                Task<string> taskYt = _httpClient.GetStringAsync(URL_SRC_YOUTUBE);
                Task<string> taskDc = _httpClient.GetStringAsync(URL_SRC_DISCORD);

                try { LinkTikTok = (await taskTk).Trim(); } catch { }
                try { LinkYoutube = (await taskYt).Trim(); } catch { }
                try { LinkDiscord = (await taskDc).Trim(); } catch { }
            }
            catch { }
        }

        public static void OpenLink(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                try { Process.Start(url); } catch { }
            }
        }
    }
}