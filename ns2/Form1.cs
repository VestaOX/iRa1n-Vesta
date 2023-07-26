using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using iMobileDevice;
using LibMobileDevice;
using LibMobileDevice.Enumerates;
using LibMobileDevice.Event;
using ns1;

namespace ns2;

public class Form1 : Form
{
	public const int WM_NCLBUTTONDOWN = 161;

	public const int HT_CAPTION = 2;

	private const string string_0 = "3.2";

	internal static iOSDeviceManager iOSDeviceManager_0;

	internal static iOSDevice iOSDevice_0;

	private static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>
	{
		{ "iPhone7,1", "iPhone 6 Plus" },
		{ "iPhone7,2", "iPhone 6" },
		{ "iPhone8,1", "iPhone 6s" },
		{ "iPhone8,2", "iPhone 6s Plus" },
		{ "iPhone8,4", "iPhone SE (1st gen)" },
		{ "iPhone9,1", "iPhone 7 (Global)" },
		{ "iPhone9,2", "iPhone 7 Plus (Global)" },
		{ "iPhone9,3", "iPhone 7 (GSM)" },
		{ "iPhone9,4", "iPhone 7 Plus (GSM)" },
		{ "iPhone10,1", "iPhone 8 (Global)" },
		{ "iPhone10,2", "iPhone 8 Plus (Global)" },
		{ "iPhone10,3", "iPhone X (Global)" },
		{ "iPhone10,4", "iPhone 8 (GSM)" },
		{ "iPhone10,5", "iPhone 8 Plus (GSM)" },
		{ "iPhone10,6", "iPhone X (GSM)" },
		{ "iPod9,1", "iPod Touch (7th gen)" },
		{ "iPad5,1", "iPad mini 4 (WiFi)" },
		{ "iPad5,2", "iPad mini 4 (Cellular)" },
		{ "iPad5,3", "iPad Air 2 (WiFi)" },
		{ "iPad5,4", "iPad Air 2 (Cellular)" },
		{ "iPad6,3", "iPad Pro 9.7-inch (WiFi)" },
		{ "iPad6,4", "iPad Pro 9.7-inch (Cellular)" },
		{ "iPad6,7", "iPad Pro 12.9-inch (1st gen, WiFi)" },
		{ "iPad6,8", "iPad Pro 12.9-inch (1st gen, Cellular)" },
		{ "iPad6,11", "iPad (5th gen, WiFi)" },
		{ "iPad6,12", "iPad (5th gen, Cellular)" },
		{ "iPad7,1", "iPad Pro 12.9-inch (2nd gen, WiFi)" },
		{ "iPad7,2", "iPad Pro 12.9-inch (2nd gen, Cellular)" },
		{ "iPad7,3", "iPad Pro 10.5-inch (WiFi)" },
		{ "iPad7,4", "iPad Pro 10.5-inch (Cellular)" },
		{ "iPad7,5", "iPad (6th gen, WiFi)" },
		{ "iPad7,6", "iPad (6th gen, Cellular)" },
		{ "iPad7,11", "iPad (7th gen, WiFi)" },
		{ "iPad7,12", "iPad (7th gen, Cellular)" }
	};

	private static Dictionary<string, string> dictionary_1 = new Dictionary<string, string>
	{
		{ "iBridge2,1", "Apple T2 iMacPro1,1 (j137)" },
		{ "iBridge2,3", "Apple T2 MacBookPro15,1 (j680)" },
		{ "iBridge2,4", "Apple T2 MacBookPro15,2 (j132)" },
		{ "iBridge2,5", "Apple T2 Macmini8,1 (j174)" },
		{ "iBridge2,6", "Apple T2 MacPro7,1 (j160)" },
		{ "iBridge2,7", "Apple T2 MacBookPro15,3 (j780)" },
		{ "iBridge2,8", "Apple T2 MacBookAir8,1 (j140k)" },
		{ "iBridge2,10", "Apple T2 MacBookPro15,4 (j213)" },
		{ "iBridge2,12", "Apple T2 MacBookAir8,2 (j140a)" },
		{ "iBridge2,14", "Apple T2 MacBookPro16,1 (j152f)" },
		{ "iBridge2,15", "Apple T2 MacBookAir9,1 (j230k)" },
		{ "iBridge2,16", "Apple T2 MacBookPro16,2 (j214k)" },
		{ "iBridge2,19", "Apple T2 iMac20,1 (j185)" },
		{ "iBridge2,20", "Apple T2 iMac20,2 (j185f)" },
		{ "iBridge2,21", "Apple T2 MacBookPro16,3 (j223)" },
		{ "iBridge2,22", "Apple T2 MacBookPro16,4 (j215)" }
	};

	private static Thread thread_0;

	private static bool bool_0 = true;

	internal static string string_1 = Class7.smethod_10();

	private BackgroundWorker backgroundWorker_0;

	private static bool bool_1 = false;

	private static string string_2 = "";

	private static bool bool_2;

	private static bool bool_3 = false;

	private static bool bool_4 = false;

	[CompilerGenerated]
	private Task task_0;

	private static bool bool_5;

	private static bool bool_6;

	private static bool bool_7;

	private static string string_3;

	private IContainer icontainer_0;

	private Label label1;

	private Label label2;

	private Label label3;

	private Label label4;

	private Label label5;

	private Label label6;

	private Label label7;

	private Label label8;

	private Label label9;

	private Label label10;

	private Button button1;

	private Button buttonRestore;

	private Button button2;

	private Label label12;

	private Label label13;

	private Panel panel1;

	private Button button3;

	private Label label14;

	private Label label11;

	private CheckBox checkBox3;

	private CheckBox checkBox2;

	private CheckBox checkBox1;

	private CheckBox checkBox5;

	private CheckBox checkBox4;

	private Panel recoveryPanel;

	private Label label18;

	private Label label17;

	private Label label16;

	private Label label15;

	private Button NextButt;

	private Button button4;

	private Label label19;

	private Label ecidLabel;

	private Label warnLabel;

	private Panel dfuPanel;

	private Label pressDFU;

	private Label startDFU;

	private Button button5;

	private Button button6;

	private Label label23;

	private Label label24;

	private Label label20;

	private Label label21;

	private Button button7;

	private Panel checkrainPanel;

	private ProgressBar progressBar1;

	private Button button8;

	private Label label28;

	private Label label29;

	private Label label22;

	private Label label25;

	private TextBox textBox1;

	private Label label27;

	private PictureBox devicePicture;

	private Label sideButtonXLab;

	private Label volumeDown78XLab;

	private Label sideButton678Lab;

	private Label homeButtLab;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private IContainer components;

	private Guna2GradientPanel guna2GradientPanel1;

	private Guna2Separator guna2Separator1;

	private Label label31;

	private Label label30;

	private Guna2CirclePictureBox guna2CirclePictureBox1;

	private Guna2Separator guna2Separator2;

	private string temp = Path.GetTempPath() + "\\";

	private static BackgroundWorker BackgroundWorker_dump;
    private Guna2CirclePictureBox guna2CirclePictureBox2;
    private Guna2CirclePictureBox guna2CirclePictureBox3;
    public static string iOSPublic = "";

	public Task Task_0
	{
		[CompilerGenerated]
		get
		{
			return task_0;
		}
		[CompilerGenerated]
		private set
		{
			task_0 = value;
		}
	}

	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	[DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool IsWow64Process(IntPtr hProcess, out bool Wow64Process);

	[DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool Wow64DisableWow64FsRedirection(out IntPtr OldValue);

	public Form1()
	{
		InitializeComponent();
		base.Load += Form1_Load;
		BackgroundWorker_dump = new BackgroundWorker();
		BackgroundWorker_dump.DoWork += BackgroundWorker_dump_DoWork;
		BackgroundWorker_dump.RunWorkerAsync();
		Processkill("openra1n.exe");
		Processkill("Checkra1n.exe");
		Processkill("pongoterm.exe");
        this.FormBorderStyle = FormBorderStyle.None;
        (new Core.DropShadow()).ApplyShadows(this);
    }

	private static void BackgroundWorker_dump_DoWork(object sender, DoWorkEventArgs e)
	{
		while (true)
		{
			AntiDebuggers antiDebuggers = new AntiDebuggers();
			antiDebuggers.CheckForDebuggers();
		}
	}

	public void Processkill(string ProcessName)
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			Process[] array = processes;
			foreach (Process process in array)
			{
				if (process.ProcessName.ToLower().Contains(ProcessName))
				{
					process.Kill();
				}
			}
		}
		catch
		{
		}
	}

	public static bool smethod_0()
	{
		return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
	}

	internal static string smethod_1(byte[] rawData)
	{
		using SHA256 sHA = SHA256.Create();
		byte[] array = sHA.ComputeHash(rawData);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public void method_0(string fileName)
	{
		Process process = new Process();
		process.StartInfo.FileName = fileName;
		process.StartInfo.UseShellExecute = true;
		process.StartInfo.Verb = "runas";
		process.Start();
	}

	private void method_1(object sender, FormClosingEventArgs e)
	{
		if (thread_0 != null)
		{
			thread_0.Abort();
			thread_0 = null;
		}
		bool_0 = false;
	}

	private bool method_2(object fdfdfd, object gdgdfdf, object gdgdfd, SslPolicyErrors letsgo)
	{
		X509Certificate2 x509Certificate = new X509Certificate2((X509Certificate)gdgdfdf);
		return x509Certificate.Verify() & "CN=s13.iremovalpro.com".Equals(x509Certificate.Subject);
	}

	private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			string text = string_1;
			if (!text.Contains("Windows 7") && !text.Contains("Windows 8") && !text.Contains("Windows 10") && !text.Contains("Windows 11"))
			{
				MessageBox.Show("Only Windows 7/8/10/11 32/64 bits are supported currently!");
			}
			if (!smethod_0())
			{
				method_0(AppDomain.CurrentDomain.FriendlyName);
			}
			try
			{
				_ = smethod_1(File.ReadAllBytes("libimobiledevice-glue-1.0.dll")) != "b18daf063ba27150ed08c027b35be5a9c1ba74ce6de310d401f28e0ca61a020b";
				_ = smethod_1(File.ReadAllBytes("LZ4.dll")) != "be632f8631dbf02387e4a54ece212fef2d91ec8d0dc1e0c24859a7d36025d2fd";
				_ = smethod_1(File.ReadAllBytes("iMobileDevice-net.dll")) != "f3bcf42b55a8f6ea12c7591abc4b4dc0d5060ae6060bfcd817d50343bc395414";
			}
			catch (Exception)
			{
			}
			if (!Class7.smethod_4().Contains("AppleMobileDevice"))
			{
				MessageBox.Show("Detected missing driver!\n\niRa1n app require AppleMobileDevice to work correctly.\nPlease install iTunes to get it working!");
			}
			List<Class7.Class9> list = Class7.smethod_6();
			bool flag = false;
			List<Class7.Class9>.Enumerator enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Class7.Class9 current = enumerator.Current;
				if (current.String_4.Contains("05/19/2017 6.0.9999.69"))
				{
					flag = true;
				}
				current.String_4.Contains("05/07/2018 423.36.0.0");
				current.String_2.Contains("libusbK");
				if (current.String_1.Contains("wpdmtp"))
				{
					Class7.smethod_12(current.String_0);
				}
			}
			if (!flag)
			{
				Class7.smethod_8();
			}
			Class7.smethod_11();
		}
		catch (Exception)
		{
		}
	}

	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		try
		{
			NativeLibraries.Load(Environment.CurrentDirectory + "\\bin\\libimobiledevice");
			if (iOSDeviceManager_0 == null)
			{
				iOSDeviceManager_0 = new iOSDeviceManager();
				iOSDeviceManager_0.CommonConnectEvent += method_3;
				iOSDeviceManager_0.RecoveryConnectEvent += method_5;
				iOSDeviceManager_0.DfuConnectEvent += method_4;
				iOSDeviceManager_0.ListenErrorEvent += method_6;
				Thread thread = new Thread(iOSDeviceManager_0.StartListen);
				thread.IsBackground = true;
				thread.Start();
			}
		}
		catch (Exception)
		{
			MessageBox.Show("error");
		}
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		try
		{
			CenterToScreen();
			base.MaximizeBox = false;
			backgroundWorker_0 = new BackgroundWorker();
			backgroundWorker_0.RunWorkerCompleted += backgroundWorker_0_RunWorkerCompleted;
			backgroundWorker_0.RunWorkerAsync();
		}
		catch (Exception)
		{
		}
	}

	private void method_3(object sender, DeviceCommonConnectEventArgs e)
	{
		if (e.Message == ConnectNotificationMessage.Connected)
		{
			iOSDevice_0 = e.Device;
			if (!iOSDevice_0.IsConnected)
			{
				Invoke((MethodInvoker)delegate
				{
					label2.Text = "Failed to connect to lockdownd (-21)";
				});
			}
			string deviceName = "";
			if (iOSDevice_0 != null && iOSDevice_0.IsConnected)
			{
				Dictionary<string, string>.Enumerator enumerator = dictionary_0.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> current = enumerator.Current;
					if (current.Key == iOSDevice_0.ProductType)
					{
						deviceName = current.Value;
						break;
					}
				}
				if (iOSDevice_0.ProductVersion.Contains("15.5") || iOSDevice_0.ProductVersion.Contains("15.6") || iOSDevice_0.ProductVersion.Contains("15.7") || iOSDevice_0.ProductVersion.Contains("15.8") || ((iOSDevice_0.ProductVersion.Contains("16.4") || iOSDevice_0.ProductVersion.Contains("16.5")) && iOSDevice_0.ProductType.Contains("iPhone")))
				{
					try
					{
						string productVersion = iOSDevice_0.ProductVersion;
						if (productVersion.StartsWith("12."))
						{
							iOSPublic = "12.x";
						}
						else if (productVersion.StartsWith("13."))
						{
							iOSPublic = "13.x";
						}
						else if (productVersion.StartsWith("14."))
						{
							iOSPublic = "14.x";
						}
						else if (productVersion.StartsWith("15."))
						{
							iOSPublic = "15.x";
						}
						else
						{
							iOSPublic = "16.4x";
						}
						bool_1 = true;
						string s = iOSDevice_0.GetDeviceValue(null, "UniqueChipID").ToString();
						Thread.Sleep(2500);
						Class13.string_4 = Class3.smethod_9(iOSDevice_0.UniqueDeviceID);
						Class13.string_0 = s;
						Class13.string_3 = iOSDevice_0.ProductType;
						Class13.string_6 = iOSDevice_0.InternationalMobileEquipmentIdentity;
						Class13.string_7 = iOSDevice_0.GetDeviceValue(null, "MobileEquipmentIdentifier").ToString();
						string_2 = long.Parse(s).ToString("x");
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message + ex.StackTrace);
					}
				}
				Class13.string_2 = iOSDevice_0.ProductVersion;
				Invoke((MethodInvoker)delegate
				{
					if (string.IsNullOrEmpty(deviceName))
					{
						label2.Name = "Unsupported device";
						button2.Enabled = false;
					}
					else if (!iOSDevice_0.ProductVersion.Contains("12.") && !iOSDevice_0.ProductVersion.Contains("13.") && !iOSDevice_0.ProductVersion.Contains("14.") && (iOSDevice_0.ProductVersion.Contains("15.5") || iOSDevice_0.ProductVersion.Contains("15.6") || iOSDevice_0.ProductVersion.Contains("15.7") || iOSDevice_0.ProductVersion.Contains("15.8") || ((iOSDevice_0.ProductVersion.Contains("16.4") || iOSDevice_0.ProductVersion.Contains("16.5")) && iOSDevice_0.ProductType.Contains("iPhone10"))) && string.IsNullOrEmpty(Class13.string_4))
					{
						label2.Text = deviceName + " (" + iOSDevice_0.ProductVersion + ") is not supported at this point. Only iOS 12.0\nto iOS 14.8.1 are supported! (and iOS 15.5/15.6 exclusively)";
						button2.Enabled = false;
					}
					else if (!iOSDevice_0.ProductVersion.Contains("16.4") && !iOSDevice_0.ProductVersion.Contains("16.5") && iOSDevice_0.ProductType.Contains("iPhone10"))
					{
						label2.Text = deviceName + " (" + iOSDevice_0.ProductVersion + ") is not supported.. update it to latest iOS 16.x version!";
						button2.Enabled = false;
					}
					else
					{
						label2.Text = deviceName + " (" + iOSDevice_0.ProductVersion + ") connected in Normal mode";
						button2.Enabled = true;
					}
				});
			}
		}
		if (e.Message == ConnectNotificationMessage.Disconnected)
		{
			Invoke((MethodInvoker)delegate
			{
				label2.Text = "Connect your iPhone, iPod touch, iPad, or AppleTV to begin";
				button2.Enabled = false;
			});
		}
	}

	public static string smethod_2(string arg, string key, bool ret = true, bool dfu = false)
	{
		Process process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = Environment.CurrentDirectory + "\\bin\\irecovery.exe",
				Arguments = arg,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true
			}
		};
		process.Start();
		if (!ret)
		{
			return "";
		}
		if (dfu)
		{
			if (process.WaitForExit(500) && process.StandardOutput.ReadToEnd().Contains(key))
			{
				return key;
			}
		}
		else
		{
			string text;
			while ((text = process.StandardOutput.ReadLine()) != null)
			{
				if (text.Contains(key))
				{
					return text;
				}
			}
		}
		return "";
	}

	public static string smethod_2_1(string arg, string key, bool ret = true, bool dfu = false)
	{
		Process process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = Environment.CurrentDirectory + "\\bin\\irecover.exe",
				Arguments = arg,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true
			}
		};
		process.Start();
		if (!ret)
		{
			return "";
		}
		if (dfu)
		{
			if (process.WaitForExit(500) && process.StandardOutput.ReadToEnd().Contains(key))
			{
				return key;
			}
		}
		else
		{
			string text;
			while ((text = process.StandardOutput.ReadLine()) != null)
			{
				if (text.Contains(key))
				{
					return text;
				}
			}
		}
		return "";
	}

	private async void method_4(object sender, DeviceDfuConnectEventArgs e)
	{
		if (e.Message == ConnectNotificationMessage.Connected)
		{
			string text = smethod_2("-q", "PRODUCT").Replace("PRODUCT: ", "");
			string text2 = smethod_2("-q", "CPID").Replace("CPID: ", "");
			string text3 = smethod_2("-q", "MODEL").Replace("MODEL: ", "");
			string text4 = smethod_2("-q", "ECID").Replace("ECID: ", "");
			string name = "";
			foreach (KeyValuePair<string, string> item in dictionary_1)
			{
				if (item.Key == text)
				{
					name = item.Value;
					break;
				}
			}
			if (!string.IsNullOrEmpty(name))
			{
				Class13.string_5 = text2.Replace("0x", "");
				Class13.string_3 = text3;
				Class13.string_0 = long.Parse(text4.Replace("0x", ""), NumberStyles.HexNumber).ToString();
				Class13.string_1 = text4.Replace("0x", "");
				Invoke((MethodInvoker)delegate
				{
					label2.Text = name + " connected in DFU mode";
					button2.Enabled = true;
				});
				bool_4 = true;
			}
		}
		if (e.Message == ConnectNotificationMessage.Disconnected)
		{
			Invoke((MethodInvoker)delegate
			{
				label2.Text = "Connect your iPhone, iPod touch, iPad, or MacBook to begin";
				button2.Enabled = false;
			});
			bool_4 = false;
		}
	}

	private async void method_5(object sender, DeviceRecoveryConnectEventArgs e)
	{
		if (e.Message == ConnectNotificationMessage.Connected)
		{
			string ecid = smethod_2("-q", "ECID").Replace("ECID: ", "").Replace("0x00", "");
			string text = smethod_2("-q", "PRODUCT").Replace("PRODUCT: ", "");
			string text2 = smethod_2("-q", "CPID").Replace("CPID: ", "");
			string text3 = smethod_2_1("-q", "iBoot").Replace("iBoot: ", "");
			Console.WriteLine(text3);
			if (text3.StartsWith("iBoot-4513"))
			{
				iOSPublic = "12.x";
			}
			else if (text3.StartsWith("iBoot-5540"))
			{
				iOSPublic = "13.x";
			}
			else if (text3.StartsWith("iBoot-6723") || text3.StartsWith("iBoot-6603") || text3.StartsWith("iBoot-6631") || text3.StartsWith("iBoot-6671"))
			{
				iOSPublic = "14.x";
			}
			else if (text3.StartsWith("iBoot-7429") || text3.StartsWith("iBoot-7459"))
			{
				iOSPublic = "15.x";
			}
			else if (text3.StartsWith("iBoot-8419"))
			{
				iOSPublic = "16.x";
			}
			else if (text3.StartsWith("iBoot-8422"))
			{
				iOSPublic = "16.4x";
			}
			else
			{
				iOSPublic = "16.4x";
			}
			string name = "";
			if (!ecid.Contains(string_2) && bool_1)
			{
				bool_1 = false;
				string_2 = "";
			}
			else
			{
				Class13.string_5 = text2.Replace("0x", "");
			}
			Console.WriteLine("here");
			foreach (KeyValuePair<string, string> item in dictionary_0)
			{
				if (item.Key == text)
				{
					name = item.Value;
					break;
				}
			}
			Invoke((MethodInvoker)delegate
			{
				if (!name.Contains("iPhone 6") && !name.Contains("iPhone 5s") && !name.Contains("iPhone SE") && !name.Contains("iPad"))
				{
					if (!name.Contains("iPhone 7") && !name.Contains("iPhone 8"))
					{
						if (name.Contains("iPhone X"))
						{
							volumeDown78XLab.Visible = true;
							sideButtonXLab.Visible = true;
							devicePicture.Image = Class1.Bitmap_2;
							devicePicture.Visible = true;
							string_3 = "Volume down";
						}
						else
						{
							string_3 = "Volume down";
						}
					}
					else
					{
						volumeDown78XLab.Visible = true;
						sideButton678Lab.Visible = true;
						devicePicture.Image = Class1.Bitmap_1;
						devicePicture.Visible = true;
						string_3 = "Volume down";
					}
				}
				else
				{
					homeButtLab.Visible = true;
					sideButton678Lab.Visible = true;
					devicePicture.Image = Class1.Bitmap_0;
					devicePicture.Visible = true;
					string_3 = "Home";
				}
				if (string.IsNullOrEmpty(name))
				{
					label2.Name = "Unsupported device";
					button2.Enabled = false;
					Application.DoEvents();
				}
				else
				{
					label2.Text = name + " (" + iOSPublic + "x) connected in Recovery mode";
					ecidLabel.Text = "ECID: " + ecid;
					warnLabel.Text = "WARNING: Reboot to normal mode to proceed jailbreak!";
					ecidLabel.Visible = true;
					warnLabel.Visible = true;
					bool_2 = true;
					pressDFU.Text = "2. Press and hold the Side \nand " + string_3 + " buttons \ntogether (4)";
					label20.Text = "3. Release the Side button \nBUT KEEP HOLDING the \n" + string_3 + " button (10)";
					if (bool_6)
					{
						bool_6 = false;
						label19.Text = "Device is now in recovery mode.";
						Application.DoEvents();
						Thread.Sleep(1500);
						button6.Enabled = true;
						dfuPanel.Visible = true;
						recoveryPanel.Visible = false;
						label19.Visible = false;
					}
					button2.Enabled = true;
					button4.Enabled = true;
				}
			});
		}
		if (e.Message != ConnectNotificationMessage.Disconnected)
		{
			return;
		}
		Invoke((MethodInvoker)delegate
		{
			label2.Text = "Connect your iPhone, iPod touch, iPad, or AppleTV to begin";
			button2.Enabled = false;
			NextButt.Enabled = true;
			ecidLabel.Visible = false;
			warnLabel.Visible = false;
			if (!dfuPanel.Visible)
			{
				volumeDown78XLab.Visible = false;
				sideButton678Lab.Visible = false;
				sideButtonXLab.Visible = false;
				homeButtLab.Visible = false;
				devicePicture.Visible = false;
			}
		});
		bool_2 = false;
	}

	private void method_6(object sender, ListenErrorEventHandlerEventArgs e)
	{
		if (e.ErrorType == ListenErrorEventType.StartListen)
		{
			MessageBox.Show(e.ErrorMessage);
		}
	}

	private async void button2_Click(object sender, EventArgs e)
	{
		if (bool_4)
		{
			checkrainPanel.Visible = true;
			Application.DoEvents();
			method_9(0, "Preparing device..");
			await Task.Delay(500);
			await method_8();
			await Task.Delay(2000);
			Task.Factory.StartNew(() => new Class4().method_7(this));
		}
		else if (bool_2)
		{
			dfuPanel.Visible = true;
		}
		else
		{
			recoveryPanel.Visible = true;
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		panel1.Visible = true;
	}

	private async void buttonRestore_Click(object sender, EventArgs e)
	{
		if (bool_4)
		{
			checkrainPanel.Visible = true;
			Application.DoEvents();
			method_9(0, "Preparing device..");
			await Task.Delay(500);
			await method_8(t2: true);
			await Task.Delay(2000);
			Task.Factory.StartNew(() => new Class4().method_8(this));
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		panel1.Visible = false;
	}

	private void button4_Click(object sender, EventArgs e)
	{
		recoveryPanel.Visible = false;
	}

	private async Task method_7()
	{
		while (bool_6)
		{
			label19.Visible = true;
			label19.Text = "Entering recovery mode |........";
			await Task.Delay(100);
			if (bool_6)
			{
				label19.Text = "Entering recovery mode .|.......";
				await Task.Delay(100);
				if (bool_6)
				{
					label19.Text = "Entering recovery mode ..|......";
					await Task.Delay(100);
					if (bool_6)
					{
						label19.Text = "Entering recovery mode ...|.....";
						await Task.Delay(100);
						if (bool_6)
						{
							label19.Text = "Entering recovery mode ....|....";
							await Task.Delay(100);
							if (bool_6)
							{
								label19.Text = "Entering recovery mode .....|...";
								await Task.Delay(100);
								if (bool_6)
								{
									label19.Text = "Entering recovery mode ......|..";
									await Task.Delay(100);
									if (bool_6)
									{
										label19.Text = "Entering recovery mode .......|.";
										await Task.Delay(100);
										if (bool_6)
										{
											label19.Text = "Entering recovery mode ........|";
											continue;
										}
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				break;
			}
			break;
		}
	}

	private async Task method_8(bool t2 = false)
	{
		foreach (Class7.Class9 item in Class7.smethod_6())
		{
			if (item.String_2 == "libusbK")
			{
				Class7.smethod_12(item.String_0);
			}
			if (item.String_2 == "libusb-win32")
			{
				Class7.smethod_12(item.String_0);
			}
			if (item.String_2 == "libwdi")
			{
				Class7.smethod_12(item.String_0);
			}
			if (item.String_4.Contains("05/19/2017 6.0.9999.69"))
			{
				Class7.smethod_12(item.String_0);
			}
			if (item.String_4.Contains("05/07/2018 423.36.0.0"))
			{
				Class7.smethod_12(item.String_0);
			}
			if (item.String_4.Contains("10/02/2020 486.0.0.0"))
			{
				Class7.smethod_12(item.String_0);
			}
			if (item.String_1.Contains("appleusb"))
			{
				Class7.smethod_12(item.String_0);
			}
		}
		await Task.Delay(2000);
		if (t2)
		{
			Class7.smethod_8(T2: true, restore: true, Class13.string_1);
		}
	}

	public static DialogResult smethod_3(string msg)
	{
		return MessageBox.Show(msg, "iRa1n", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
	}

	private async Task waitdfu()
	{
		foreach (Class7.Class9 item in Class7.smethod_6())
		{
			if (item.String_2 == "libusbK")
			{
				Class7.smethod_12(item.String_0);
			}
			if (item.String_2 == "libusb-win32")
			{
				Class7.smethod_12(item.String_0);
			}
			if (item.String_2 == "libwdi")
			{
				Class7.smethod_12(item.String_0);
			}
		}
		do
		{
			if (!bool_7)
			{
				return;
			}
		}
		while (!(smethod_2("-m", "DFU", ret: true, dfu: true) == "DFU"));
		bool_7 = false;
		bool_5 = true;
	}

	public void method_9(int value, string text, string SN = "")
	{
		Invoke((MethodInvoker)delegate
		{
			progressBar1.Value = value;
			label22.Text = text;
			label22.Visible = true;
			if (value == 100)
			{
				button8.Enabled = true;
			}
			if (text.Contains("Unregistered T2 device.."))
			{
				Clipboard.SetText(SN);
				MessageBox.Show("Congrats! Your device is supported for T2 full bypass! You can register your device using SN:" + SN + " (copied to clipboard!)", "iRa1n", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else if (text.Contains("Unregistered") && !text.Contains("T2"))
			{
				MessageBox.Show("Congrats! Your device is supported for iOS 15 full bypass! You can register your device in iRemoval PRO Website!", "iRa1n", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else if (text.Contains("Unsupported") && !text.Contains("iBridge"))
			{
				MessageBox.Show("Unfortunately, your device is NOT supported for iOS 15 Full bypass! Your device may be simlocked or has a changed SN", "iRa1n", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else if (text.Contains("iBridge"))
			{
				MessageBox.Show("Please update your locked T2 into latest iBridge 7.x !", "iRa1n", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else if (text.Contains("Successfully Activated.."))
			{
				MessageBox.Show("Your device has been succesfully Activated! \n\nRemember, this is an exclusive T2 Full Bypass service for last iBridgeOS!.\nPlease don't forget to review our service on Trustpilot!", "iDevice Activated Succesfully !", MessageBoxButtons.OK, MessageBoxIcon.Question);
				Process.Start("https://www.trustpilot.com/review/iremovalpro.com");
			}
			else if (text.Contains("Failed to get data"))
			{
				MessageBox.Show("Failed to get required Data, please goto Internet Recovery Screen(the screen with the Globe Animation) just go to it without connecting WiFi,\nafter that put your device in DFU mode and try again!!", "ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (text.Contains("Plug your device into recovery mode.."))
			{
				MessageBox.Show("Failed to load iRain! please connect your locked T2 into internet recovery mode (hold CMD + R) and then connect to DFU Mode!", "ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		});
	}

	private async void NextButt_Click(object sender, EventArgs e)
	{
		NextButt.Enabled = false;
		button4.Enabled = false;
		Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			FileName = Environment.CurrentDirectory + "\\bin\\ideviceenterrecovery.exe",
			Arguments = iOSDevice_0.UniqueDeviceID,
			UseShellExecute = false,
			RedirectStandardOutput = true,
			CreateNoWindow = true
		};
		process.Start();
		if (!process.StandardOutput.ReadToEnd().Contains("Device is successfully switching to recovery mode."))
		{
			label19.Text = "Failed to enter recovery mode!";
			label19.Visible = true;
			button4.Enabled = true;
		}
		else
		{
			bool_6 = true;
			Task_0 = method_7();
		}
	}

	private async void button6_Click(object sender, EventArgs e)
	{
		button6.Enabled = false;
		await Task.Delay(100);
		smethod_2("-n", "", ret: false);
		dfuPanel.Visible = false;
		button6.Enabled = true;
	}

	private async void button5_Click(object sender, EventArgs e)
	{
		button5.Enabled = false;
		button6.Enabled = false;
		await Task.Delay(10);
		startDFU.Enabled = false;
		pressDFU.Enabled = true;
		await Task.Delay(1000);
		pressDFU.Text = "2. Press and hold the Side \nand " + string_3 + " buttons \ntogether (3)";
		smethod_2("-n", "", ret: false);
		await Task.Delay(1000);
		pressDFU.Text = "2. Press and hold the Side \nand " + string_3 + " buttons \ntogether (2)";
		await Task.Delay(1000);
		pressDFU.Text = "2. Press and hold the Side \nand " + string_3 + " buttons \ntogether (1)";
		await Task.Delay(1000);
		pressDFU.Text = "2. Press and hold the Side \nand " + string_3 + " buttons \ntogether (0)";
		pressDFU.Enabled = false;
		label20.Enabled = true;
		bool_7 = true;
		Task.Factory.StartNew(() => waitdfu());
		int sec = 10;
		while (bool_7)
		{
			if (sec == 0)
			{
				bool_7 = false;
				break;
			}
			await Task.Delay(1000);
			sec--;
			label20.Text = string.Format("3. Release the Side button \nBUT KEEP HOLDING the \n" + string_3 + " button ({0})", sec.ToString());
		}
		label20.Text = "3. Release the Side button \nBUT KEEP HOLDING the \n" + string_3 + " button (0)";
		label20.Enabled = false;
		if (!bool_5)
		{
			dfuPanel.Visible = false;
			startDFU.Enabled = true;
			button5.Enabled = true;
			button6.Enabled = true;
			pressDFU.Text = "2. Press and hold the Side \nand " + string_3 + " buttons \ntogether (4)";
			label20.Text = "3. Release the Side button \nBUT KEEP HOLDING the \n" + string_3 + " button (10)";
			volumeDown78XLab.Visible = false;
			sideButton678Lab.Visible = false;
			sideButtonXLab.Visible = false;
			homeButtLab.Visible = false;
			devicePicture.Visible = false;
			return;
		}
		label21.Enabled = true;
		await method_8();
		await Task.Delay(2000);
		label21.Enabled = false;
		dfuPanel.Visible = false;
		startDFU.Enabled = true;
		button5.Enabled = true;
		button6.Enabled = true;
		pressDFU.Text = "2. Press and hold the Side \nand " + string_3 + " buttons \ntogether (4)";
		label20.Text = "3. Release the Side button \nBUT KEEP HOLDING the \n" + string_3 + " button (10)";
		volumeDown78XLab.Visible = false;
		sideButton678Lab.Visible = false;
		sideButtonXLab.Visible = false;
		homeButtLab.Visible = false;
		devicePicture.Visible = false;
		label22.Text = "";
		checkrainPanel.Visible = true;
		await Task.Delay(500);
		try
		{
			if (bool_1)
			{
				Task.Factory.StartNew(() => new Class4().Start15(this));
			}
			else
			{
				Task.Factory.StartNew(() => new Class4().Start(this));
			}
		}
		catch (Exception)
		{
		}
	}

	private async void button7_Click(object sender, EventArgs e)
	{
		button7.Enabled = false;
		await Task.Delay(50);
		List<Class7.Class9> list = Class7.smethod_6();
		bool flag = false;
		foreach (Class7.Class9 item in list)
		{
			if (item.String_4.Contains("05/19/2017 6.0.9999.69"))
			{
				flag = true;
			}
		}
		if (!flag)
		{
			button7.Text = "Fixing..";
			Class7.smethod_8();
		}
		button7.Text = "Done";
	}

	private void button8_Click(object sender, EventArgs e)
	{
		button8.Enabled = false;
		checkrainPanel.Visible = false;
		progressBar1.Value = 0;
	}

	private void label25_Click(object sender, EventArgs e)
	{
		Process.Start("https://t.me/VestaOX");
	}

	private void label26_Click(object sender, EventArgs e)
	{
		Process.Start("https://t.me/VestaOX");
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.recoveryPanel = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.NextButt = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dfuPanel = new System.Windows.Forms.Panel();
            this.homeButtLab = new System.Windows.Forms.Label();
            this.sideButton678Lab = new System.Windows.Forms.Label();
            this.volumeDown78XLab = new System.Windows.Forms.Label();
            this.sideButtonXLab = new System.Windows.Forms.Label();
            this.devicePicture = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pressDFU = new System.Windows.Forms.Label();
            this.startDFU = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.ecidLabel = new System.Windows.Forms.Label();
            this.warnLabel = new System.Windows.Forms.Label();
            this.checkrainPanel = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button8 = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.panel1.SuspendLayout();
            this.recoveryPanel.SuspendLayout();
            this.dfuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicePicture)).BeginInit();
            this.checkrainPanel.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to fk-world!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Connect your iPhone, iPod touch, iPad, or AppleTV to begin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Made by: Checkra1n / iRemoval / VestaOX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "With 💖 from @VestaOX";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(413, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "NOTE: Please ensure you have a backup of your device before applying the jailbrea" +
    "k.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 321);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(366, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "While data loss is unlikely, we won\'t be responsible if something goes wrong.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Use at your own risk.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Options";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(127, 357);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(90, 23);
            this.buttonRestore.TabIndex = 10;
            this.buttonRestore.Text = "Restore T2";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Visible = false;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(339, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Silver;
            this.label12.Location = new System.Drawing.Point(12, 284);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(415, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "____________________________________________________________________";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.Silver;
            this.label13.Location = new System.Drawing.Point(12, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(415, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "____________________________________________________________________";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 322);
            this.panel1.TabIndex = 16;
            this.panel1.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(25, 134);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(85, 13);
            this.label27.TabIndex = 10;
            this.label27.Text = "Boot Arguments:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(50, 153);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(357, 20);
            this.textBox1.TabIndex = 9;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(27, 234);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Fix Driver";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(28, 208);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(105, 17);
            this.checkBox5.TabIndex = 7;
            this.checkBox5.Text = "Dark Blockchain";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(28, 183);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(127, 17);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.Text = "Skip A11 BPR check";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(28, 107);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(90, 17);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Verbose Boot";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(28, 81);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(78, 17);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Safe Mode";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(28, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(227, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Allow untested iOS/iPadOS/tvOS versions";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(182, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "probably have no reason to set them.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(355, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "You may set the following options. If you don\'t know what they mean you\'ll";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(348, 295);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // recoveryPanel
            // 
            this.recoveryPanel.Controls.Add(this.checkrainPanel);
            this.recoveryPanel.Controls.Add(this.label19);
            this.recoveryPanel.Controls.Add(this.NextButt);
            this.recoveryPanel.Controls.Add(this.button4);
            this.recoveryPanel.Controls.Add(this.label18);
            this.recoveryPanel.Controls.Add(this.label17);
            this.recoveryPanel.Controls.Add(this.label16);
            this.recoveryPanel.Controls.Add(this.label15);
            this.recoveryPanel.Location = new System.Drawing.Point(1, 63);
            this.recoveryPanel.Name = "recoveryPanel";
            this.recoveryPanel.Size = new System.Drawing.Size(454, 322);
            this.recoveryPanel.TabIndex = 8;
            this.recoveryPanel.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 97);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(152, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Entering recovery mode ..........";
            this.label19.Visible = false;
            // 
            // NextButt
            // 
            this.NextButt.Location = new System.Drawing.Point(347, 290);
            this.NextButt.Name = "NextButt";
            this.NextButt.Size = new System.Drawing.Size(90, 23);
            this.NextButt.TabIndex = 5;
            this.NextButt.Text = "Next";
            this.NextButt.UseVisualStyleBackColor = true;
            this.NextButt.Click += new System.EventHandler(this.NextButt_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(241, 290);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(287, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "put into recovery mode first. Click Next when you are ready.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(369, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "In order to prevent filesystem corruption through hard reset, the device will be";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(235, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "manual process and we will guide you through it.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(360, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "The device needs to be put into DFU mode to apply the jailbreak. This is a ";
            // 
            // dfuPanel
            // 
            this.dfuPanel.Controls.Add(this.homeButtLab);
            this.dfuPanel.Controls.Add(this.sideButton678Lab);
            this.dfuPanel.Controls.Add(this.volumeDown78XLab);
            this.dfuPanel.Controls.Add(this.sideButtonXLab);
            this.dfuPanel.Controls.Add(this.devicePicture);
            this.dfuPanel.Controls.Add(this.label21);
            this.dfuPanel.Controls.Add(this.label20);
            this.dfuPanel.Controls.Add(this.pressDFU);
            this.dfuPanel.Controls.Add(this.startDFU);
            this.dfuPanel.Controls.Add(this.button5);
            this.dfuPanel.Controls.Add(this.button6);
            this.dfuPanel.Controls.Add(this.label23);
            this.dfuPanel.Controls.Add(this.label24);
            this.dfuPanel.Location = new System.Drawing.Point(-6, 0);
            this.dfuPanel.Name = "dfuPanel";
            this.dfuPanel.Size = new System.Drawing.Size(458, 324);
            this.dfuPanel.TabIndex = 9;
            this.dfuPanel.Visible = false;
            // 
            // homeButtLab
            // 
            this.homeButtLab.AutoSize = true;
            this.homeButtLab.BackColor = System.Drawing.Color.Transparent;
            this.homeButtLab.ForeColor = System.Drawing.Color.Black;
            this.homeButtLab.Location = new System.Drawing.Point(158, 263);
            this.homeButtLab.Name = "homeButtLab";
            this.homeButtLab.Size = new System.Drawing.Size(77, 13);
            this.homeButtLab.TabIndex = 14;
            this.homeButtLab.Text = "-- Home button";
            this.homeButtLab.Visible = false;
            // 
            // sideButton678Lab
            // 
            this.sideButton678Lab.AutoSize = true;
            this.sideButton678Lab.BackColor = System.Drawing.Color.Transparent;
            this.sideButton678Lab.Location = new System.Drawing.Point(201, 113);
            this.sideButton678Lab.Name = "sideButton678Lab";
            this.sideButton678Lab.Size = new System.Drawing.Size(70, 13);
            this.sideButton678Lab.TabIndex = 13;
            this.sideButton678Lab.Text = "-- Side button";
            this.sideButton678Lab.Visible = false;
            // 
            // volumeDown78XLab
            // 
            this.volumeDown78XLab.AutoSize = true;
            this.volumeDown78XLab.Location = new System.Drawing.Point(15, 134);
            this.volumeDown78XLab.Name = "volumeDown78XLab";
            this.volumeDown78XLab.Size = new System.Drawing.Size(80, 13);
            this.volumeDown78XLab.TabIndex = 12;
            this.volumeDown78XLab.Text = "Volume down --";
            this.volumeDown78XLab.Visible = false;
            // 
            // sideButtonXLab
            // 
            this.sideButtonXLab.AutoSize = true;
            this.sideButtonXLab.BackColor = System.Drawing.Color.Transparent;
            this.sideButtonXLab.Location = new System.Drawing.Point(201, 126);
            this.sideButtonXLab.Name = "sideButtonXLab";
            this.sideButtonXLab.Size = new System.Drawing.Size(70, 13);
            this.sideButtonXLab.TabIndex = 11;
            this.sideButtonXLab.Text = "-- Side button";
            this.sideButtonXLab.Visible = false;
            // 
            // devicePicture
            // 
            this.devicePicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.devicePicture.ErrorImage = null;
            this.devicePicture.InitialImage = null;
            this.devicePicture.Location = new System.Drawing.Point(90, 72);
            this.devicePicture.Name = "devicePicture";
            this.devicePicture.Size = new System.Drawing.Size(115, 211);
            this.devicePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.devicePicture.TabIndex = 10;
            this.devicePicture.TabStop = false;
            this.devicePicture.Visible = false;
            this.devicePicture.Click += new System.EventHandler(this.devicePicture_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Enabled = false;
            this.label21.Location = new System.Drawing.Point(279, 205);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(0, 13);
            this.label21.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Enabled = false;
            this.label20.Location = new System.Drawing.Point(279, 153);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(136, 39);
            this.label20.TabIndex = 8;
            this.label20.Text = "3. Release the Side button \nBUT KEEP HOLDING the \nVolume down button (10)";
            // 
            // pressDFU
            // 
            this.pressDFU.AutoSize = true;
            this.pressDFU.Enabled = false;
            this.pressDFU.Location = new System.Drawing.Point(279, 103);
            this.pressDFU.Name = "pressDFU";
            this.pressDFU.Size = new System.Drawing.Size(134, 39);
            this.pressDFU.TabIndex = 7;
            this.pressDFU.Text = "2. Press and hold the Side \nand Volume down buttons \ntogether (4)";
            // 
            // startDFU
            // 
            this.startDFU.AutoSize = true;
            this.startDFU.Location = new System.Drawing.Point(279, 77);
            this.startDFU.Name = "startDFU";
            this.startDFU.Size = new System.Drawing.Size(67, 13);
            this.startDFU.TabIndex = 6;
            this.startDFU.Text = "1. Click Start";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(347, 290);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Start";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(243, 290);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Cancel";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(16, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(354, 13);
            this.label23.TabIndex = 1;
            this.label23.Text = "your device and check the instructions on the right *before* clicking Start.";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(14, 11);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(380, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "Time to put the device into DFU mode. Locate the buttons as marked below on";
            // 
            // ecidLabel
            // 
            this.ecidLabel.AutoSize = true;
            this.ecidLabel.Location = new System.Drawing.Point(11, 119);
            this.ecidLabel.Name = "ecidLabel";
            this.ecidLabel.Size = new System.Drawing.Size(97, 13);
            this.ecidLabel.TabIndex = 17;
            this.ecidLabel.Text = "ECID: 0x00000000";
            this.ecidLabel.Visible = false;
            // 
            // warnLabel
            // 
            this.warnLabel.AutoSize = true;
            this.warnLabel.Location = new System.Drawing.Point(12, 136);
            this.warnLabel.Name = "warnLabel";
            this.warnLabel.Size = new System.Drawing.Size(50, 13);
            this.warnLabel.TabIndex = 18;
            this.warnLabel.Text = "Warnig...";
            this.warnLabel.Visible = false;
            // 
            // checkrainPanel
            // 
            this.checkrainPanel.Controls.Add(this.dfuPanel);
            this.checkrainPanel.Controls.Add(this.panel1);
            this.checkrainPanel.Controls.Add(this.label22);
            this.checkrainPanel.Controls.Add(this.progressBar1);
            this.checkrainPanel.Controls.Add(this.button8);
            this.checkrainPanel.Controls.Add(this.label28);
            this.checkrainPanel.Controls.Add(this.label29);
            this.checkrainPanel.Location = new System.Drawing.Point(0, 0);
            this.checkrainPanel.Name = "checkrainPanel";
            this.checkrainPanel.Size = new System.Drawing.Size(454, 322);
            this.checkrainPanel.TabIndex = 10;
            this.checkrainPanel.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(14, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 13);
            this.label22.TabIndex = 7;
            this.label22.Text = "Exploiting device..";
            this.label22.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.progressBar1.Location = new System.Drawing.Point(17, 111);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(398, 10);
            this.progressBar1.TabIndex = 6;
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(347, 290);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(90, 23);
            this.button8.TabIndex = 5;
            this.button8.Text = "Done";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(14, 26);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(284, 13);
            this.label28.TabIndex = 1;
            this.label28.Text = "Please enter it. Do not disconnect the device until finished.";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(14, 11);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(365, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Installing jailbreak, this will take a moment. If the device asks for a passcode";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label25.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label25.Location = new System.Drawing.Point(341, 271);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 13);
            this.label25.TabIndex = 19;
            this.label25.Text = "@VestaOX";
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 10;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.guna2CirclePictureBox3);
            this.guna2GradientPanel1.Controls.Add(this.guna2Separator2);
            this.guna2GradientPanel1.Controls.Add(this.label31);
            this.guna2GradientPanel1.Controls.Add(this.label30);
            this.guna2GradientPanel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(-2, -2);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(447, 63);
            this.guna2GradientPanel1.TabIndex = 21;
            this.guna2GradientPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2GradientPanel1_MouseDown);
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator2.Location = new System.Drawing.Point(3, 56);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(444, 10);
            this.guna2Separator2.TabIndex = 5;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.White;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(53, 33);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(69, 17);
            this.label31.TabIndex = 4;
            this.label31.Text = "@VestaOX";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.White;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(51, 11);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(194, 25);
            this.label30.TabIndex = 3;
            this.label30.Text = "Checkra1n Windows";
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.Image = global::Properties.Resources.pngwing_com;
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(365, 65);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(72, 84);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox2.TabIndex = 22;
            this.guna2CirclePictureBox2.TabStop = false;
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.Image = global::Properties.Resources.close_hover;
            this.guna2CirclePictureBox3.ImageRotate = 0F;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(419, 11);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(22, 39);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox3.TabIndex = 23;
            this.guna2CirclePictureBox3.TabStop = false;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::Properties.Resources.pngwing_com;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(11, 11);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(40, 39);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 2;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(444, 389);
            this.Controls.Add(this.recoveryPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.warnLabel);
            this.Controls.Add(this.ecidLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2CirclePictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AldazRa1n v1.0";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.recoveryPanel.ResumeLayout(false);
            this.recoveryPanel.PerformLayout();
            this.dfuPanel.ResumeLayout(false);
            this.dfuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicePicture)).EndInit();
            this.checkrainPanel.ResumeLayout(false);
            this.checkrainPanel.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}

	public static void FileEncryptAndSave(string FileNameInput, string FileNameOutput)
	{
		string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "bin/ref/");
		string path2 = Path.Combine(path, FileNameInput);
		byte[] data = File.ReadAllBytes(path2);
		byte[] bytes = AES256Encrypt(data, EncryptionKey());
		string path3 = Path.Combine(path, FileNameOutput);
		File.WriteAllBytes(path3, bytes);
	}

	public static void FileDecryptAndSave(string FileNameInput, string FileNameOutput)
	{
		string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "bin/ref/");
		string path2 = Path.Combine(path, FileNameInput);
		byte[] data = File.ReadAllBytes(path2);
		byte[] bytes = AES256Decrypt(data, EncryptionKey());
		string path3 = Path.Combine(FileNameOutput);
		File.WriteAllBytes(path3, bytes);
	}

	private static byte[] AES256Encrypt(byte[] data, byte[] key)
	{
		using Aes aes = Aes.Create();
		aes.Key = key;
		aes.Mode = CipherMode.ECB;
		aes.Padding = PaddingMode.PKCS7;
		ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
		using MemoryStream memoryStream = new MemoryStream();
		using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		cryptoStream.Write(data, 0, data.Length);
		cryptoStream.FlushFinalBlock();
		return memoryStream.ToArray();
	}

	private static byte[] AES256Decrypt(byte[] data, byte[] key)
	{
		using Aes aes = Aes.Create();
		aes.Key = key;
		aes.Mode = CipherMode.ECB;
		aes.Padding = PaddingMode.PKCS7;
		ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
		using MemoryStream stream = new MemoryStream(data);
		using CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read);
		byte[] array = new byte[data.Length];
		int num = cryptoStream.Read(array, 0, array.Length);
		byte[] array2 = new byte[num];
		Array.Copy(array, array2, num);
		return array2;
	}

	private static byte[] EncryptionKey()
	{
		string s = "7E892875A52C59A3B588306B13C31FBD";
		return Encoding.UTF8.GetBytes(s);
	}

	private void CloseBtn_Click(object sender, EventArgs e)
	{
		Processkill("openra1n.exe");
		Processkill("Checkra1n.exe");
		Processkill("pongoterm.exe");
		Process[] processesByName = Process.GetProcessesByName("irecovery");
		Process[] processesByName2 = Process.GetProcessesByName("iRa1n");
		if (processesByName.Length >= 1)
		{
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				process.Kill();
			}
			Process[] array2 = processesByName2;
			foreach (Process process2 in array2)
			{
				process2.Kill();
			}
		}
		Environment.Exit(1);
	}

	private void guna2GradientPanel1_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 161, 2, 0);
		}
	}

    private void devicePicture_Click(object sender, EventArgs e)
    {

    }
}
