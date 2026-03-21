using System;
using System.Threading;
using System.Windows.Forms;

namespace CPS_Guard
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            bool createdNew;
            using (Mutex mutex = new Mutex(true, "CPSGuard_App_Mutex", out createdNew))
            {
                if (!createdNew)
                {
                    try
                    {
                        if (!mutex.WaitOne(2000, false))
                        {
                            return;
                        }
                    }
                    catch (AbandonedMutexException)
                    {
                    }
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}