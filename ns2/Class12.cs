using System;
using System.Windows.Forms;

namespace ns2;

internal static class Class12
{
	[STAThread]
	private static void Main(string[] args)
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new Form1());
	}
}
