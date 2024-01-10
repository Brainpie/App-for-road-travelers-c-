using System;
using System.Windows.Forms;

namespace Kursach_PIS
{
    internal static class Program
    {
        static FormManager formManager;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            formManager = new FormManager();
        }
    }
}
