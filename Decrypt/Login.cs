// Decompiled with JetBrains decompiler
// Type: Decrypt.Login
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

namespace Decrypt
{
  public class Login
  {
    public int id { get; set; }

    public string hostname { get; set; }

    public object httpRealm { get; set; }

    public string formSubmitURL { get; set; }

    public string usernameField { get; set; }

    public string passwordField { get; set; }

    public string encryptedUsername { get; set; }

    public string encryptedPassword { get; set; }

    public string guid { get; set; }

    public int encType { get; set; }

    public long timeCreated { get; set; }

    public long timeLastUsed { get; set; }

    public long timePasswordChanged { get; set; }

    public int timesUsed { get; set; }
  }
}
