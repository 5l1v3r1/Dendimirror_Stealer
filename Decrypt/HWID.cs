// Decompiled with JetBrains decompiler
// Type: Decrypt.HWID
// Assembly: Decrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2765FEAE-7833-475D-8D48-4374EDF0542D
// Assembly location: C:\Users\foxov\Desktop\build\bin\Debug\Decrypt.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Decrypt
{
  public class HWID
  {
    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern bool GetCurrentHwProfile(IntPtr lpHwProfileInfo);

    [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern long GetVolumeInformationA(string PathName, StringBuilder VolumeNameBuffer, int VolumeNameSize, ref int VolumeSerialNumber, ref int MaximumComponentLength, ref int FileSystemFlags, StringBuilder FileSystemNameBuffer, int FileSystemNameSize);

    private static HWID.HW_PROFILE_INFO ProfileInfo()
    {
      IntPtr num = IntPtr.Zero;
      try
      {
        HWID.HW_PROFILE_INFO hwProfileInfo = new HWID.HW_PROFILE_INFO();
        num = Marshal.AllocHGlobal(Marshal.SizeOf((object) hwProfileInfo));
        Marshal.StructureToPtr((object) hwProfileInfo, num, false);
        if (!HWID.GetCurrentHwProfile(num))
          throw new Exception("Error cant get current hw profile!");
        Marshal.PtrToStructure(num, (object) hwProfileInfo);
        return hwProfileInfo;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.ToString());
      }
      finally
      {
        if (num != IntPtr.Zero)
          Marshal.FreeHGlobal(num);
      }
    }

    private static string GetVolumeSerial(string strDriveLetter)
    {
      int VolumeSerialNumber = 0;
      int MaximumComponentLength = 0;
      int FileSystemFlags = 0;
      StringBuilder VolumeNameBuffer = new StringBuilder(256);
      StringBuilder FileSystemNameBuffer = new StringBuilder(256);
      HWID.GetVolumeInformationA(strDriveLetter + ":\\", VolumeNameBuffer, VolumeNameBuffer.Capacity, ref VolumeSerialNumber, ref MaximumComponentLength, ref FileSystemFlags, FileSystemNameBuffer, FileSystemNameBuffer.Capacity);
      return Convert.ToString(VolumeSerialNumber);
    }

    private static string MD5(string str)
    {
      byte[] buffer = Encoding.UTF8.GetBytes(str);
      using (MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider())
        buffer = cryptoServiceProvider.ComputeHash(buffer);
      return BitConverter.ToString(buffer).Replace("-", string.Empty).ToUpper();
    }

    public static string Generate()
    {
      return HWID.MD5(HWID.ProfileInfo().szHwProfileGuid.ToString() + HWID.GetVolumeSerial(Environment.SystemDirectory.Substring(0, 1)));
    }

    [Flags]
    private enum DockInfo
    {
      DOCKINFO_DOCKED = 2,
      DOCKINFO_UNDOCKED = 1,
      DOCKINFO_USER_SUPPLIED = 4,
      DOCKINFO_USER_DOCKED = DOCKINFO_USER_SUPPLIED | DOCKINFO_UNDOCKED,
      DOCKINFO_USER_UNDOCKED = DOCKINFO_USER_SUPPLIED | DOCKINFO_DOCKED,
    }

    [StructLayout(LayoutKind.Sequential)]
    private class HW_PROFILE_INFO
    {
      [MarshalAs(UnmanagedType.U4)]
      public int dwDockInfo;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 39)]
      public string szHwProfileGuid;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
      public string szHwProfileName;
    }
  }
}
