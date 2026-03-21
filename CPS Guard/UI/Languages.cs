using System;

namespace CPS_Guard
{
    #region 10. Langues

    public interface ILanguage
    {
        string GuardEnabled { get; }
        string GuardDisabled { get; }
        string ModeHardTitle { get; }
        string ModeHardDesc { get; }
        string ModePulseTitle { get; }
        string ModePulseDesc { get; }
        string ModeSmartTitle { get; }
        string ModeSmartDesc { get; }
        string MaxCeiling { get; }
        string AverageCeiling { get; }
        string PressKey(int seconds);
        string KeyNone { get; }
        string AdminWarning(string procName);
        string TooltipAdminRestart { get; }
        string RasText { get; }
        string StartHiddenText { get; }
        string TrayMinimizeText { get; }
        string DisableAppText { get; }
        string HighCPSAlertText { get; }
        string CheckUpdatesText { get; }
        string SmartActivationText { get; }
        string CountLeftText { get; }
        string CountRightText { get; }
        string ThresholdsText { get; }
        string DebounceTimeText { get; }
        string AppBehaviorText { get; }
        string MiscText { get; }
        string PreferencesText { get; }
        string KeybindingText { get; }
        string SelectedLanguageText { get; }
        string SaveLogsText { get; }
        string OpenLogsFolderText { get; }
        string TabMainText { get; }
        string TabLogsText { get; }
        string TabSettingsText { get; }
        string TooltipRS { get; }
        string TooltipLeft { get; }
        string TooltipRight { get; }
        string TooltipGuard { get; }
        string TooltipCeiling { get; }
        string TooltipDebounce { get; }
        string TooltipSmartcut { get; }
        string TooltipHardcut { get; }
        string TooltipPulsecut { get; }
        string TooltipSH { get; }
        string TooltipCU { get; }
        string TooltipDA { get; }
        string TooltipTR { get; }
        string TooltipAL { get; }
        string TooltipLimit { get; }
        string TooltipKeybind { get; }
        string TooltipEK { get; }
        string TooltipSA { get; }
        string UpdateAvailableTitle { get; }
        string UpdateAvailableMessage(string version);
        string TrayMinimizedMessage { get; }
        string AlertLimitExceededTitle { get; }
        string AlertLimitExceededMessage(string msg);
        string AlertLeft(int cps);
        string AlertRight(int cps);
        string NotificationsDisabledTitle { get; }
        string NotificationsDisabledMessage { get; }
    }

    public class LangEN : ILanguage
    {
        public string GuardEnabled => "CPS Guard - Enabled";
        public string GuardDisabled => "CPS Guard - Disabled";
        public string ModeHardTitle => "Limiting Mode: Hard";
        public string ModeHardDesc => "Instant blocks at limit.";
        public string ModePulseTitle => "Limiting Mode: Safe";
        public string ModePulseDesc => "Dynamic limit with bursts.";
        public string ModeSmartTitle => "Limiting Mode: Smart";
        public string ModeSmartDesc => "Natural flow, allows bursts.";
        public string MaxCeiling => "Max Ceiling:";
        public string AverageCeiling => "Average Ceiling:";
        public string PressKey(int seconds) => $"Press a key ({seconds})...";
        public string KeyNone => "[None]";
        public string AdminWarning(string procName) => $"⚠️ Admin rights required for this window ({procName})";
        public string TooltipAdminRestart => "Click to restart CPS Guard as Administrator.";
        public string RasText => "Run at Windows startup";
        public string StartHiddenText => "Start hidden";
        public string TrayMinimizeText => "Minimize to tray on close";
        public string DisableAppText => "Disable GUARD over app window";
        public string HighCPSAlertText => "Alert on high CPS";
        public string CheckUpdatesText => "Check for updates at launch";
        public string CountLeftText => "Left Click";
        public string CountRightText => "Right Click";
        public string SmartActivationText => "Smart Activation";
        public string ThresholdsText => "Thresholds";
        public string DebounceTimeText => "Debounce Time:";
        public string AppBehaviorText => "Application Behavior";
        public string MiscText => "Miscellaneous";
        public string PreferencesText => "Preferences";
        public string KeybindingText => "Activation Keybinding";
        public string SelectedLanguageText => "Selected language";
        public string SaveLogsText => "Save logs as files";
        public string OpenLogsFolderText => "Open logs folder";
        public string TabMainText => "Dashboard";
        public string TabLogsText => "Console";
        public string TabSettingsText => "Settings";
        public string NotificationsDisabledTitle => "Notifications disabled";
        public string NotificationsDisabledMessage => "Windows notifications appear to be disabled on your system or 'Do Not Disturb' is active.\n\nYou won't see the high CPS alerts until you enable them in your Windows settings.";

        public string TooltipRS => "Automatically runs the app on Windows startup.";
        public string TooltipLeft => "Enable left click limiting.";
        public string TooltipRight => "Enable right click limiting.";
        public string TooltipGuard => "Enable CPS limiting system.";
        public string TooltipCeiling => "Defines the target CPS threshold.";
        public string TooltipDebounce => "Sets the minimum delay between clicks to prevent unintended double-clicks.";
        public string TooltipSmartcut => "Intelligently allows short CPS bursts while maintaining the overall target average.";
        public string TooltipHardcut => "Strictly enforces the target limit. Blocks any excess clicks instantly.";
        public string TooltipPulsecut => "Rhythmically fluctuates the limit to simulate human inconsistency.";
        public string TooltipSH => "Starts the app minimized to the system tray.";
        public string TooltipCU => "Automatically check updates when the app is launched.";
        public string TooltipDA => "Disables counting and blocking when the cursor is over the app.";
        public string TooltipTR => "Minimizes app to the system tray instead of closing it.";
        public string TooltipAL => "Send a Windows notification if your CPS exceeds the limit set below. Make sure your notifications are enabled!";
        public string TooltipLimit => "Sets the CPS threshold that triggers the alert.";
        public string TooltipKeybind => "Select a keybind. Press 'ESC' for \"None\".";
        public string TooltipEK => "Enables the keybinding activation/deactivation system.";
        public string TooltipSA => "In case you forget: automatically enables the limit if your CPS reach the defined threshold.";

        public string UpdateAvailableTitle => "Update Available";
        public string UpdateAvailableMessage(string version) => $"A new version of CPS Guard ({version}) is available!\n\nWould you like to download it now?";
        public string TrayMinimizedMessage => "Minimized to tray.";
        public string AlertLimitExceededTitle => "CPS Alert";
        public string AlertLimitExceededMessage(string msg) => $"Limit Exceeded! {msg}";
        public string AlertLeft(int cps) => $"Left: {cps}";
        public string AlertRight(int cps) => $"Right: {cps}";
    }

    // -------------------------------------------------------------------------------------------------------------------

    public class LangFR : ILanguage
    {
        public string GuardEnabled => "CPS Guard - Activé";
        public string GuardDisabled => "CPS Guard - Désactivé";
        public string ModeHardTitle => "Mode de limite: Hard";
        public string ModeHardDesc => "Blocage direct à la limite.";
        public string ModePulseTitle => "Mode de limite: Safe";
        public string ModePulseDesc => "Limite dynamique avec bursts.";
        public string ModeSmartTitle => "Mode de limite: Smart";
        public string ModeSmartDesc => "Flux naturel, tolère les bursts.";
        public string MaxCeiling => "Limite max:";
        public string AverageCeiling => "Limite moyenne:";
        public string PressKey(int seconds) => $"Appuyez sur une touche ({seconds})...";
        public string KeyNone => "[Aucune]";
        public string AdminWarning(string procName) => $"⚠️ Droits Admin requis pour cette fenêtre ({procName})";
        public string TooltipAdminRestart => "Cliquez ici pour redémarrer CPS Guard en tant qu'Administrateur.";
        public string RasText => "Lancer au démarrage de Windows";
        public string StartHiddenText => "Minimiser au lancement";
        public string TrayMinimizeText => "Minimiser à la fermeture";
        public string DisableAppText => "Désactiver GUARD sur sa fenêtre";
        public string HighCPSAlertText => "Alerter si CPS élevés";
        public string CheckUpdatesText => "Vérifier les mises à jour au lancement";
        public string CountLeftText => "Click gauche";
        public string CountRightText => "Click droit";
        public string SmartActivationText => "Activation intelligente";
        public string ThresholdsText => "Seuils";
        public string DebounceTimeText => "Temps de rebond:";
        public string AppBehaviorText => "Comportement de l'application";
        public string MiscText => "Divers";
        public string PreferencesText => "Préférences";
        public string KeybindingText => "Touche d'activation";
        public string SelectedLanguageText => "Langue sélectionnée";
        public string SaveLogsText => "Sauvegarder les logs";
        public string OpenLogsFolderText => "Ouvrir le dossier logs";
        public string TabMainText => "Dashboard";
        public string TabLogsText => "Console";
        public string TabSettingsText => "Options";
        public string NotificationsDisabledTitle => "Notifications désactivées";
        public string NotificationsDisabledMessage => "Les notifications Windows semblent être désactivées sur votre système, ou le mode 'Ne pas déranger' est actif.\n\nVous ne verrez pas les alertes de CPS élevés tant que vous ne les aurez pas activées dans les paramètres de Windows.";

        public string TooltipRS => "Lance automatiquement l'application au démarrage de Windows.";
        public string TooltipLeft => "Activer la limitation du click gauche.";
        public string TooltipRight => "Activer la limitation du click droit.";
        public string TooltipGuard => "Activer le système CPS Guard.";
        public string TooltipCeiling => "Définit le seuil de CPS cible.";
        public string TooltipDebounce => "Définit le délai minimum entre les clicks pour éviter les doubles clicks involontaires.";
        public string TooltipSmartcut => "Autorise intelligemment de courts bursts de CPS tout en maintenant la moyenne globale ciblée.";
        public string TooltipHardcut => "Applique strictement la limite cible. Bloque instantanément tout click excédentaire.";
        public string TooltipPulsecut => "Fait fluctuer la limite de manière rythmique pour simuler l'inconstance humaine.";
        public string TooltipSH => "Démarre l'application minimisée dans les icônes cachées (barre de tâches).";
        public string TooltipCU => "Vérifie automatiquement les mises à jour au lancement de l'application.";
        public string TooltipDA => "Désactiver le comptage et le blocage lorsque le curseur est sur l'application.";
        public string TooltipTR => "Minimise l'application dans les icônes cachées (barre des tâches) au lieu de la fermer.";
        public string TooltipAL => "Envoie une notification Windows si vos CPS dépassent la limite définie ci-dessous. Assurez-vous que vos notifications sont activées !";
        public string TooltipLimit => "Définit le seuil de CPS qui déclenche une notification d'alerte.";
        public string TooltipKeybind => "Sélectionnez un raccourci. Appuyez sur 'ECHAP' pour \"Aucune\".";
        public string TooltipEK => "Active le système d'activation/désactivation par raccourci clavier.";
        public string TooltipSA => "En cas d'oubli : active automatiquement la limite si vos CPS atteignent le seuil défini.";

        public string UpdateAvailableTitle => "Mise à jour disponible";
        public string UpdateAvailableMessage(string version) => $"Une nouvelle version de CPS Guard ({version}) est disponible !\n\nVoulez-vous la télécharger ?";
        public string TrayMinimizedMessage => "Minimisé dans la barre des tâches.";
        public string AlertLimitExceededTitle => "Alerte CPS";
        public string AlertLimitExceededMessage(string msg) => $"Limite dépassée ! {msg}";
        public string AlertLeft(int cps) => $"Gauche : {cps}";
        public string AlertRight(int cps) => $"Droit : {cps}";
    }

    #endregion
}