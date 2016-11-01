using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using Ionic.Zip;
using System.Diagnostics;

namespace msb.Backup
{
  public class Backup
  {
    private int TotalFilesField;

    private int CopiedFilesField;

    public String mZip = "false";

    public int TotalFiles
    {
      get { return TotalFilesField; }
      set { TotalFilesField = value; }
    }

    public List<BackupSetInfo> ListOfBackupSetInfoField;

    public int CopiedFiles
    {
      get { return CopiedFilesField; }
      set { CopiedFilesField = value; }
    }

    public List<BackupSetInfo> ListOfBackupSetInfo
    {
      get { return ListOfBackupSetInfoField; }
      set { ListOfBackupSetInfoField = value; }
    }

    public Backup()
    {
      this.ListOfBackupSetInfo = new List<BackupSetInfo>();
    }

    /// <summary> Fast file move with big buffers
    /// </summary>
    /// <param name="source">Source file path</param> 
    /// <param name="destination">Destination file path</param> 
    static void FMove(string source, string destination)
    {
        int array_length = (int)Math.Pow(2, 20);
        byte[] dataArray = new byte[array_length];

        FileStream fsread = new FileStream(source, FileMode.Open, FileAccess.Read, FileShare.None, array_length * 2);
        BinaryReader bwread = new BinaryReader(fsread);
        FileStream fswrite = new FileStream(destination, FileMode.Create, FileAccess.Write, FileShare.None, array_length * 2);
        BinaryWriter bwwrite = new BinaryWriter(fswrite);

        for (; ; )
        {
            int read = bwread.Read(dataArray, 0, array_length);
            if (0 == read)
                break;
            bwwrite.Write(dataArray, 0, read);
        }
        bwwrite.Close();
        fswrite.Close();
        bwread.Close();
        fsread.Close();
        File.Delete(source);
    }


    public BackupResponseInfo BackupFiles(BackupSetInfo BackupSetInfoOf)
    {

        Stopwatch watch = new Stopwatch();
        watch.Start();

        string backupLocation = "";
      BackupResponseInfo response = new BackupResponseInfo();

      foreach (string sS in BackupSetInfoOf.BackupDirectories)
      {
        if (!Directory.Exists(sS))
        {
          response.IsSuccess = false;
          response.Message += "Fehler im Backup.  Verzeichniss " + sS + " existiert nicht.\r\n";
        }
        if (!Directory.Exists(BackupSetInfoOf.BackupToDirectory))
        {
            response.IsSuccess = false;
            response.Message += "Fehler im Backup.  Verzeichniss " + BackupSetInfoOf.BackupToDirectory + " existiert nicht.\r\n";
        }
      }

      if (BackupSetInfoOf.BackupZip == "true")
      {
          backupLocation = BackupSetInfoOf.BackupToDirectory + BackupSetInfoOf.BackupName;
          mZip = "true";
      }
      else
          backupLocation = BackupSetInfoOf.BackupToDirectory + BackupSetInfoOf.BackupName + "_" + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "\\";

      if (response.Message.Length < 1)
      {
// Zählen
        foreach (string sS in BackupSetInfoOf.BackupDirectories)
        {
          if (BackupSetInfoOf.BackupZip == "false")
          {
              DirectoryInfo dD = new DirectoryInfo(backupLocation + sS.Replace(":", ""));
              dD.Create();
              CopyDirectory(new DirectoryInfo(sS), dD, true);
          }
          //else
          //{
          //    DirectoryInfo zD = new DirectoryInfo(backupLocation);
          //    ZipDirectory(new DirectoryInfo(sS), zD, false);
          //}
        }
// Kopieren
        int _z = 0;
        string _backupLocation = backupLocation;
        foreach (string sS in BackupSetInfoOf.BackupDirectories)
        {
            if (BackupSetInfoOf.BackupZip == "false")
            {
                DirectoryInfo dD = new DirectoryInfo(backupLocation + sS.Replace(":", ""));
                dD.Create();
                CopyDirectory(new DirectoryInfo(sS), dD, false);
            }
            else
            {
                _z = _z + 1;
                backupLocation = _backupLocation + "_" + Convert.ToString(_z) + "--" + Convert.ToString(BackupSetInfoOf.BackupDirectories.Count) + "_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ".zip";
                DirectoryInfo zD = new DirectoryInfo(backupLocation);
                ZipDirectory(new DirectoryInfo(sS), zD, false); ;
            }
        }
// Fertig
        watch.Stop();
        response.IsSuccess = true;
        response.Message += "Backup erfolgreich beendet. Time spent: " + watch.Elapsed;
      } 
      return response;
    }

    private void ZipDirectory(DirectoryInfo Source, DirectoryInfo Destination, bool CountOnly)
    {
        using (ZipFile zip = new ZipFile())
       {
       //zip.UseUnicode= true;  // utf-8
       zip.AddDirectory(Source.FullName);
       this.TotalFiles = zip.Count;
       zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G") ;
       zip.Save(Destination.FullName);
       this.CopiedFiles = zip.Count;
       }
    }

    private void CopyDirectory(DirectoryInfo Source, DirectoryInfo Destination, bool CountOnly)
    {
      foreach (FileInfo f in Source.GetFiles())
      {
        if (CountOnly)
          this.TotalFiles++;
        else
        {
          f.CopyTo(Destination + @"\" + f.Name);
          this.CopiedFiles++;
        }
      }
      foreach (DirectoryInfo dS in Source.GetDirectories())
      {
        string newDirPart = dS.FullName.Replace(Source.FullName, "");
        string newDestinationPath = Destination + newDirPart;
        DirectoryInfo dD = new DirectoryInfo(newDestinationPath);
        dD.Create();
        CopyDirectory(dS, dD, CountOnly);
      }
    }

    public void Update(BackupSetInfo BackupSetInfoOf)
    {
      bool isUpdate = false;
      for (int i = 0; i < this.ListOfBackupSetInfo.Count; i++)
      {
        if (this.ListOfBackupSetInfo[i].BackupName == BackupSetInfoOf.BackupName)
        {
          this.ListOfBackupSetInfo[i] = BackupSetInfoOf;
          isUpdate = true;
        }
      }
      if (!isUpdate)
        this.ListOfBackupSetInfo.Add(BackupSetInfoOf);

      SerializeXml(BackupSetInfoOf.BackupName.Replace(" ", "") + ".backupset", typeof(BackupSetInfo), BackupSetInfoOf);
    }

    public void Delete(string Name)
    {
      File.Delete(Name + ".backupset");
    }

    public void LoadBackupSets()
    {
      this.ListOfBackupSetInfo.Clear();
      foreach (string fullFile in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
      {
        string[] fileArray = fullFile.Split(new char[] { '\\' });
        string file = fileArray[fileArray.GetUpperBound(0)];
        if (file.EndsWith(".backupset"))
        {
          BackupSetInfo si = (BackupSetInfo)DeserializeXml(file, typeof(BackupSetInfo));
          this.ListOfBackupSetInfo.Add(si);
        }
      }
    }

    private void SerializeXml(string FileName, Type ObjectType, object InstanceToSerialize)
    {
      File.Delete(FileName);
      using (FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + FileName, FileMode.Create))
      {
        using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs))
        {
          XmlSerializer serializer = new XmlSerializer(ObjectType);
          serializer.Serialize(writer, InstanceToSerialize);
        }
      }
    }

    private object DeserializeXml(string FileName, Type ObjectType)
    {
      using (FileStream fs = new FileStream(FileName, FileMode.Open))
      {
        using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, XmlDictionaryReaderQuotas.Max))
        {
          XmlSerializer serializer = new XmlSerializer(ObjectType);
          return serializer.Deserialize(reader);
        }
      }
    }
  }
}
