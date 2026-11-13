using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace BellezaTotal_UI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new UI_Main());

            bool testing = false;

            if (testing)
            {
                Application.Run(new UI_Main());
            }
            else
            {
                while (true)
                {
                    Console.WriteLine(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                    foreach (ConnectionStringSettings cs in ConfigurationManager.ConnectionStrings)
                        Console.WriteLine(cs.Name);

                    DialogResult resultadoLogin;

                    using (UI_Login formularioLogin = new UI_Login())
                    {
                        resultadoLogin = formularioLogin.ShowDialog();
                    }

                    // Si el login se cerró sin iniciar sesión, termina la aplicación
                    if (resultadoLogin != DialogResult.OK) break;

                    // Corre hasta que el menú se cierre (por logout o por la X)
                    using (UI_Main formularioMenu = new UI_Main())
                    {
                        Application.Run(formularioMenu);
                    }
                }
            }

        }
    }
}
