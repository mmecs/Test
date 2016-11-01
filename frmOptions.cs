using System;
using System.Windows.Forms;
using System.IO;
using System.Management;
using EventScheduler;
using System.Text;
using System.Runtime.InteropServices;

using Bienz.UI;
using System.Diagnostics;
using Bienz.SysInfo;

using IWshRuntimeLibrary;
using Shell32;



namespace msb.Backup
{
  /// <summary>
  /// Summary description for frmOptions.
  /// </summary>
  public partial class frmOptions : System.Windows.Forms.Form
  {

    BackupSetInfo bs = new BackupSetInfo();

    public frmOptions()
    {
      InitializeComponent();
      bs = new BackupSetInfo();
    }

    public frmOptions(BackupSetInfo SettingsInfoOf)
    {
      InitializeComponent();
      bs = SettingsInfoOf;
      tbxName.Text = bs.BackupName;
      #region Snr
      if (bs.BackupSnr == ""|| bs.BackupUSB == "false")
      {
          label6.Text = "nicht aktiviert";
      }
      else
      {
          label6.Text = bs.BackupSnr;
      }
      #endregion
      tbxDescription.Text = bs.BackupDescription;
      tbxBackupTo.Text = bs.BackupToDirectory;
      tbxAlternative.Text = bs.BackupToAlternative;
      maskedTextBox1.Text = bs.BackupStunde + ":" + bs.BackupMin;
      #region zip
      if (bs.BackupZip == "true")
        {
            checkBox13.Checked = true;
        }
        else
        { 
            checkBox13.Checked = false;
        }
      #endregion
      #region Shadow
      if (bs.BackupShadow == "true")
      {
          checkBox4.Checked = true;
      }
      else
      {
          checkBox4.Checked = false;
      }
      #endregion
      #region Löschen
      if (bs.BackupDel == "true")
      {
          cbLöschen.Checked = true;
      }
      else
      {
          cbLöschen.Checked = false;
      }
      #endregion
      #region usb
      if (bs.BackupUSB == "true")
        {
            checkBox1.Checked = true;
        }
        else
        {
            checkBox1.Checked = false;
        }
      #endregion
      #region Wend
      if (bs.BackupWend == "true")
        {
            checkBox3.Checked = true;
        }
        else
        {
            checkBox3.Checked = false;
        }
      #endregion
      #region Wstart
      if (bs.BackupWstart == "true")
        {
            checkBox2.Checked = true;
        }
        else
        {
            checkBox2.Checked = false;
        }
      #endregion
      #region Schedule
      if (bs.BackupSchedule == "true")
        {
            checkBox5.Checked = true;
        }
        else
        {
            checkBox5.Checked = false;
        }
#endregion
      #region So
      if (bs.BackupSo == "true")
      {
          checkBox12.Checked = true;
      }
      else
      {
          checkBox12.Checked = false;
      }
      #endregion
      #region Mo
      if (bs.BackupMo == "true")
      {
          checkBox6.Checked = true;
      }
      else
      {
          checkBox6.Checked = false;
      }
      #endregion
      #region Di
      if (bs.BackupDi == "true")
      {
          checkBox7.Checked = true;
      }
      else
      {
          checkBox7.Checked = false;
      }
      #endregion
      #region Mi
      if (bs.BackupMi == "true")
      {
          checkBox8.Checked = true;
      }
      else
      {
          checkBox8.Checked = false;
      }
      #endregion
      #region Do
      if (bs.BackupDo == "true")
      {
          checkBox9.Checked = true;
      }
      else
      {
          checkBox9.Checked = false;
      }
      #endregion
      #region Fr
      if (bs.BackupFr == "true")
      {
          checkBox10.Checked = true;
      }
      else
      {
          checkBox10.Checked = false;
      }
      #endregion
      #region Sa
      if (bs.BackupSa == "true")
      {
          checkBox11.Checked = true;
      }
      else
      {
          checkBox11.Checked = false;
      }
      #endregion
      if (bs.BackupDirectories != null)
        foreach (string s in bs.BackupDirectories)
          lbDirs.Items.Add(s);
    }

    private void btnOk_Click(object sender, System.EventArgs e)
    {
      if (tbxName.Text.Trim().Length > 0)
      {
        bs.BackupDescription = tbxDescription.Text;
        bs.BackupName = tbxName.Text;
        bs.BackupToDirectory = tbxBackupTo.Text;
        bs.BackupToAlternative = tbxAlternative.Text;
          if (checkBox4.Checked == true)
              bs.BackupShadow = "true";
          else
              bs.BackupShadow = "false";
          if (checkBox13.Checked == true)
              bs.BackupZip = "true";
          else
              bs.BackupZip = "false";

        #region Wstart
        if (checkBox2.Checked == true)
        {
            bs.BackupWstart = "true";
        }
        else
        {
            bs.BackupWstart = "false";
        }
        #endregion
        #region "Wend"
        if (checkBox3.Checked == true)
        {
            bs.BackupWend = "true";
        }
        else
        {
            bs.BackupWend = "false";
        }
        #endregion
        #region Schedule
        if (checkBox5.Checked == true)
        {
            bs.BackupSchedule = "true";
        }
        else
        {
            bs.BackupSchedule = "false";
        }
        #endregion
        #region So
        if (checkBox12.Checked == true)
        {
            bs.BackupSo = "true";
        }
        else
        {
            bs.BackupSo = "false";
        }
        #endregion
        #region Mo
        if (checkBox6.Checked == true)
        {
            bs.BackupMo = "true";
        }
        else
        {
            bs.BackupMo = "false";
        }
        #endregion
        #region Di
        if (checkBox7.Checked == true)
        {
            bs.BackupDi = "true";
        }
        else
        {
            bs.BackupDi = "false";
        }
        #endregion
        #region Mi
        if (checkBox8.Checked == true)
        {
            bs.BackupMi = "true";
        }
        else
        {
            bs.BackupMi = "false";
        }
        #endregion
        #region Do
        if (checkBox9.Checked == true)
        {
            bs.BackupDo = "true";
        }
        else
        {
            bs.BackupDo = "false";
        }
        #endregion
        #region Fr
        if (checkBox10.Checked == true)
        {
            bs.BackupFr = "true";
        }
        else
        {
            bs.BackupFr = "false";
        }
        #endregion
        #region Sa
        if (checkBox11.Checked == true)
        {
            bs.BackupSa = "true";
        }
        else
        {
            bs.BackupSa = "false";
        }
        #endregion
        #region Stunde
        bs.BackupStunde = maskedTextBox1.Text.Substring(0, 2); //_Time.Substring(1, 2);
        bs.BackupMin = maskedTextBox1.Text.Substring(3, 2);    //_Time.Substring(4, 2);
        #endregion
        bs.BackupSnr = label6.Text;
        bs.BackupDirectories.Clear();
        foreach (string s in lbDirs.Items)
          bs.BackupDirectories.Add(s);
        Backup backup = new Backup();
        backup.Update(bs);
        this.Close();
      }
      else
      {
        tabControl1.SelectedTab = tabGeneral;
        tbxName.Select();
        MessageBox.Show("Backup Name wird benötigt.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void btnCancel_Click(object sender, System.EventArgs e)
    {
      this.Close();
    }

    private void frmOptions_Load(object sender, System.EventArgs e)
    {
 
    }

    private void btnAddDirs_Click(object sender, System.EventArgs e)
    {
      string entry = tbxAddDirectory.Text.Trim();
      if (!entry.EndsWith("\\"))
        entry += "\\";
      if (Directory.Exists(entry))
      {
          lbDirs.Items.Add(entry);
          tbxAddDirectory.Text = "";
      }
      else
          MessageBox.Show("Verzeichniss existiert nicht", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void btnRemoveDirs_Click(object sender, System.EventArgs e)
    {
      lbDirs.Items.Remove(lbDirs.SelectedItem);
    }

    private void tbxAddDirectory_TextChanged(object sender, EventArgs e)
    {
      if (tbxAddDirectory.Text.Trim().Length > 0)
        btnAddFullDirs.Enabled = true;
      else
        btnAddFullDirs.Enabled = false;
    }

    private void btnDeleteBackupSet_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Sind Sie sicher das Sie diesen Job löschen wollen?", "Löschen ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
      {
        Backup backup = new Backup();
        backup.Delete(bs.BackupName);
        this.Close();
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult result = fb1.ShowDialog();
        if (result == DialogResult.OK)
        {
          tbxBackupTo.Text = fb1.SelectedPath += "\\" ;
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        DialogResult result = fb1.ShowDialog();
        if (result == DialogResult.OK)
        {
            tbxAddDirectory.Text = fb1.SelectedPath;
        }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked == true)
        {
            driveCombo1.Visible = true;
        }
        else
        {
            driveCombo1.Visible = false;
        }
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox2.Checked == true)

        {
            //string _Phat = System.IO.Path.Combine(Application.StartupPath, "Backup.exe");
            //string _Icon = System.IO.Path.Combine(Application.StartupPath, "App.ico");
            //CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\msb Backup.url", _Phat, _Icon); 
            CreateStartupFolderShortcut();
        }
        else
        {
           //System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\msb Backup.url" );
            //DeleteStartupFolderShortcuts(string targetExeName);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="shortcutPath"></param>
    /// <param name="shortcutDest"></param>
    /// <param name="shortcutIcon"></param>
   private void CreateShortcut(string shortcutPath, string shortcutDest, string shortcutIcon)
   {
       StreamWriter sw = new StreamWriter(shortcutPath);
       sw.WriteLine("[InternetShortcut]");
       sw.WriteLine("URL=file:///" + shortcutDest);
       sw.WriteLine("IconIndex=0");
       sw.WriteLine("IconFile=" + shortcutIcon);
       sw.Close();
   }

   public void CreateStartupFolderShortcut()
   {
       WshShellClass wshShell = new WshShellClass();
       IWshRuntimeLibrary.IWshShortcut shortcut;
       string startUpFolderPath =
         Environment.GetFolderPath(Environment.SpecialFolder.Startup);

       // Create the shortcut
       shortcut =
         (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(
           startUpFolderPath + "\\" +
           Application.ProductName + ".lnk");

       shortcut.TargetPath = Application.ExecutablePath;
       shortcut.WorkingDirectory = Application.StartupPath;
       shortcut.Description = "Launch My Application";
       // shortcut.IconLocation = Application.StartupPath + @"\App.ico";
       shortcut.Save();
   }

   public void DeleteStartupFolderShortcuts(string targetExeName)
   {
       string startUpFolderPath =
         Environment.GetFolderPath(Environment.SpecialFolder.Startup);

       DirectoryInfo di = new DirectoryInfo(startUpFolderPath);
       FileInfo[] files = di.GetFiles("*.lnk");

       foreach (FileInfo fi in files)
       {
           string shortcutTargetFile = GetShortcutTargetFile(fi.FullName);

           if (shortcutTargetFile.EndsWith(targetExeName,
                 StringComparison.InvariantCultureIgnoreCase))
           {
               System.IO.File.Delete(fi.FullName);
           }
       }
   }

   public string GetShortcutTargetFile(string shortcutFilename)
   {
       string pathOnly = Path.GetDirectoryName(shortcutFilename);
       string filenameOnly = Path.GetFileName(shortcutFilename);

       Shell32.Shell shell = new Shell32.ShellClass();
       Shell32.Folder folder = shell.NameSpace(pathOnly);
       Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
       if (folderItem != null)
       {
           Shell32.ShellLinkObject link =
             (Shell32.ShellLinkObject)folderItem.GetLink;
           return link.Path;
       }

       return String.Empty; // Not found
   }

   private void button3_Click(object sender, EventArgs e)
   {
       SchedulerUI.ShowSchedules();
   }

   private void driveCombo1_SelectedIndexChanged(object sender, EventArgs e)
   {
       VolumeInfo VI = driveCombo1.SelectedItem;
       if (VI != null)
       {
           MessageBox.Show("Seriennummer: " + VI.SerialNumber);
           label6.Text = Convert.ToString(VI.SerialNumber);
       }
   }

   private void cbLöschen_CheckedChanged(object sender, EventArgs e)
   {

   }

   private void button4_Click(object sender, EventArgs e)
   {
       DialogResult result = fb1.ShowDialog();
       if (result == DialogResult.OK)
       {
           tbxAlternative.Text = fb1.SelectedPath += "\\";
       }
   }

    
  }
}
