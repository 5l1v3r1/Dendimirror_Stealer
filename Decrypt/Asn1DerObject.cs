// Decompiled with JetBrains decompiler
// Type: Decrypt.Asn1DerObject
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System.Collections.Generic;
using System.Text;

namespace Decrypt
{
  public class Asn1DerObject
  {
    public Asn1Der.Type Type { get; set; }

    public int Lenght { get; set; }

    public List<Asn1DerObject> objects { get; set; }

    public byte[] Data { get; set; }

    public Asn1DerObject()
    {
      this.objects = new List<Asn1DerObject>();
    }

    public override string ToString()
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      switch (this.Type)
      {
        case Asn1Der.Type.Integer:
          foreach (byte num in this.Data)
            stringBuilder2.AppendFormat("{0:X2}", (object) num);
          stringBuilder1.AppendLine("\tINTEGER " + (object) stringBuilder2);
          stringBuilder2.Clear();
          break;
        case Asn1Der.Type.OctetString:
          foreach (byte num in this.Data)
            stringBuilder2.AppendFormat("{0:X2}", (object) num);
          stringBuilder1.AppendLine("\tOCTETSTRING " + stringBuilder2.ToString());
          stringBuilder2.Clear();
          break;
        case Asn1Der.Type.ObjectIdentifier:
          foreach (byte num in this.Data)
            stringBuilder2.AppendFormat("{0:X2}", (object) num);
          stringBuilder1.AppendLine("\tOBJECTIDENTIFIER " + stringBuilder2.ToString());
          stringBuilder2.Clear();
          break;
        case Asn1Der.Type.Sequence:
          stringBuilder1.AppendLine("SEQUENCE {");
          break;
      }
      foreach (Asn1DerObject asn1DerObject in this.objects)
        stringBuilder1.Append(asn1DerObject.ToString());
      if (this.Type.Equals((object) Asn1Der.Type.Sequence))
        stringBuilder1.AppendLine("}");
      return stringBuilder1.ToString();
    }
  }
}
