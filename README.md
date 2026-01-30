# 🛡️ CPS Guard

**CPS Guard** is a lightweight, high-performance utility designed to monitor and regulate mouse clicks (Clicks Per Second). Built with C# and optimized for low latency, it features a modern UI and dual-channel protection (Left & Right clicks).

![Status](https://img.shields.io/badge/Status-Stable-brightgreen) ![Platform](https://img.shields.io/badge/Platform-Windows-blue) ![License](https://img.shields.io/badge/License-MIT-orange)

## ✨ Features

* **Dual-Channel Monitoring:** Independently track and limit Left and Right mouse buttons.
* **Active Protection:** Set a CPS ceiling (limit) to prevent accidental high clicking rates.
* **Humanized Debounce:** Intelligent algorithm to smooth out click patterns and prevent double-clicking issues.
* **Modern Dashboard:**
    * Live CPS counters.
    * Fluid, lag-free gauge visualizations (Arc Style).
    * Real-time graph toggle.
* **System Integration:**
    * **Single Instance:** Ensures only one version runs at a time.
    * **Tray Mode:** Minimize to system tray for background monitoring.
    * **Auto-Start:** Option to launch silently with Windows.
* **Safety:**
    * Auto-disable protection when the cursor is over the app (to prevent locking yourself out).
    * Low-level hooks (`WH_MOUSE_LL`) optimized for minimal CPU usage.

## 🚀 Installation

1.  Go to the [Releases](https://github.com/7controversed/CPS-Guard/releases) page.
2.  Download the latest `CPS.Guard.exe`.
3.  Run the executable (Portable - No installation required).

## ⚙️ How to use

1.  **Launch** the application.
2.  **Toggle Channels:** Check `Left` or `Right` checkboxes to enable monitoring for specific buttons.
3.  **Set Limits:**
    * **Ceiling CPS:** The maximum allowed clicks per second.
    * **Debounce Time:** The minimum delay between clicks (in ms).
4.  **Activate:** Click the big **"Guard"** shield button.
5.  *(Optional)* Enable alerts to get notified if you exceed a specific CPS threshold.

## 🛠️ Built With

* **Language:** C# (.NET Framework)
* **UI Library:** Guna.UI2
* **Packaging:** Costura.Fody (Single-file executable)

## ⚠️ Disclaimer

This software is intended for educational purposes, mouse debugging, and preventing accidental double-clicks.
**Use at your own risk in online games.** The author is not responsible for any bans or penalties resulting from the use of this software. Always check the terms of service of the platform you are using.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
*Created by [7controversed](https://github.com/7controversed)*
