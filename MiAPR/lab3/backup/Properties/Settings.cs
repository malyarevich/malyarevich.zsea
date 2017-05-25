// Decompiled with JetBrains decompiler
// Type: АТП.Properties.Settings
// Assembly: АТП, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE68989E-AFC4-4363-A19F-6EAE01B73FF7
// Assembly location: C:\Users\FireNero\Desktop\Lab3.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace АТП.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings settings = Settings.defaultInstance;
        return settings;
      }
    }
  }
}
