using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sanitaria;

namespace Sanitaria.UI.WinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Mis inyecciones
            var repositorio = new Sanitaria.Data.RepoPacienteCSV();
            var sistema = new GestorDeUrgencias(repositorio);
            // 

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(sistema));
        }
    }
}
