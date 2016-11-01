using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace msb.Backup
{
  [Serializable]
  public class BackupSetInfo
  {
    private string BackupDescriptionField;

    private string BackupNameField;

    private List<string> BackupDirectoriesField;

    private string BackupToDirectoryField;

    private string BackupToAlternativeField;

    private string BackupZipField;

    private string BackupShadowField;

    private string BackupDelField;

    private string BackupUSBField;

    private string BackupWendField;

    private string BackupWstartField;

    private string BackupScheduleField;

    private string BackupStundeField;

    private string BackupMinField;

    private string BackupTageField;

    private string BackupSoField;

    private string BackupMoField;

    private string BackupDiField;

    private string BackupMiField;

    private string BackupDoField;

    private string BackupFrField;

    private string BackupSaField;

    private string BackupUSBSnr;

    public string BackupDescription
    {
      get { return BackupDescriptionField; }
      set { BackupDescriptionField = value; }
    }

    public string BackupName
    {
      get { return BackupNameField; }
      set { BackupNameField = value; }
    }

    public List<string> BackupDirectories
    {
      get { return BackupDirectoriesField; }
      set { BackupDirectoriesField = value; }
    }

    public string BackupToDirectory
    {
      get { return BackupToDirectoryField; }
      set { BackupToDirectoryField = value; }
    }

    public string BackupToAlternative
    {
        get { return BackupToAlternativeField; }
        set { BackupToAlternativeField = value; }
    }

    public String BackupZip
    {
        get { return BackupZipField; }
        set { BackupZipField = value; }
    }

    public String BackupShadow
    {
        get { return BackupShadowField; }
        set { BackupShadowField = value; }
    }

    public String BackupDel
    {
        get { return BackupDelField; }
        set { BackupDelField = value; }
    }

    public String BackupUSB
    {
        get { return BackupUSBField; }
        set { BackupUSBField = value; }
    }

    public String BackupWend
    {
        get { return BackupWendField; }
        set { BackupWendField = value; }
    }

    public String BackupWstart
    {
        get { return BackupWstartField; }
        set { BackupWstartField = value; }
    }

    public String BackupSchedule
    {
        get { return BackupScheduleField; }
        set { BackupScheduleField = value; }
    }

    public String BackupStunde
    {
        get { return BackupStundeField; }
        set { BackupStundeField = value; }
    }

    public String BackupMin
    {
        get { return BackupMinField; }
        set { BackupMinField = value; }
    }

    public String BackupTage
    {
        get { return BackupTageField; }
        set { BackupTageField = value; }
    }

    public String BackupSo
    {
        get { return BackupSoField; }
        set { BackupSoField = value; }
    }

    public String BackupMo
    {
        get { return BackupMoField; }
        set { BackupMoField = value; }
    }

    public String BackupDi
    {
        get { return BackupDiField; }
        set { BackupDiField = value; }
    }

    public String BackupMi
    {
        get { return BackupMiField; }
        set { BackupMiField = value; }
    }

    public String BackupDo
    {
        get { return BackupDoField; }
        set { BackupDoField = value; }
    }

    public String BackupFr
    {
        get { return BackupFrField; }
        set { BackupFrField = value; }
    }

    public String BackupSa
    {
        get { return BackupSaField; }
        set { BackupSaField = value; }
    }

    public string BackupSnr
    {
        get { return BackupUSBSnr; }
        set { BackupUSBSnr = value; }
    }

    public BackupSetInfo()
    {
      this.BackupDirectories = new List<string>();
    }
  }
}
