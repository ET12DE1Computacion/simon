using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Simon
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BackEnd backEnd = new BackEnd("server=win2012-01;database=simon;uid=invitado;pwd=invitado;");
            Application.Run(new frmMenu(backEnd));
        }
    }
}
