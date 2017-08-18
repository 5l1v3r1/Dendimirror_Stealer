// Decompiled with JetBrains decompiler
// Type: Decrypt.Asn1Der
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace Decrypt
{
  public class Asn1Der
  {
    public Asn1DerObject Parse(byte[] dataToParse)
    {
      Asn1DerObject asn1DerObject1 = new Asn1DerObject();
      for (int index = 0; index < dataToParse.Length; ++index)
      {
        int num1 = 0;
        switch ((Asn1Der.Type) dataToParse[index])
        {
          case Asn1Der.Type.Integer:
            List<Asn1DerObject> objects1 = asn1DerObject1.objects;
            Asn1DerObject asn1DerObject2 = new Asn1DerObject();
            asn1DerObject2.Type = Asn1Der.Type.Integer;
            int num2 = (int) dataToParse[index + 1];
            asn1DerObject2.Lenght = num2;
            objects1.Add(asn1DerObject2);
            byte[] numArray1 = new byte[(int) dataToParse[index + 1]];
            int length1 = index + 2 + (int) dataToParse[index + 1] > dataToParse.Length ? dataToParse.Length - (index + 2) : (int) dataToParse[index + 1];
            Array.Copy((Array) ((IEnumerable<byte>) dataToParse).ToArray<byte>(), index + 2, (Array) numArray1, 0, length1);
            asn1DerObject1.objects.Last<Asn1DerObject>().Data = numArray1;
            index = index + 1 + asn1DerObject1.objects.Last<Asn1DerObject>().Lenght;
            break;
          case Asn1Der.Type.OctetString:
            List<Asn1DerObject> objects2 = asn1DerObject1.objects;
            Asn1DerObject asn1DerObject3 = new Asn1DerObject();
            asn1DerObject3.Type = Asn1Der.Type.OctetString;
            int num3 = (int) dataToParse[index + 1];
            asn1DerObject3.Lenght = num3;
            objects2.Add(asn1DerObject3);
            byte[] numArray2 = new byte[(int) dataToParse[index + 1]];
            int length2 = index + 2 + (int) dataToParse[index + 1] > dataToParse.Length ? dataToParse.Length - (index + 2) : (int) dataToParse[index + 1];
            Array.Copy((Array) ((IEnumerable<byte>) dataToParse).ToArray<byte>(), index + 2, (Array) numArray2, 0, length2);
            asn1DerObject1.objects.Last<Asn1DerObject>().Data = numArray2;
            index = index + 1 + asn1DerObject1.objects.Last<Asn1DerObject>().Lenght;
            break;
          case Asn1Der.Type.ObjectIdentifier:
            List<Asn1DerObject> objects3 = asn1DerObject1.objects;
            Asn1DerObject asn1DerObject4 = new Asn1DerObject();
            asn1DerObject4.Type = Asn1Der.Type.ObjectIdentifier;
            int num4 = (int) dataToParse[index + 1];
            asn1DerObject4.Lenght = num4;
            objects3.Add(asn1DerObject4);
            byte[] numArray3 = new byte[(int) dataToParse[index + 1]];
            int length3 = index + 2 + (int) dataToParse[index + 1] > dataToParse.Length ? dataToParse.Length - (index + 2) : (int) dataToParse[index + 1];
            Array.Copy((Array) ((IEnumerable<byte>) dataToParse).ToArray<byte>(), index + 2, (Array) numArray3, 0, length3);
            asn1DerObject1.objects.Last<Asn1DerObject>().Data = numArray3;
            index = index + 1 + asn1DerObject1.objects.Last<Asn1DerObject>().Lenght;
            break;
          case Asn1Der.Type.Sequence:
            byte[] dataToParse1;
            if (asn1DerObject1.Lenght == 0)
            {
              asn1DerObject1.Type = Asn1Der.Type.Sequence;
              asn1DerObject1.Lenght = dataToParse.Length - (index + 2);
              dataToParse1 = new byte[asn1DerObject1.Lenght];
            }
            else
            {
              List<Asn1DerObject> objects4 = asn1DerObject1.objects;
              Asn1DerObject asn1DerObject5 = new Asn1DerObject();
              asn1DerObject5.Type = Asn1Der.Type.Sequence;
              int num5 = (int) dataToParse[index + 1];
              asn1DerObject5.Lenght = num5;
              objects4.Add(asn1DerObject5);
              dataToParse1 = new byte[(int) dataToParse[index + 1]];
            }
            num1 = dataToParse1.Length > dataToParse.Length - (index + 2) ? dataToParse.Length - (index + 2) : dataToParse1.Length;
            Array.Copy((Array) dataToParse, index + 2, (Array) dataToParse1, 0, dataToParse1.Length);
            asn1DerObject1.objects.Add(this.Parse(dataToParse1));
            index = index + 1 + (int) dataToParse[index + 1];
            break;
        }
      }
      return asn1DerObject1;
    }

    public enum Type
    {
      Integer = 2,
      BitString = 3,
      OctetString = 4,
      Null = 5,
      ObjectIdentifier = 6,
      Sequence = 48,
    }
  }
}
