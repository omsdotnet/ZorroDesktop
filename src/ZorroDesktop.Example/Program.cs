using System;
using System.Windows.Forms;

namespace ZorroDesktop.Example
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


      Application.Run(swagger.GetForm(new MySuperLogic()));
    }
  }
}
