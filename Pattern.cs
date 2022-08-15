// Decompiled with JetBrains decompiler
// Type: Pattern
// Assembly: Mission Maker, Version=0.9.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 19887432-4F45-4CDD-B21E-635F7A53FBBD
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\Mission Maker.dll

using System;

public sealed class Pattern
{
  private string bytes;
  private string mask;

  public Pattern(string bytes, string mask)
  {
    this.bytes = bytes;
    this.mask = mask;
  }

  public unsafe IntPtr Get(string moduleName, int offset)
  {
    Win32Native.MODULEINFO lpmodinfo;
    Win32Native.GetModuleInformation(Win32Native.GetCurrentProcess(), Win32Native.GetModuleHandle(moduleName), out lpmodinfo, sizeof (Win32Native.MODULEINFO));
    long int64 = lpmodinfo.lpBaseOfDll.ToInt64();
    for (long index = int64 + (long) lpmodinfo.SizeOfImage; int64 < index; ++int64)
    {
      if (this.bCompare((byte*) int64, this.bytes.ToCharArray(), this.mask.ToCharArray()))
        return new IntPtr(int64 + (long) offset);
    }
    return IntPtr.Zero;
  }

  public IntPtr Get(int offset = 0) => this.Get((string) null, offset);

  private unsafe bool bCompare(byte* pData, char[] bMask, char[] szMask)
  {
    for (int index = 0; index < bMask.Length; ++index)
    {
      if (szMask[index] == 'x' && (int) pData[index] != (int) bMask[index])
        return false;
    }
    return true;
  }
}
