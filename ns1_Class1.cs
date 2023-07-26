using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class ns1_Class1
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager resourceManager = (resourceMan = new ResourceManager("ns1.Class1", typeof(ns1_Class1).Assembly));
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap iphone6
	{
		get
		{
			object @object = ResourceManager.GetObject("iphone6", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap iphone7_8
	{
		get
		{
			object @object = ResourceManager.GetObject("iphone7/8", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap iphoneX
	{
		get
		{
			object @object = ResourceManager.GetObject("iphoneX", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static byte[] resx
	{
		get
		{
			object @object = ResourceManager.GetObject("resx", resourceCulture);
			return (byte[])@object;
		}
	}

	internal ns1_Class1()
	{
	}
}
