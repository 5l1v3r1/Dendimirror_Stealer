// Decompiled with JetBrains decompiler
// Type: Decrypt.BerkeleyDB
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Decrypt
{
  public class BerkeleyDB
  {
    public string Version { get; set; }

    public List<KeyValuePair<string, string>> Keys { get; private set; }

    public BerkeleyDB(string FileName)
    {
      List<byte> byteList = new List<byte>();
      this.Keys = new List<KeyValuePair<string, string>>();
      using (BinaryReader binaryReader = new BinaryReader((Stream) File.OpenRead(FileName)))
      {
        int num = 0;
        for (int length = (int) binaryReader.BaseStream.Length; num < length; ++num)
          byteList.Add(binaryReader.ReadByte());
      }
      string str1 = BitConverter.ToString(this.Extract(byteList.ToArray(), 0, 4, false)).Replace("-", "");
      string str2 = BitConverter.ToString(this.Extract(byteList.ToArray(), 4, 4, false)).Replace("-", "");
      int int32 = BitConverter.ToInt32(this.Extract(byteList.ToArray(), 12, 4, true), 0);
      string str3 = "00061561";
      if (str1.Equals(str3))
      {
        this.Version = "Berkelet DB";
        if (str2.Equals("00000002"))
          this.Version = this.Version + " 1.85 (Hash, version 2, native byte-order)";
        int num1 = int.Parse(BitConverter.ToString(this.Extract(byteList.ToArray(), 56, 4, false)).Replace("-", ""));
        int num2 = 1;
        while (this.Keys.Count < num1)
        {
          string[] array = new string[(num1 - this.Keys.Count) * 2];
          for (int index = 0; index < (num1 - this.Keys.Count) * 2; ++index)
            array[index] = BitConverter.ToString(this.Extract(byteList.ToArray(), int32 * num2 + 2 + index * 2, 2, true)).Replace("-", "");
          Array.Sort<string>(array);
          int index1 = 0;
          while (index1 < array.Length)
          {
            int start1 = Convert.ToInt32(array[index1], 16) + int32 * num2;
            int start2 = Convert.ToInt32(array[index1 + 1], 16) + int32 * num2;
            int num3 = index1 + 2 >= array.Length ? int32 + int32 * num2 : Convert.ToInt32(array[index1 + 2], 16) + int32 * num2;
            string key = Encoding.ASCII.GetString(this.Extract(byteList.ToArray(), start2, num3 - start2, false));
            string str4 = BitConverter.ToString(this.Extract(byteList.ToArray(), start1, start2 - start1, false));
            if (!string.IsNullOrWhiteSpace(key))
              this.Keys.Add(new KeyValuePair<string, string>(key, str4));
            index1 += 2;
          }
          ++num2;
        }
      }
      else
        this.Version = "Unknow database format";
    }

    private byte[] Extract(byte[] source, int start, int length, bool littleEndian)
    {
      byte[] numArray = new byte[length];
      int index1 = 0;
      for (int index2 = start; index2 < start + length; ++index2)
      {
        numArray[index1] = source[index2];
        ++index1;
      }
      if (littleEndian)
        Array.Reverse((Array) numArray);
      return numArray;
    }

    private byte[] ConvertToLittleEndian(byte[] source)
    {
      Array.Reverse((Array) source);
      return source;
    }
  }
}
