// Decompiled with JetBrains decompiler
// Type: Decrypt.PasswordCheck
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System.Globalization;

namespace Decrypt
{
  public class PasswordCheck
  {
    public string EntrySalt { get; private set; }

    public string OID { get; private set; }

    public string Passwordcheck { get; private set; }

    public PasswordCheck(string DataToParse)
    {
      int length1 = int.Parse(DataToParse.Substring(2, 2), NumberStyles.HexNumber) * 2;
      this.EntrySalt = DataToParse.Substring(6, length1);
      int length2 = DataToParse.Length - (6 + length1 + 36);
      this.OID = DataToParse.Substring(6 + length1 + 36, length2);
      this.Passwordcheck = DataToParse.Substring(6 + length1 + 4 + length2);
    }
  }
}
