// Decompiled with JetBrains decompiler
// Type: Decrypt.TripleDESHelper
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System.IO;
using System.Security.Cryptography;

namespace Decrypt
{
  public class TripleDESHelper
  {
    public static string DESCBCDecryptor(byte[] key, byte[] iv, byte[] input)
    {
      using (TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider())
      {
        cryptoServiceProvider.Key = key;
        cryptoServiceProvider.IV = iv;
        cryptoServiceProvider.Mode = CipherMode.CBC;
        cryptoServiceProvider.Padding = PaddingMode.None;
        ICryptoTransform decryptor = cryptoServiceProvider.CreateDecryptor(cryptoServiceProvider.Key, cryptoServiceProvider.IV);
        using (MemoryStream memoryStream = new MemoryStream(input))
        {
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
              return streamReader.ReadToEnd();
          }
        }
      }
    }

    public static byte[] DESCBCDecryptorByte(byte[] key, byte[] iv, byte[] input)
    {
      byte[] buffer = new byte[512];
      using (TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider())
      {
        cryptoServiceProvider.Key = key;
        cryptoServiceProvider.IV = iv;
        cryptoServiceProvider.Mode = CipherMode.CBC;
        cryptoServiceProvider.Padding = PaddingMode.None;
        ICryptoTransform decryptor = cryptoServiceProvider.CreateDecryptor(cryptoServiceProvider.Key, cryptoServiceProvider.IV);
        using (MemoryStream memoryStream = new MemoryStream(input))
        {
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
            cryptoStream.Read(buffer, 0, buffer.Length);
        }
      }
      return buffer;
    }
  }
}
