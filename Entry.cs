using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace msb.Backup
{
  class Entry
  {
    [STAThread]
    static void Main(string[] a) 
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new frmMain());
    }
  }
}
