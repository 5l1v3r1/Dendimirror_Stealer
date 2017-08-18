// Decompiled with JetBrains decompiler
// Type: Decrypt.Helpers
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System.IO;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Decrypt
{
  public static class Helpers
  {
    private static JavaScriptSerializer json;

    private static JavaScriptSerializer JSON
    {
      get
      {
        return Helpers.json ?? (Helpers.json = new JavaScriptSerializer());
      }
    }

    private static Stream ToStream(this string @this)
    {
      MemoryStream memoryStream = new MemoryStream();
      StreamWriter streamWriter = new StreamWriter((Stream) memoryStream);
      string str = @this;
      streamWriter.Write(str);
      streamWriter.Flush();
      long num = 0;
      memoryStream.Position = num;
      return (Stream) memoryStream;
    }

    public static T ParseXML<T>(this string @this) where T : class
    {
      return new XmlSerializer(typeof (T)).Deserialize(XmlReader.Create(@this.Trim().ToStream(), new XmlReaderSettings()
      {
        ConformanceLevel = ConformanceLevel.Document
      })) as T;
    }

    public static T ParseJSON<T>(this string @this) where T : class
    {
      return Helpers.JSON.Deserialize<T>(@this.Trim());
    }
  }
}
