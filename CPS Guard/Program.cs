using System;
using System.Threading;
using System.Windows.Forms;

namespace CPS_Guard
{
    static class Program
    {
        // Création d'un ID unique pour ton application
        private static Mutex mutex = null;

        [STAThread]
        static void Main()
        {
            const string appName = "Global\\CPS_Guard_Unique_ID_BLSQUAD";
            bool createdNew;

            // On essaie de créer le verrou
            mutex = new Mutex(true, appName, out createdNew);

            // Si createdNew est faux, c'est que l'appli tourne déjà !
            if (!createdNew)
            {
                return; 
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Gestion globale des crashs (pour éviter que l'appli disparaisse sans rien dire)
            Application.ThreadException += (sender, args) => MessageBox.Show($"Error: {args.Exception.Message}", "Critical Error");

            Application.Run(new Form1());
        }
    }
}