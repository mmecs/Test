
#region "using"
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ionic.Zip;
using System.Management;
using EventScheduler;

using System.Runtime.InteropServices;
using System.Text;

using Bienz.UI;
using System.Diagnostics;
using Bienz.SysInfo;

using System.IO;

using Microsoft.VisualBasic.Devices;

using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;

using NotificationWindow;

using usbWatch;
#endregion

namespace msb.Backup
{
  public partial class frmMain : Form
  {
      #region "Variablen"
      const int NB_SECOND_SLACK = 15;
      delegate void SetActionTextCallback(string text);
      delegate void MyAnzeigeDelegate(string msg);
      delegate void MyMeldung(string _art, string _text);
      Backup backup = new Backup();
      string[,] _USB = new string[26, 2];
      string[,] _USBa = new string[26, 2];
      Boolean _USBb = false;                // Sicherungslaufwerk vorhanden
      string _USBc = string.Empty;
      string _USBsnr = string.Empty;

      string _Ziel = string.Empty;
      string _Quel = string.Empty;
      string _LW = string.Empty;
      Boolean _Sichern = false;
      Boolean _Info = false;
      Boolean _BackupDel = false;
      int USBCount;
      int CDCount;
      Double _Prozent = 0;
      // tray icon
      private NotifyIcon _icon;
      // number of milliseconds after which a balloon tip will fade out automatically 
      private const int BALLOON_TIMEOUT = 20000;
      Computer myComputer = new Computer();
      PopupNotifier popupNotifier1 ;

      private List<DriveInfo> allDrives = new List<DriveInfo>();
      private const int WM_DEVICECHANGE = 0x219;
      private const int DBT_DEVICEARRIVAL = 0x8000;
      private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;

#endregion

    public frmMain()
    {
      InitializeComponent();

      popupNotifier1 = new NotificationWindow.PopupNotifier();

      popupNotifier1.AnimationDuration = 250;
      popupNotifier1.AnimationInterval = 1;
      popupNotifier1.BodyColor = System.Drawing.SystemColors.GradientActiveCaption;
      popupNotifier1.BorderColor = System.Drawing.Color.Aqua;
      popupNotifier1.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      popupNotifier1.ContentFont = new System.Drawing.Font("Tahoma", 8F);
      popupNotifier1.ContentPadding = new System.Windows.Forms.Padding(0, 17, 0, 0);
      popupNotifier1.ContentText = null;
      popupNotifier1.GradientPower = 300;
      popupNotifier1.HeaderColor = System.Drawing.Color.SteelBlue;
      popupNotifier1.HeaderFont = new System.Drawing.Font("Bookman Old Style", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      popupNotifier1.HeaderHeight = 20;
      popupNotifier1.HeaderPadding = new System.Windows.Forms.Padding(0);
      popupNotifier1.HeaderText = "msb.Backup";
      popupNotifier1.Image = global::msb.Backup.Properties.Resources.check;
      popupNotifier1.ImagePadding = new System.Windows.Forms.Padding(10, 13, 0, 0);
      popupNotifier1.ImageSize = new System.Drawing.Size(30, 30);
      popupNotifier1.OptionsMenu = null;
      popupNotifier1.Scroll = false;
      popupNotifier1.ShowCloseButton = false;
      popupNotifier1.Size = new System.Drawing.Size(220, 75);
      popupNotifier1.TitleColor = System.Drawing.Color.Black;
      popupNotifier1.TitleFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      popupNotifier1.TitlePadding = new System.Windows.Forms.Padding(0, 2, 0, 0);
      popupNotifier1.TitleText = "Hallo";

      popupNotifier1.TitleText = "Hallo";
      popupNotifier1.ContentText = "content text";
      popupNotifier1.ShowCloseButton = true;
      popupNotifier1.ShowOptionsButton = false;
      popupNotifier1.ShowGripText = true;
      popupNotifier1.Delay = 5000;
      popupNotifier1.AnimationInterval = 1;
      popupNotifier1.AnimationDuration = 400;
      popupNotifier1.Scroll = true;
      popupNotifier1.ShowCloseButton = true;

      popupNotifier1.Image = Properties.Resources.about;

    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      CreateTrayIcon();
      LoadBackupSets();
      foreach (BackupSetInfo bs in backup.ListOfBackupSetInfo)
      {
          if (bs.BackupName == cbxBackupName.Text)
          {
              if (bs.BackupDel == "true")
              {
                  _BackupDel = true;
              }
              else
              {
                  _BackupDel = false;
              }
              if (bs.BackupSchedule == "true")
              {
                  button1_Click(null, null);
              }
              label2.Text = bs.BackupDescription;
              if (bs.BackupSnr != "")
                  _USBsnr = bs.BackupSnr;
              break;

          }
      }
      allDrives = usbWatch.USBW.USBwatch.GetAllDrives();  
      CheckDrives();
      check_LW();
      Microsoft.Win32.SystemEvents.SessionEnding += new Microsoft.Win32.SessionEndingEventHandler(this.WinShutdown);
      Mehide();
    }
// Fenster ins Tray verschieben
    private void Mehide()
    {
        this.WindowState = FormWindowState.Minimized;
        this.Visible = false;
        this.ShowInTaskbar = false;
        _icon.Visible = true;
    }
// Tray Icn und beschriftung erstellen
    private void CreateTrayIcon()
    {
        _icon = new NotifyIcon();
        _icon.Icon = Properties.Resources.data_copy;
        _icon.Text = string.Format("Backup...");

        _icon.ContextMenuStrip = new ContextMenuStrip();

        _icon.ContextMenuStrip.Items.Add("Nach: " + _Ziel);
        _icon.ContextMenuStrip.Items[0].Enabled = false;

        _icon.ContextMenuStrip.Items.Add("Abbruch", Properties.Resources.delete, (s, e) => { Abort(); });
        _icon.ContextMenuStrip.Items.Add("Einstellungen", Properties.Resources.check, (s, e) => { Einstell(); });
        _icon.ContextMenuStrip.Items.Add("Menu", Properties.Resources.document_find, (s, e) => { Menue(); });
        _icon.ContextMenuStrip.Items.Add("Zeitplan", Properties.Resources.clock, (s, e) => { Zeitp(); });
        _icon.ContextMenuStrip.Items.Add("Starte Backup", Properties.Resources.data_forbidden, (s, e) => { SBackup(); });
        _icon.ContextMenuStrip.Items.Add("Beenden", Properties.Resources.warning, (s, e) => { Beenden(); });

        EnableAborting(true);

        _icon.Visible = true;

        //_icon.ShowBalloonTip(BALLOON_TIMEOUT, "Analysiere...", "suche änderungen...", ToolTipIcon.Info);
    }
    /// <summary>Enables or disables the abort context menu item.</summary>
    private void EnableAborting(bool enable)
    {
        if (_icon != null)
            _icon.ContextMenuStrip.Items[1].Enabled = enable;
    }
// Tray Icon wechseln
    public string strIcon = "App";
    private void trmIcon()
    {
        if (strIcon == "NewMsg")
        {
            _icon.Icon = new Icon("zip.ico");
            strIcon = "App";
        }
        else if (strIcon == "App")
        {
            _icon.Icon = new Icon("wzip.ico");
            strIcon = "NewMsg";
        }
        else if (strIcon == "ENDE")
        {
            _icon.Icon = Properties.Resources.data_copy4;
            strIcon = "App";
        }
    }
    public void Abort()
    {
        //if (HasStarted && !IsFinished)
        //    Finish(false);
    }
    public void Einstell()
    {
        if (cbxBackupName.SelectedItem != null)
            LoadOptions(cbxBackupName.SelectedValue.ToString());
        else
            MessageBox.Show("Bitte wählen Sie ein Backup-Set aus oder erstellen ein neues.", "Backup Set");
    }
    public void Menue()
    {
        this.Show();
        this.WindowState = FormWindowState.Normal;
        this.Visible = true;
        this.ShowInTaskbar = true;
        //_icon.Visible = false;
    }
    public void Zeitp()
    {
        SchedulerUI.ShowSchedules();
    }
    public void SBackup()
    {
        btnBackup_Click(button1, null);
    }
    public void Beenden()
    {
        this.Close();
    }
// Melden wenn Windows beendet wird
    private void WinShutdown(object sender, Microsoft.Win32.SessionEndingEventArgs e)
    {
        foreach (BackupSetInfo bs in backup.ListOfBackupSetInfo)
            if (bs.BackupWend == "true")
            {
                e.Cancel = true;
                NotiText("Meldung", "suche Änderungen                 ");
                btnBackup_Click(button1, null);
            }
    }
// Anzahl aller Laufwerke aufnehmen zum erkennen wenn sich was ändert
    private void CheckDrives()
    {
        USBCount = 0;
        foreach (System.IO.DriveInfo d in System.IO.DriveInfo.GetDrives())
        {
            if (d.DriveType == System.IO.DriveType.Removable)
                USBCount++;
            if (d.DriveType == System.IO.DriveType.CDRom)
                CDCount++;
            if (d.DriveType == System.IO.DriveType.Fixed)
                CDCount++;
            if (d.DriveType == System.IO.DriveType.Network)
                CDCount++;
            if (d.DriveType == System.IO.DriveType.NoRootDirectory)
                CDCount++;
            if (d.DriveType == System.IO.DriveType.Ram)
                CDCount++;
            if (d.DriveType == System.IO.DriveType.Unknown)
                CDCount++;
        }
    }
// Ereigniss Laufwerks erkennung 
    protected override void WndProc(ref Message m)
    {

        if (m.Msg == WM_DEVICECHANGE && m.WParam == (IntPtr)DBT_DEVICEARRIVAL)
        {
            NotiText("Meldung", "Wechseldatenträger           angeschlossen");
            check_LW();
            var _allDrives = usbWatch.USBW.USBwatch.newDrva(allDrives);
            if (_USBc == _allDrives.Item2)
            {
                _USBb = true; // Sicherungslaufwerk vorhanden
                _Info = false;
                NotiText("Meldung", "Starte sicherung..              Sicherungslaufwerk erkannt");
                btnBackup_Click(button1, null);
            }
        }

        if (m.Msg == WM_DEVICECHANGE && m.WParam == (IntPtr)DBT_DEVICEREMOVECOMPLETE)
        {
            NotiText("Meldung", "Wechseldatenträger            entfernt...");
            var _allDrives = usbWatch.USBW.USBwatch.remDrva(allDrives);
            if (_USBc == _allDrives.Item2)
            {
                _USBb = false;// Sicherungslaufwerk vorhanden
                _Info = true;
            }
        }
        base.WndProc(ref m);
    }
// Daten sichern starten 
    private void btnBackup_Click(object sender, EventArgs e)
    {
        if (listBox1.Items.Count > 0) //Logs vorhanden
        {
            string _dn = DateTime.Now.ToString("dd.MM.yyyy_HH_mm_ss");
            StreamWriter _fr = new StreamWriter(Application.StartupPath+"\\"+ _dn+ ".log");
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                _fr.WriteLine(listBox1.Items[i].ToString());
            }
            _fr.Close();
            listBox1.Items.Clear();
        }//ende Logs vorhanden
        Button btn = (Button)sender;
        if (btn.Name == "btnBackup") //Handsicherung
        {
            _Info=true;
        }// ende Handsicherung
      try
      {//try
        if (cbxBackupName.SelectedItem != null)
        {
          foreach (BackupSetInfo bs in backup.ListOfBackupSetInfo)
          {
            if (bs.BackupName == cbxBackupName.SelectedValue.ToString())
            {
                if (!Directory.Exists(bs.BackupToDirectory))
                {
                    if (bs.BackupToAlternative.ToString() == "")
                        break;
                    else
                        if (_USBb == false)                 // Kein Sicherungslaufwerk vorhanden
                            _Ziel = bs.BackupToAlternative; //dann Alternativen Sicherungspfad nehmen
                }
                else
                    _Ziel = bs.BackupToDirectory;
                _Quel = bs.BackupDirectories[0];
                if (bs.BackupSnr == "nicht aktiviert")
                {//
                    if (bs.BackupDirectories.Count > 0)
                    {//
                       
                        if (bs.BackupShadow == "true")
                        {//
                            this.backgroundWorker2.RunWorkerAsync();
                        }//
                        else
                        {//
                            frmProgress f1 = new frmProgress(bs, _Info); // Fortschrittsfenster anzeigen
                            if (_Info == true)
                                f1.ShowDialog();
                        }//
                    }//
                    else
                    {//
                        MessageBox.Show("Dieser Backup Job enthält kein Verzeichniss das gesichert werden soll. Bitte ein Verzeichniss auswählen.", "Kein Verzeichniss augewählt.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }//
                }//
                else
                {
                    if (_USBb == false && _Ziel != "") // Kein Sicherungslaufwerk vorhanden und Ersatzpfad nicht leer
                    {
                        if (this.backgroundWorker2.IsBusy != true)
                        {//
                            this.backgroundWorker2.RunWorkerAsync();
                            break;
                        }//
                        else
                        {//
                            break;
                        }//
                    }

                    for (int i = 0; i < 25; i++)
                    {//1
                        if (bs.BackupSnr == _USB[i,1])  //if (bs.BackupSnr == USBdef[i])
                        {//2
                            _LW = _USB[i, 0];
                            if (bs.BackupDirectories.Count > 0)
                            {//3
                                
                                if (bs.BackupShadow == "true")//ohne Progress Fenster anzeige
                                {//4
                                    if (this.backgroundWorker2.IsBusy != true)
                                    {//5
                                        this.backgroundWorker2.RunWorkerAsync();
                                        break;
                                    }//5
                                    else
                                    {//5
                                        break;
                                    }//5
                                }//4
                                else
                                {//4
                                    frmProgress f1 = new frmProgress(bs, _Info);
                                    i = 25;
                                    if (_Info == true)
                                        f1.ShowDialog();
                                }//4
                            }//3
                            else
                            {//3
                                MessageBox.Show("Dieser Backup Job enthält kein Verzeichniss das gesichert werden soll. Bitte ein Verzeichniss auswählen.", "Kein Verzeichniss augewählt.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }//3
                        }//2
                        else
                        {//2
                            if (i == 24 || _USB[i, 0] == null)
                            {//6
                                if (USBCount == 0)
                                {//7
                                    NotiText("Warnung", "USB nicht gefunden kein USB-Laufwerk angeschlossen.");
                                }//7
                                else
                                {//7
                                    if (_USBb == false)
                                    { 
                                    
                                    }
                                    else
                                        NotiText("Warnung", "USB nicht gefunden kein / falsches USB-Laufwerk.");
                                }//7
                            }//6
                        }//2
                    }//1
                }//
            }
          }
        }
        else
        {
          MessageBox.Show("Bitte wählen Sie ein Backup-Set aus oder erstellen ein neues.", "Backup Set");
        }
      }//Try
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Fehler");
      }
      // Windows runterfahren nach sicherung
      if (_Sichern == true)
        System.Diagnostics.Process.Start(System.Environment.SystemDirectory + "\\shutdown.exe", "-s -t 60");
    }
// Einstellungen anzeigen
    private void btnOptions_Click(object sender, EventArgs e)
    {
      if (cbxBackupName.SelectedItem != null)
        LoadOptions(cbxBackupName.SelectedValue.ToString());
      else
          MessageBox.Show("Bitte wählen Sie ein Backup-Set aus oder erstellen ein neues.", "Backup Set");
    }
// Einstellungen laden
    private void LoadOptions(string BackupName)
    {
      foreach (BackupSetInfo bs in backup.ListOfBackupSetInfo)
      {
        if (bs.BackupName == BackupName)
        {
          frmOptions f = new frmOptions(bs);
          f.ShowDialog();
          LoadBackupSets();
          break;
        }
      }
    }
// Backupeinstellungen des ausgewählten Job´s laden
    private void LoadBackupSets()
    {
      backup.LoadBackupSets();
      cbxBackupName.DataSource = null;
      cbxBackupName.DataSource = backup.ListOfBackupSetInfo;
      cbxBackupName.ValueMember = "BackupName";
      cbxBackupName.DisplayMember = "BackupName";
    }
// Beim Beenden schauen ob noch gesichert werden muss
    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        foreach (BackupSetInfo bs in backup.ListOfBackupSetInfo)       
        if (bs.BackupWend == "true" && _Sichern == false)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)  // UserClosing
                e.Cancel = true;         // Herunterfahren abbrechen
            _Sichern = true;             // Merker das gesichert wird und danach kann der PC runtergefahren werden.
            _Info = false;
            NotiText("Meldung", "Starte sicherung..                    vorm Runterfahren");
            btnBackup_Click(button1, null);
        }       
    }
//  Im Zeitplan eingestellte zeit erreicht sichern starten
    private void ScheduleCallBack(string scheduleName)
    {
        _Info = false;
        NotiText("Meldung", "Starte sicherung..                Zeitplangesteuert");
        btnBackup_Click(button1, null);
    }
// Zeitplan erstellen
    private void button1_Click(object sender, EventArgs e)
    {
        foreach (BackupSetInfo bs in backup.ListOfBackupSetInfo)
        {
            if (bs.BackupSchedule == "true")
            {
                int _H = Convert.ToInt16(bs.BackupStunde);
                int _M = Convert.ToInt16(bs.BackupMin);
                int _S = 0;
                DateTime dt = DateTime.Now;
                TimeSpan ts = new TimeSpan(_H, _M, _S);
                dt = dt.Date + ts;
                if (dt.CompareTo(DateTime.Now) <= 0)
                    dt = dt.AddDays(+1);
                String.Format("{0:dd.MM.yyyy HH:mm}", dt);
                Schedule s = new DailySchedule("Sicherung", dt);
                s.OnTrigger += new EventScheduler.Invoke(ScheduleCallBack);
                if (bs.BackupSo == "true")
                    s.SetWeekDay(DayOfWeek.Sunday, true);
                else
                    s.SetWeekDay(DayOfWeek.Sunday, false);
                if (bs.BackupMo == "true")
                    s.SetWeekDay(DayOfWeek.Monday, true);
                else
                    s.SetWeekDay(DayOfWeek.Monday, false);
                if (bs.BackupDi == "true")
                    s.SetWeekDay(DayOfWeek.Tuesday, true);
                else
                    s.SetWeekDay(DayOfWeek.Tuesday, false);
                if (bs.BackupMi == "true")
                    s.SetWeekDay(DayOfWeek.Wednesday, true);
                else
                    s.SetWeekDay(DayOfWeek.Wednesday, false);
                if (bs.BackupDo == "true")
                    s.SetWeekDay(DayOfWeek.Thursday, true);
                else
                    s.SetWeekDay(DayOfWeek.Thursday, false);
                if (bs.BackupFr == "true")
                    s.SetWeekDay(DayOfWeek.Friday, true);
                else
                    s.SetWeekDay(DayOfWeek.Friday, false);
                if (bs.BackupSa == "true")
                    s.SetWeekDay(DayOfWeek.Saturday, true);
                else
                    s.SetWeekDay(DayOfWeek.Saturday, false);
                Scheduler.AddSchedule(s);
                NotiText("Meldung", "Zeitplan angelegt               ");
            }
        }
    }
// Neuen Sicherungsjob 
    private void pictureBox2_Click(object sender, EventArgs e)
    {
        frmOptions f = new frmOptions();
        f.ShowDialog();
        LoadBackupSets();
    }

   public void Shutdown()
    {
        ManagementBaseObject mboShutdown = null;
        ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
        mcWin32.Get();

        // You can't shutdown without security privileges
        mcWin32.Scope.Options.EnablePrivileges = true;
        ManagementBaseObject mboShutdownParams =
                 mcWin32.GetMethodParameters("Win32Shutdown");

        // Flag 1 means we want to shut down the system. Use "2" to reboot.
        mboShutdownParams["Flags"] = "1";
        mboShutdownParams["Reserved"] = "0";
        foreach (ManagementObject manObj in mcWin32.GetInstances())
        {
            mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                           mboShutdownParams, null);
        }
    }

    private void frmMain_Resize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            Mehide();
        }
    }

    private void DoBackUp(string _Q, string _Z)
    {
        DateTime _start = DateTime.Now;
        int _neuer = 0;
        int _gleich = 0;
        _icon.ShowBalloonTip(BALLOON_TIMEOUT, "Starte sicherung....", "Kopiere...", ToolTipIcon.Info);
        listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "Starte sicherung...."+ Convert.ToString(DateTime.Now) });
        listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "Von  : " + _Q });
        listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "Nach : " + _Z });
        ReadOnlyCollection<string> lFiles = default(ReadOnlyCollection<string>);
        ReadOnlyCollection<string> rFiles = default(ReadOnlyCollection<string>);
        bool doCopy = false;
        bool fileExists = false;
        FileInfo fileDataRemote = default(FileInfo);
        FileInfo fileDataLocal = default(FileInfo);
        string TargetDir = _Z;
        string SourceDir = _Q;
        int _pro = 0;
        _icon.ShowBalloonTip(BALLOON_TIMEOUT, "Überprüfe....", "lokale & entfernte Dateien", ToolTipIcon.Info);  
        if (System.IO.Directory.Exists(SourceDir))
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            lFiles = myComputer.FileSystem.GetFiles(SourceDir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*");
            watch.Stop();
        }
        else
        {
            _icon.ShowBalloonTip(BALLOON_TIMEOUT, "Fehler", "Quellverzeichniss existiert nicht", ToolTipIcon.Info);
            return;
        }
        if (System.IO.Directory.Exists(TargetDir))
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            rFiles = myComputer.FileSystem.GetFiles(TargetDir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*");
            watch.Stop();
        }
        else
        {
            _icon.ShowBalloonTip(BALLOON_TIMEOUT, "Fehler", "Zielverzeichniss existiert nicht", ToolTipIcon.Info);
            System.IO.Directory.CreateDirectory(TargetDir);
            rFiles = myComputer.FileSystem.GetFiles(TargetDir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*");
        }
        listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { " lokale Datei(en)   " + Convert.ToString(lFiles.Count) + " gefunden" });
        listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "entfernte Datei(en) " + Convert.ToString(rFiles.Count) + " gefunden" });
        int iMax = lFiles.Count + rFiles.Count;
        double iValue = 100.0 / iMax;
        double iCount = 0;
        #region Überprüfen
        if (lFiles.Count > 0)
        {
            for (int i = 0; i <= lFiles.Count - 1; i++)
            {
                iCount += iValue;
                backgroundWorker2.ReportProgress(i);
               _pro= Convert.ToInt32(System.Math.Round(iCount, 0));
                fileDataLocal = myComputer.FileSystem.GetFileInfo(lFiles[i]);
                listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "prüfe Datei: " + fileDataLocal.Name });
                try
                {
                    fileDataRemote = myComputer.FileSystem.GetFileInfo(TargetDir + lFiles[i].Substring(SourceDir.Length));
                    double timeDiff = fileDataRemote.LastWriteTimeUtc.Subtract(fileDataLocal.LastWriteTimeUtc).TotalSeconds;
                    if (timeDiff < 0 | timeDiff > NB_SECOND_SLACK)
                    {
                        // We give NB_SECOND_SLACK seconds slacks for the file to be copied to the destination
                        // Looks like the datetime last write is the datetime of the source plus duration
                        // of copy
                        // gleich alte dateien überspringen
                        doCopy = true;
                        _neuer += 1;
                        if ((fileDataRemote.Attributes & FileAttributes.ReadOnly) != 0)
                        {
                            fileDataRemote.Attributes = fileDataRemote.Attributes & FileAttributes.ReadOnly;
                        }
                    }
                    else
                    {
                        _gleich += 1;
                    }
                }
                catch (Exception ex)
                {
                    doCopy = true;
                }
                if (doCopy == true)
                {
                    try
                    {
                        listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "Kopiere: " + fileDataLocal.Name });
                        //_icon.ShowBalloonTip(BALLOON_TIMEOUT, "Kopiere....", lFiles[i].Substring(SourceDir.Length).ToString(), ToolTipIcon.Info);
                        _icon.ShowBalloonTip(BALLOON_TIMEOUT, "Kopiere....", i.ToString() + " von " + lFiles.Count.ToString(), ToolTipIcon.Info);
                        myComputer.FileSystem.CopyFile(lFiles[i], TargetDir + lFiles[i].Substring(SourceDir.Length), true);
                    }
                    catch (Exception ex)
                    {
                        _icon.ShowBalloonTip(BALLOON_TIMEOUT, "Fehler....", ex.Message, ToolTipIcon.Error);
                    }
                }
                doCopy = false;
                fileExists = false;
            }
        }
        #endregion
        // Auf Sicherungslaufwerk vorhandene Dateien die nicht im Quelllaufwerk sind löschen
        if (rFiles.Count > 0 & lFiles.Count > 0 & _BackupDel == true)
        {
            for (int i = 0; i <= rFiles.Count - 1; i++)
            {
                iCount += iValue; 
                fileExists = myComputer.FileSystem.FileExists(SourceDir + rFiles[i].Substring(TargetDir.Length));
                if (fileExists == false)
                {
                    listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "lösche: " + rFiles[i] });
                    _icon.ShowBalloonTip(BALLOON_TIMEOUT, "lösche....",  rFiles[i] , ToolTipIcon.Info);
                    myComputer.FileSystem.DeleteFile(rFiles[i]);
                }
            }
        }
        if (this.backgroundWorker2.CancellationPending == false)
        {
            DateTime _stop = DateTime.Now;
            _icon.ShowBalloonTip(BALLOON_TIMEOUT, "Kopieren...", "beendet", ToolTipIcon.Info);
            listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "Fertig...." + Convert.ToString(DateTime.Now) });
            listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "Dauer...." + Convert.ToString(_stop - _start) });
            listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "Übersprungen...." + Convert.ToString(_gleich) });
            listBox1.Invoke(new MyAnzeigeDelegate(myAnzeige), new object[] { "Neuer...." + Convert.ToString(_neuer) });
        }
    }

    private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        if (listBox1.Items.Count > 0)
        {
            StreamWriter _fr = new StreamWriter(DateTime.Now.ToString() + ".log");
            for ( int i=0;i<listBox1.Items.Count;i++)
            {
                _fr.WriteLine(listBox1.Items[i].ToString());
            }
            _fr.Close();
            listBox1.Items.Clear();
        }
        DoBackUp(_Quel, _Ziel);
    }

    private void backgroundWorker2_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        trmIcon();
        _Prozent = e.ProgressPercentage;
    }

    private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
        strIcon = "ENDE";
        trmIcon();
    }

    public void myAnzeige(string msg)
    {
        listBox1.Items.Add(msg);
        listBox1.SelectedIndex = listBox1.Items.Count - 1;
        listBox1.SelectedIndex = -1;
    }

    public void SetActionText(string text)
    {
        // InvokeRequired required compares the thread ID of the
        // calling thread to the thread ID of the creating thread.
        // If these threads are different, it returns true.
        ////if (this.label1.InvokeRequired)
        ////{
        ////    SetActionTextCallback d = new SetActionTextCallback(SetActionText);
        ////    this.Invoke(d, new object[] { text });
        ////}
        ////else
        ////{
        ////    this.label1.Text = text;
        ////    this.label1.Refresh();
        ////}
        if (this.listBox1.InvokeRequired)
        {
            //SetActionTextCallback d = new SetActionTextCallback(SetActionText);
            //this.Invoke(d, new object[] { text });
            //listBox1.Invoke(() => listBox1.Items.Add({text});
            this.listBox1.Invoke(new SetActionTextCallback(SetActionText),listBox1.Items.Add(text));

        }

//        if( listBox.InvokeRequired )
//    listBox.Invoke(() => listBox.Items.Add("Some item");
//else
//    listBox.Items.Add("Some item");
    }

    private void NotiText(string _Titel, string _Text )
    {
        popupNotifier1.popup(_Titel, _Text, 10, 10, 10, 10, Properties.Resources.data_into);
    }

    public void chech_Snr()
    {
        foreach (BackupSetInfo bs in backup.ListOfBackupSetInfo)
            if (bs.BackupSnr != "" && bs.BackupUSB == "true" )
            {
                _Info = false;
                _USBb = true;    // Sicherungslaufwerk vorhanden erkannt
                NotiText("Meldung", "Starte sicherung..              Sicherungslaufwerk erkannt");
                btnBackup_Click(button1, null);
                break;
            }
    }

    public void check_LW()
    {
        int i = 0;
        Array.Copy(_USB, _USBa, 26);
        Array.Clear(_USB, 0, _USB.Length);
        foreach (string Drv in Directory.GetLogicalDrives())
        {
            try
            {
                Uri dUri = new Uri(Drv);
                VolumeInfo VI = new VolumeInfo(dUri);
                _USB[i, 0] = dUri.LocalPath;
                _USB[i, 1] = Convert.ToString(VI.SerialNumber);
                if (_USB[i, 1] == _USBsnr)
                {
                    _USBc = _USB[i, 0];
                    _USBb = true;       // Sicherungslaufwerk erkannt
                }
                i++;
            }
            catch { }
        }
    }
  }
}