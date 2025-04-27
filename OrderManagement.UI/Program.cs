// OrderManagement.UI/Program.cs
using System;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using OrderManagement.UI.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrderManagement.UI
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
            Application.Run(new LoginForm());
        }
    }
}

