using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameWork;


namespace IE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Culture.InitializePersianCulture();


            var splashScreen = new IE.Views.SplashScreenForm();
            var result = splashScreen.ShowDialog();
            if (result != DialogResult.OK)
                return;

            var loginForm = new Views.Login();
            result = loginForm.ShowDialog();

            var mainForm = new Main();
            mainForm.ShowDialog();
            Application.Run(new Main());
        }
    }
}
