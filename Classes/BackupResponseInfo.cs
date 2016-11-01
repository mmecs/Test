using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace msb.Backup
{
  [Serializable]
  public class BackupResponseInfo
  {
    private bool IsSuccessField;

    private string MessageField;

    public bool IsSuccess
    {
      get { return IsSuccessField; }
      set { IsSuccessField = value; }
    }

    public string Message
    {
      get { return MessageField; }
      set { MessageField = value; }
    }

    public BackupResponseInfo()
    {
      this.Message = string.Empty;
      this.IsSuccess = true;
    }
  }
}
