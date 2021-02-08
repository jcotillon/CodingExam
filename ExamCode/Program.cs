using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamCode
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());

            LoginForm loginForm = new LoginForm();
            loginForm.Visible = false;

            LoginController controller = new LoginController(loginForm);
            controller.LoadView();
            loginForm.ShowDialog();
        }
    }
}
