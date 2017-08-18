// Decompiled with JetBrains decompiler
// Type: Decrypt.ByteHelper
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System;
using System.Globalization;

namespace Decrypt
{
  public static class ByteHelper
  {
    public static byte[] ConvertHexStringToByteArray(string hexString)
    {
      if (hexString.Length % 2 != 0)
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", new object[1]
        {
          (object) hexString
        }));
      byte[] numArray = new byte[hexString.Length / 2];
      for (int index = 0; index < numArray.Length; ++index)
      {
        string s = hexString.Substring(index * 2, 2);
        numArray[index] = byte.Parse(s, NumberStyles.HexNumber, (IFormatProvider) CultureInfo.InvariantCulture);
      }
      return numArray;
    }
  }
}
