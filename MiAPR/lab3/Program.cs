// Decompiled with JetBrains decompiler
// Type: АТП.Program
// Assembly: АТП, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE68989E-AFC4-4363-A19F-6EAE01B73FF7
// Assembly location: C:\Users\FireNero\Desktop\Lab3.exe

using System;
using System.Windows.Forms;

namespace АТП
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
