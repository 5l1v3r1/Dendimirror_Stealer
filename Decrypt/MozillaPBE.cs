// Decompiled with JetBrains decompiler
// Type: Decrypt.MozillaPBE
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System;
using System.Security.Cryptography;

namespace Decrypt
{
  public class MozillaPBE
  {
    private byte[] GlobalSalt { get; set; }

    private byte[] MasterPassword { get; set; }

    private byte[] EntrySalt { get; set; }

    public byte[] Key { get; private set; }

    public byte[] IV { get; private set; }

    public MozillaPBE(byte[] GlobalSalt, byte[] MasterPassword, byte[] EntrySalt)
    {
      this.GlobalSalt = GlobalSalt;
      this.MasterPassword = MasterPassword;
      this.EntrySalt = EntrySalt;
    }

    public void Compute()
    {
      SHA1CryptoServiceProvider cryptoServiceProvider = new SHA1CryptoServiceProvider();
      byte[] numArray1 = new byte[this.GlobalSalt.Length + this.MasterPassword.Length];
      Array.Copy((Array) this.GlobalSalt, 0, (Array) numArray1, 0, this.GlobalSalt.Length);
      Array.Copy((Array) this.MasterPassword, 0, (Array) numArray1, this.GlobalSalt.Length, this.MasterPassword.Length);
      byte[] buffer1 = numArray1;
      byte[] hash1 = cryptoServiceProvider.ComputeHash(buffer1);
      byte[] numArray2 = new byte[hash1.Length + this.EntrySalt.Length];
      Array.Copy((Array) hash1, 0, (Array) numArray2, 0, hash1.Length);
      Array.Copy((Array) this.EntrySalt, 0, (Array) numArray2, hash1.Length, this.EntrySalt.Length);
      byte[] buffer2 = numArray2;
      byte[] hash2 = cryptoServiceProvider.ComputeHash(buffer2);
      byte[] buffer3 = new byte[20];
      Array.Copy((Array) this.EntrySalt, 0, (Array) buffer3, 0, this.EntrySalt.Length);
      for (int length = this.EntrySalt.Length; length < 20; ++length)
        buffer3[length] = (byte) 0;
      byte[] buffer4 = new byte[buffer3.Length + this.EntrySalt.Length];
      Array.Copy((Array) buffer3, 0, (Array) buffer4, 0, buffer3.Length);
      Array.Copy((Array) this.EntrySalt, 0, (Array) buffer4, buffer3.Length, this.EntrySalt.Length);
      byte[] hash3;
      byte[] hash4;
      using (HMACSHA1 hmacshA1 = new HMACSHA1(hash2))
      {
        hash3 = hmacshA1.ComputeHash(buffer4);
        byte[] hash5 = hmacshA1.ComputeHash(buffer3);
        byte[] buffer5 = new byte[hash5.Length + this.EntrySalt.Length];
        Array.Copy((Array) hash5, 0, (Array) buffer5, 0, hash5.Length);
        Array.Copy((Array) this.EntrySalt, 0, (Array) buffer5, hash5.Length, this.EntrySalt.Length);
        hash4 = hmacshA1.ComputeHash(buffer5);
      }
      byte[] numArray3 = new byte[hash3.Length + hash4.Length];
      Array.Copy((Array) hash3, 0, (Array) numArray3, 0, hash3.Length);
      Array.Copy((Array) hash4, 0, (Array) numArray3, hash3.Length, hash4.Length);
      this.Key = new byte[24];
      for (int index = 0; index < this.Key.Length; ++index)
        this.Key[index] = numArray3[index];
      this.IV = new byte[8];
      int index1 = this.IV.Length - 1;
      for (int index2 = numArray3.Length - 1; index2 >= numArray3.Length - this.IV.Length; --index2)
      {
        this.IV[index1] = numArray3[index2];
        --index1;
      }
    }
  }
}
