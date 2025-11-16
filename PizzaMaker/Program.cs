using System;
using System.Windows.Forms;

namespace PizzaMaker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmPizzaMaker());
        }
    }
}