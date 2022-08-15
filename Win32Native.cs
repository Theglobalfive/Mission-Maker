// Decompiled with JetBrains decompiler
// Type: Win32Native
// Assembly: Mission Maker, Version=0.9.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 19887432-4F45-4CDD-B21E-635F7A53FBBD
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\Mission Maker.dll

using System;
using System.Runtime.InteropServices;

public static class Win32Native
{
  [DllImport("kernel32.dll")]
  public static extern IntPtr GetCurrentProcess();

  [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
  public static extern IntPtr GetModuleHandle(string lpModuleName);

  [DllImport("psapi.dll", SetLastError = true)]
  public static extern bool GetModuleInformation(
    IntPtr hProcess,
    IntPtr hModule,
    out Win32Native.MODULEINFO lpmodinfo,
    int cb);

  public struct MODULEINFO
  {
    public IntPtr lpBaseOfDll;
    public uint SizeOfImage;
    public IntPtr EntryPoint;
  }
}
