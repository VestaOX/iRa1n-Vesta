using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;

namespace ns2;

internal class Class7
{
	public class Class8
	{
		[CompilerGenerated]
		private string string_0;

		public string String_0
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}
	}

	public class Class9
	{
		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1 = "";

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

		[CompilerGenerated]
		private string string_4;

		[CompilerGenerated]
		private string string_5;

		public bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		public string String_0
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string String_1
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string String_2
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public string String_3
		{
			[CompilerGenerated]
			get
			{
				return string_3;
			}
			[CompilerGenerated]
			set
			{
				string_3 = value;
			}
		}

		public string String_4
		{
			[CompilerGenerated]
			get
			{
				return string_4;
			}
			[CompilerGenerated]
			set
			{
				string_4 = value;
			}
		}

		public string String_5
		{
			[CompilerGenerated]
			get
			{
				return string_5;
			}
			[CompilerGenerated]
			set
			{
				string_5 = value;
			}
		}
	}

	internal static bool bool_0;

	public static Process proceso = new Process();

	public static List<Class9> smethod_0(IEnumerable<string> enumerable)
	{
		List<Class9> list = new List<Class9>();
		string[] array = enumerable.ToArray();
		for (int i = 2; i < array.Length - 1; i++)
		{
			List<string> list2 = new List<string>();
			do
			{
				list2.Add(array[i]);
				i++;
			}
			while (!string.IsNullOrEmpty(array[i]));
			Class9 item = new Class9
			{
				String_0 = smethod_2(list2[0]),
				String_2 = smethod_2(list2[1]),
				String_3 = smethod_2(list2[2]),
				String_4 = smethod_2(list2[3]),
				String_5 = smethod_2(list2[4])
			};
			list.Add(item);
		}
		return list;
	}

	public static List<Class8> smethod_1(IEnumerable<string> enumerable)
	{
		List<Class8> list = new List<Class8>();
		string[] array = enumerable.ToArray();
		for (int i = 2; i < array.Length - 1; i++)
		{
			List<string> list2 = new List<string>();
			do
			{
				list2.Add(array[i]);
				i++;
			}
			while (!string.IsNullOrEmpty(array[i]));
			Class8 item = new Class8
			{
				String_0 = smethod_2(list2[0])
			};
			list.Add(item);
		}
		return list;
	}

	internal static string smethod_2(string line)
	{
		return line.Split(new string[1] { ": " }, StringSplitOptions.None)[1].Trim();
	}

	public static List<string> smethod_3(string[] args)
	{
		Process process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/C pnputil " + string.Join(" ", args),
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true
			}
		};
		process.Start();
		using (process)
		{
			List<string> list = new List<string>();
			string item;
			while ((item = process.StandardOutput.ReadLine()) != null)
			{
				list.Add(item);
			}
			return list;
		}
	}

	public static string smethod_4()
	{
		Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			FileName = "cmd.exe",
			Arguments = "/C netstat -ano | findstr :27015 && tasklist | findstr Apple",
			UseShellExecute = false,
			RedirectStandardOutput = true,
			CreateNoWindow = true
		};
		process.Start();
		process.WaitForExit(1000);
		return process.StandardOutput.ReadToEnd();
	}

	public static string smethod_5()
	{
		Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			FileName = "cmd.exe",
			Arguments = "/C wmic os get BuildNumber",
			UseShellExecute = false,
			RedirectStandardOutput = true,
			CreateNoWindow = true
		};
		process.Start();
		process.WaitForExit(1000);
		return process.StandardOutput.ReadToEnd();
	}

	public static List<Class9> smethod_6()
	{
		return smethod_0(smethod_3(new string[1] { "-e" }));
	}

	private static string SheLL(string Command)
	{
		File.WriteAllText("shell.cmd", "@echo off\n" + Command);
		proceso = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "shell.cmd",
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true
			}
		};
		proceso.Start();
		StreamReader standardOutput = proceso.StandardOutput;
		return standardOutput.ReadToEnd();
	}

	public static void Pnputil_Restart()
	{
		string text = "bin";
		File.WriteAllText("url.cmd", "@echo off\n\"" + text + "\\pnputil.exe\" /restart-device /class \"USB\" /bus \"USB\"");
		Process process = new Process();
		process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "url.cmd",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true
			}
		};
		process.Start();
		process.WaitForExit();
	}

	public static void smethod_8(bool T2 = false, bool restore = false, string ucid = "")
	{
		Process[] processesByName = Process.GetProcessesByName("iproxy");
		for (int i = 0; i < processesByName.Length; i++)
		{
		}
		Process[] processesByName2 = Process.GetProcessesByName("pnputil");
		for (int j = 0; j < processesByName2.Length; j++)
		{
		}
		X509Certificate2 certificate = new X509Certificate2(Convert.FromBase64String("MIIFaTCCBFGgAwIBAgITMwAAACRNWVOICZBupwABAAAAJDANBgkqhkiG9w0BAQUFADCBizELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjE1MDMGA1UEAxMsTWljcm9zb2Z0IFdpbmRvd3MgSGFyZHdhcmUgQ29tcGF0aWJpbGl0eSBQQ0EwHhcNMTYxMDEyMjAzMjUzWhcNMTgwMTA1MjAzMjUzWjCBoDELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjENMAsGA1UECxMETU9QUjE7MDkGA1UEAxMyTWljcm9zb2Z0IFdpbmRvd3MgSGFyZHdhcmUgQ29tcGF0aWJpbGl0eSBQdWJsaXNoZXIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDKxNQUvHr2Mf47EXW+dlzSNOKqM9pDU/y4hLRVtg5TWvZm9Z4ePsrTpYIoxRvroyiXmp7R9N0TB6Dr8YglzLfaPEiFgX++sRaXZLDGHG5CyK8u17HMabdi5LNyVayeB1ECfMvf30Cz2JhpVlc8Qsl5xC5vEJf/pD6gtzCsdpo53e6VKWrG5rr4TSgpA38IOqEzEkDH2TJoK2r4KlNlYRIEStwdHp0GCmV17KTCkonvP1+buaWcrfSanXB3getYZzOpwVP9qlldKQ22t8IWoVH9vUk2YoPvKc6E0TspaEh/ocZ3jEjCHU33bm7VgxoZkAnEGN/JHSChiZ1SznlrmH61AgMBAAGjggGtMIIBqTAfBgNVHSUEGDAWBgorBgEEAYI3CgMFBggrBgEFBQcDAzAdBgNVHQ4EFgQU16THNiLiI639hkVOZLQYnP+nzaMwUgYDVR0RBEswSaRHMEUxDTALBgNVBAsTBE1PUFIxNDAyBgNVBAUTKzIzMDAwMSs2ZWE3NjAzYy1lM2I1LTQxZDctODU3My0xMDRkZGZiZGNhNGIwHwYDVR0jBBgwFoAUKMzvYaR8vD+Wa/YNIn9qK4CIPi0wdgYDVR0fBG8wbTBroGmgZ4ZlaHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3BraS9DUkwvcHJvZHVjdHMvTWljcm9zb2Z0JTIwV2luZG93cyUyMEhhcmR3YXJlJTIwQ29tcGF0aWJpbGl0eSUyMFBDQSgxKS5jcmwwegYIKwYBBQUHAQEEbjBsMGoGCCsGAQUFBzAChl5odHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpL2NlcnRzL01pY3Jvc29mdCUyMFdpbmRvd3MlMjBIYXJkd2FyZSUyMENvbXBhdGliaWxpdHklMjBQQ0EoMSkuY3J0MA0GCSqGSIb3DQEBBQUAA4IBAQCfz/XQaDq8TI2upMyThBo7A38lEhFLeA5tHQuvIMpj8VuvEuFTktCVLXrT1uJwGCCF2N0qeK+KWF9VdQbJdVRhOKCHxY3Kxbnlh5oh3K9PAmual9xXxbin6F9Xhh3t9hhCGwNqSzMs0SpPbiq6CqH/Uknp2T12adE+unYdXd3UlbhqxG6sOPck9SUGDJAHkEXjBajuDMtibkzWci3s1W+CTW427KIBb8vM9UeenfezsSP20apCnXOAjPWfZbdefy2hb31cgbBUMNxYfACPP79a/ELJnPQLfy6nsnoxTCLLM+suut/pBLe26kD1fu6AzAWCKaYX4x3q05CarXOIXSHn"));
		X509Store x509Store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);
		X509Store x509Store2 = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
		x509Store.Open(OpenFlags.ReadWrite);
		x509Store.Add(certificate);
		x509Store2.Open(OpenFlags.ReadWrite);
		x509Store2.Add(certificate);
		Process process = new Process();
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.CreateNoWindow = true;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.RedirectStandardError = true;
		process.StartInfo.FileName = "cmd.exe";
		process.StartInfo.WorkingDirectory = Path.GetDirectoryName(Environment.CurrentDirectory + "\\bin\\driver\\usb\\" + (Environment.Is64BitOperatingSystem ? "x64\\" : "x86\\"));
		process.StartInfo.Arguments = "/c pnputil -a " + (Environment.Is64BitOperatingSystem ? "usbaapl64.inf" : "usbaapl.inf");
		process.Start();
		process.WaitForExit();
		Process process2 = new Process();
		process2.StartInfo.UseShellExecute = false;
		process2.StartInfo.CreateNoWindow = true;
		process2.StartInfo.RedirectStandardOutput = true;
		process2.StartInfo.RedirectStandardError = true;
		process2.StartInfo.FileName = "cmd.exe";
		process2.StartInfo.WorkingDirectory = Path.GetDirectoryName(Environment.CurrentDirectory + "\\bin\\driver\\usb\\" + (Environment.Is64BitOperatingSystem ? "x64\\" : "x86\\"));
		process2.StartInfo.Arguments = "/c pnputil -i -a " + (Environment.Is64BitOperatingSystem ? "usbaapl64.inf" : "usbaapl.inf");
		process2.Start();
		new List<string>();
		string text = "";
		string text2;
		while ((text2 = process2.StandardOutput.ReadLine()) != null)
		{
			if (text2.Contains("oem"))
			{
				text = smethod_2(text2);
			}
		}
		process2.WaitForExit();
		try
		{
			if (!T2)
			{
				return;
			}
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM").OpenSubKey("CurrentControlSet").OpenSubKey("Enum")
				.OpenSubKey("USB", writable: true);
			RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SYSTEM").OpenSubKey("CurrentControlSet").OpenSubKey("Control")
				.OpenSubKey("Class")
				.OpenSubKey("{36fc9e60-c465-11cf-8056-444553540000}", writable: true);
			RegistryKey registryKey3 = null;
			string[] subKeyNames = registryKey2.GetSubKeyNames();
			string[] array = subKeyNames;
			foreach (string name in array)
			{
				try
				{
					RegistryKey registryKey4 = registryKey2.OpenSubKey(name, writable: true);
					object value = registryKey4.GetValue("InfPath");
					if (value != null && ((string)value).Contains(text))
					{
						registryKey3 = registryKey4;
						break;
					}
				}
				catch
				{
				}
			}
			string text3 = registryKey3.Name.Substring(registryKey3.Name.Length - 4);
			Console.WriteLine(text3 + text);
			RegistryKey registryKey5 = registryKey.OpenSubKey("VID_05AC&PID_8600", writable: true);
			if (registryKey5 != null)
			{
				RegistryKey registryKey6 = registryKey5.OpenSubKey("000000000000", writable: true);
				registryKey6.SetValue("DeviceDesc", "@" + text + ",%iphone.devicedesc%;Apple Mobile Device USB Driver");
				registryKey6.SetValue("Service", "USBAAPL64");
				registryKey6.SetValue("Driver", "{36fc9e60-c465-11cf-8056-444553540000}\\" + text3);
				registryKey6.SetValue("Mfg", "@" + text + ",%mfgname%;Apple, Inc.");
				registryKey6.SetValue("FriendlyName", "@" + text + ",%iPhone.DeviceDesc%;Apple Mobile Device USB Driver");
				bool_0 = true;
				registryKey6.Close();
				registryKey5.Close();
			}
			registryKey.Close();
			registryKey.Close();
			registryKey2.Close();
			registryKey3.Close();
		}
		catch (Exception ex)
		{
			File.WriteAllText("error", ex.Message);
		}
	}

	internal static bool smethod_9(RegistryKey subKey)
	{
		bool result = true;
		if (subKey == null)
		{
			result = false;
		}
		return result;
	}

	internal static string smethod_10()
	{
		string result = "";
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
		ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
		if (managementObjectCollection != null)
		{
			foreach (ManagementObject item in managementObjectCollection)
			{
				result = item["Caption"].ToString() + " - " + item["OSArchitecture"].ToString();
			}
		}
		return result;
	}

	internal static void smethod_11()
	{
		bool flag = false;
		RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{36fc9e60-c465-11cf-8056-444553540000}", writable: true);
		object value = registryKey.GetValue("UPPERFILTERS");
		if (value != null)
		{
			string[] array = (string[])value;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == "UsbDk")
				{
					flag = true;
					break;
				}
			}
		}
		else
		{
			List<string> list = new List<string>();
			registryKey.CreateSubKey("UPPERFILTERS");
			registryKey.SetValue("UPPERFILTERS", list.ToArray(), RegistryValueKind.MultiString);
		}
		registryKey.Close();
		bool flag2 = File.Exists("C:\\Windows\\System32\\drivers\\UsbDk.sys");
		_ = flag && flag2;
	}

	internal static void smethod_12(string Infpath)
	{
		Process process = new Process();
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.CreateNoWindow = true;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.RedirectStandardError = true;
		process.StartInfo.FileName = "cmd.exe";
		process.StartInfo.Arguments = "/c pnputil -f -d " + Infpath;
		process.Start();
		process.StandardOutput.ReadToEnd();
		process.WaitForExit();
		process.Dispose();
	}
}
