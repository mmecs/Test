using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Threading;

namespace msb.Backup
{
  public partial class frmProgress : System.Windows.Forms.Form
  {
    msb.Backup.frmMain _ende = new frmMain();
    Backup backup = new Backup();
    private BackupSetInfo settingsInfo = new BackupSetInfo();
    private static BackupResponseInfo response = new BackupResponseInfo();
    private Thread t;
    private Boolean _Info = false;
    public delegate void BackupFinishedDelegate();

    public frmProgress(BackupSetInfo SettingsInfoOf , Boolean Info)
    {
        _Info = Info;
      InitializeComponent();
      settingsInfo = SettingsInfoOf;
      if (Info == false)
      {
          t = new Thread(delegate() { BackupStart(this.settingsInfo); });
          t.Start();
      }
    }

    private void ProcessError(Exception ex)
    {
      this.Cursor = Cursors.Arrow;
      MessageBox.Show(ex.Message + "\r\n" + ex.ToString());
    }

    private void btnDo_Click(object sender, System.EventArgs e)
    {
      timer1.Enabled = false;
      if (btnDo.Text.ToLower().StartsWith("Abbruch"))
        t.Abort();
      this.Close();
    }

    private void frmProgress_Load(object sender, System.EventArgs e)
    {
      t = new Thread(delegate() { BackupStart(this.settingsInfo); });
      t.Start();
      timer1.Enabled = true;
    }

    private void BackupStart(BackupSetInfo SettingsInfoOf)
    {
      response = backup.BackupFiles(SettingsInfoOf);
     if (_Info == true)
        this.Invoke(new BackupFinishedDelegate(BackupFinished));
    }

    private void BackupFinished()
    {
      lblStatus.Text = response.Message;
      //if (backup.mZip == "true")
      //{
      //    this.progressBar1.Maximum = 100;
      //    backup.TotalFiles = 1;
      //    this.progressBar1.Value = progressBar1.Maximum;
      //    timer1.Enabled = false;
      //}
      btnDo.Text = "OK";
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.progressBar1.Maximum = backup.TotalFiles;
      if(backup.CopiedFiles<=progressBar1.Maximum)
        this.progressBar1.Value = backup.CopiedFiles;
    }

    private void frmProgress_FormClosed(object sender, FormClosedEventArgs e)
    {
       _ende.Shutdown();
    }
  }
}
