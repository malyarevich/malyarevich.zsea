// Decompiled with JetBrains decompiler
// Type: АТП.Properties.Resources
// Assembly: АТП, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE68989E-AFC4-4363-A19F-6EAE01B73FF7
// Assembly location: C:\Users\FireNero\Desktop\Lab3.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace АТП.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (АТП.Properties.Resources.resourceMan == null)
          АТП.Properties.Resources.resourceMan = new ResourceManager("АТП.Properties.Resources", typeof (АТП.Properties.Resources).Assembly);
        return АТП.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return АТП.Properties.Resources.resourceCulture;
      }
      set
      {
        АТП.Properties.Resources.resourceCulture = value;
      }
    }

    internal Resources()
    {
    }
  }
}
