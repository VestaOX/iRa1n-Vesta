using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using ns1;

namespace ns2;

internal class Class4
{
	internal class Class5
	{
		public byte[] byte_0;

		public ushort ushort_0;

		public byte[] byte_1;

		public ushort ushort_1;

		public byte[] byte_2;

		public ushort ushort_2;

		public byte[] byte_3;

		public ushort ushort_3;
	}

	internal class Class6
	{
		internal byte[] byte_0;

		internal byte[] byte_1;

		internal byte[] byte_2;

		internal byte[] byte_3;

		internal byte[] byte_4;

		internal byte[] byte_5;

		internal byte[] byte_6;

		internal byte[] byte_7;

		internal bool bool_0;
	}

	public class pnputil
	{
		private Class4 Td = new Class4();

		[DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern bool IsWow64Process(IntPtr hProcess, out bool Wow64Process);

		[DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern bool Wow64DisableWow64FsRedirection(out IntPtr OldValue);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetCurrentProcess();

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetModuleHandle(string moduleName);

		[DllImport("kernel32")]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		public void Get_SSH_hotkey()
		{
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				processStartInfo.UseShellExecute = false;
				processStartInfo.CreateNoWindow = true;
				processStartInfo.Verb = "runas";
				processStartInfo.FileName = "cmd.exe";
				processStartInfo.Arguments = "/C setlocal enabledelayedexpansion && RMDIR /s /q C:\\Windows\\Temp\\File > nul 2>&1";
				Process.Start(processStartInfo).WaitForExit();
				processStartInfo.Arguments = "/C reg delete HKEY_CURRENT_USER\\SOFTWARE\\SimonTatham\\PuTTY\\SshHostKeys /f > nul 2>&1";
				Process.Start(processStartInfo).WaitForExit();
				processStartInfo.Arguments = "/C reg add HKEY_CURRENT_USER\\SOFTWARE\\SimonTatham\\PuTTY\\SshHostKeys /f > nul 2>&1";
				Process.Start(processStartInfo).WaitForExit();
				processStartInfo.Arguments = "/C reg Query \"HKLM\\Hardware\\Description\\System\\CentralProcessor\\0\" | find /i \"x86\" > NUL && set cpu=32 || set cpu=64";
				Process.Start(processStartInfo).WaitForExit();
				processStartInfo.Arguments = "/C if \"%PROCESSOR_ARCHITECTURE%\" EQU \"amd64\" ( >nul 2>&1 \"%SYSTEMROOT%\\SysWOW64\\cacls\" \"%SYSTEMROOT%\\SysWOW64\\config\\system\" ) ELSE ( >nul 2>&1 \"%SYSTEMROOT%\\system32\\cacls\" \"%SYSTEMROOT%\\system32\\config\\system\" )";
				Process.Start(processStartInfo).WaitForExit();
				Process.Start(processStartInfo).WaitForExit();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public string get_oeminf(string searchname)
		{
			try
			{
				string text = pnputil_cmd("-e");
				if (string.IsNullOrEmpty(text))
				{
					throw new Exception("not found driver oem list");
				}
				string[] array = text.Split(new string[1] { "oem" }, StringSplitOptions.RemoveEmptyEntries);
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					if (text2.ToLower().Contains(searchname.ToLower()))
					{
						string[] array3 = text2.Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
						return "oem" + array3[0].Replace("\n", "").Replace("\r", "").Replace(" ", "")
							.Replace("\t", "");
					}
				}
				return null;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public string scan_device()
		{
			try
			{
				return pnputil_cmd(" /scan-devices ");
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public string delete_oeminf(string oeminf)
		{
			try
			{
				string cmd = $" /delete-driver {oeminf} /uninstall /force";
				return pnputil_cmd(cmd);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public string install_oeminf_1(string oeminf)
		{
			try
			{
				if (string.IsNullOrEmpty(oeminf))
				{
					oeminf = Path.Combine(Application.StartupPath, "bin\\ref\\x\\HASNIT3CH.inf");
				}
				if (!File.Exists(oeminf))
				{
					throw new Exception("oeminf file not found. driver inf file error.");
				}
				string cmd = $" -i -a \"{oeminf}\"";
				return pnputil_cmd(cmd);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public string install_oeminf_2(string oeminf)
		{
			try
			{
				if (string.IsNullOrEmpty(oeminf))
				{
					oeminf = Path.Combine(Application.StartupPath, "bin\\ref\\x\\HASNIT3CH.inf");
				}
				if (!File.Exists(oeminf))
				{
					throw new Exception("oeminf file not found. driver inf file error.");
				}
				string cmd = $" /add-driver \"{oeminf}\" /install";
				return pnputil_cmd(cmd);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public string[][] GetDataFull()
		{
			ManagementObjectCollection managementObjectCollection = null;
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT DeviceID,Name FROM Win32_PnPEntity where Name Like '%Apple Mobile Device%'");
			managementObjectCollection = managementObjectSearcher.Get();
			string[][] array = new string[managementObjectCollection.Count][];
			if (managementObjectSearcher.Get().Count >= 1)
			{
				try
				{
					int num = 0;
					foreach (ManagementObject item in managementObjectCollection)
					{
						string text = item["DeviceID"].ToString();
						string text2 = item["Name"].ToString();
						array[num] = new string[2] { text, text2 };
						num++;
					}
					return array;
				}
				catch (Exception ex)
				{
					array[0] = new string[1] { ex.Message };
					return array;
				}
			}
			return array;
		}

		public void uninstall_dfu_driver()
		{
			string[][] dataFull = GetDataFull();
			string[][] array = dataFull;
			foreach (string[] array2 in array)
			{
				fix_driver(array2[0], update_device: false, install_dfu_driver: false);
			}
		}

		public void fix_driver(string device_id, bool update_device = true, bool install_dfu_driver = true)
		{
			string driverInfName = getDriverInfName(device_id);
			shell_code("pnputil -d " + driverInfName + " -f -u");
			if (install_dfu_driver)
			{
				InstallDriversFull();
			}
			if (update_device)
			{
				shell_code("pnputil /scan-devices");
			}
		}

		public string shell_code(string _Command)
		{
			string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), (!Environment.Is64BitOperatingSystem || Environment.Is64BitProcess) ? "System32\\cmd.exe" : "Sysnative\\cmd.exe");
			ProcessStartInfo processStartInfo = new ProcessStartInfo(fileName, "/c " + _Command);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			Process process = new Process();
			process.StartInfo = processStartInfo;
			process.Start();
			string text = process.StandardOutput.ReadToEnd();
			Console.WriteLine(text);
			return text;
		}

		public string getDriverInfName(string device_id)
		{
			string text = "";
			string text2 = shell_code("pnputil /enum-devices /instanceid \"" + device_id + "\" /connected");
			try
			{
				text = text2;
				text2 = find_string(text, "oem(.*?).inf")[0].Value.ToString().Trim();
				return text2;
			}
			catch
			{
				return text2;
			}
		}

		public void InstallDriversFull()
		{
			X509Certificate2 certificate = new X509Certificate2(Convert.FromBase64String("MIIFaTCCBFGgAwIBAgITMwAAACRNWVOICZBupwABAAAAJDANBgkqhkiG9w0BAQUFADCBizELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjE1MDMGA1UEAxMsTWljcm9zb2Z0IFdpbmRvd3MgSGFyZHdhcmUgQ29tcGF0aWJpbGl0eSBQQ0EwHhcNMTYxMDEyMjAzMjUzWhcNMTgwMTA1MjAzMjUzWjCBoDELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjENMAsGA1UECxMETU9QUjE7MDkGA1UEAxMyTWljcm9zb2Z0IFdpbmRvd3MgSGFyZHdhcmUgQ29tcGF0aWJpbGl0eSBQdWJsaXNoZXIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDKxNQUvHr2Mf47EXW+dlzSNOKqM9pDU/y4hLRVtg5TWvZm9Z4ePsrTpYIoxRvroyiXmp7R9N0TB6Dr8YglzLfaPEiFgX++sRaXZLDGHG5CyK8u17HMabdi5LNyVayeB1ECfMvf30Cz2JhpVlc8Qsl5xC5vEJf/pD6gtzCsdpo53e6VKWrG5rr4TSgpA38IOqEzEkDH2TJoK2r4KlNlYRIEStwdHp0GCmV17KTCkonvP1+buaWcrfSanXB3getYZzOpwVP9qlldKQ22t8IWoVH9vUk2YoPvKc6E0TspaEh/ocZ3jEjCHU33bm7VgxoZkAnEGN/JHSChiZ1SznlrmH61AgMBAAGjggGtMIIBqTAfBgNVHSUEGDAWBgorBgEEAYI3CgMFBggrBgEFBQcDAzAdBgNVHQ4EFgQU16THNiLiI639hkVOZLQYnP+nzaMwUgYDVR0RBEswSaRHMEUxDTALBgNVBAsTBE1PUFIxNDAyBgNVBAUTKzIzMDAwMSs2ZWE3NjAzYy1lM2I1LTQxZDctODU3My0xMDRkZGZiZGNhNGIwHwYDVR0jBBgwFoAUKMzvYaR8vD+Wa/YNIn9qK4CIPi0wdgYDVR0fBG8wbTBroGmgZ4ZlaHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3BraS9DUkwvcHJvZHVjdHMvTWljcm9zb2Z0JTIwV2luZG93cyUyMEhhcmR3YXJlJTIwQ29tcGF0aWJpbGl0eSUyMFBDQSgxKS5jcmwwegYIKwYBBQUHAQEEbjBsMGoGCCsGAQUFBzAChl5odHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpL2NlcnRzL01pY3Jvc29mdCUyMFdpbmRvd3MlMjBIYXJkd2FyZSUyMENvbXBhdGliaWxpdHklMjBQQ0EoMSkuY3J0MA0GCSqGSIb3DQEBBQUAA4IBAQCfz/XQaDq8TI2upMyThBo7A38lEhFLeA5tHQuvIMpj8VuvEuFTktCVLXrT1uJwGCCF2N0qeK+KWF9VdQbJdVRhOKCHxY3Kxbnlh5oh3K9PAmual9xXxbin6F9Xhh3t9hhCGwNqSzMs0SpPbiq6CqH/Uknp2T12adE+unYdXd3UlbhqxG6sOPck9SUGDJAHkEXjBajuDMtibkzWci3s1W+CTW427KIBb8vM9UeenfezsSP20apCnXOAjPWfZbdefy2hb31cgbBUMNxYfACPP79a/ELJnPQLfy6nsnoxTCLLM+suut/pBLe26kD1fu6AzAWCKaYX4x3q05CarXOIXSHn"));
			X509Store x509Store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);
			X509Store x509Store2 = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
			x509Store.Open(OpenFlags.ReadWrite);
			x509Store.Add(certificate);
			x509Store2.Open(OpenFlags.ReadWrite);
			x509Store2.Add(certificate);
			try
			{
				try
				{
					if (Is64BitOperatingSystem())
					{
						Install(".\\bin\\driver\\install_x64.exe", "usb\\x64\\usbaapl64.inf");
					}
					else
					{
						Install(".\\bin\\driver\\install_x86.exe", "usb\\x86\\usbaapl.inf");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void install_libusbk()
		{
			X509Certificate2 certificate = new X509Certificate2(Convert.FromBase64String("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"));
			X509Store x509Store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);
			X509Store x509Store2 = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
			x509Store.Open(OpenFlags.ReadWrite);
			x509Store.Add(certificate);
			x509Store2.Open(OpenFlags.ReadWrite);
			x509Store2.Add(certificate);
			try
			{
				try
				{
					if (Is64BitOperatingSystem())
					{
						Install(".\\bin\\driver\\install_x64.exe", "libusbK\\Apple_Mobile_Device_(DFU_Mode).inf");
					}
					else
					{
						Install(".\\bin\\driver\\install_x86.exe", "libusbK\\Apple_Mobile_Device_(DFU_Mode).inf");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void FullKm(bool dfu, bool recovery, bool device, bool driver, bool none)
		{
			string[][] dataFull = GetDataFull();
			bool flag = false;
			string[][] array = dataFull;
			foreach (string[] array2 in array)
			{
				if (array2[1] == "Apple Mobile Device (DFU Mode)")
				{
					if (dfu)
					{
						flag = true;
					}
				}
				else if (array2[1] == "Apple Mobile Device (Recovery Mode)")
				{
					if (recovery)
					{
						flag = true;
					}
				}
				else if (array2[1] == "Apple Mobile Device USB Device")
				{
					if (device)
					{
						flag = true;
					}
				}
				else if (array2[1] == "")
				{
					if (none)
					{
						flag = true;
					}
				}
				else if (array2[1] == "Apple Mobile Device USB Driver" && driver)
				{
					flag = true;
				}
			}
			if (flag)
			{
				InstallDriversFull();
			}
		}

		public MatchCollection find_string(string the_page, string pattern, RegexOptions opt = RegexOptions.ExplicitCapture)
		{
			Regex regex = new Regex(pattern, opt);
			return regex.Matches(the_page);
		}

		public static bool Is64BitOperatingSystem()
		{
			if (IntPtr.Size == 8)
			{
				return true;
			}
			IntPtr moduleHandle = GetModuleHandle("kernel32");
			if (moduleHandle != IntPtr.Zero)
			{
				IntPtr procAddress = GetProcAddress(moduleHandle, "IsWow64Process");
				if (procAddress != IntPtr.Zero && IsWow64Process(GetCurrentProcess(), out var Wow64Process) && Wow64Process)
				{
					return true;
				}
			}
			return false;
		}

		public void Install(string Processname, string inf, bool uninstall = false)
		{
			string text = "";
			text = ((!uninstall) ? $"install --inf=\"{inf}\"" : $"uninstall --inf=\"{inf}\"");
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo
				{
					WindowStyle = ProcessWindowStyle.Hidden,
					FileName = Processname,
					Arguments = text,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					Verb = "runas",
					WorkingDirectory = Path.GetDirectoryName(Processname)
				};
				processStartInfo.RedirectStandardOutput = true;
				processStartInfo.UseShellExecute = false;
				processStartInfo.CreateNoWindow = true;
				Process process = new Process
				{
					StartInfo = processStartInfo
				};
				process.OutputDataReceived += Async_Data;
				process.Start();
				process.BeginOutputReadLine();
				process.WaitForExit();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private void Async_Data(object sender, DataReceivedEventArgs e)
		{
			if (e.Data != null)
			{
				if (e.Data.ToLower().Contains("error") || e.Data.ToLower().Contains("fail"))
				{
					Console.WriteLine(e.Data + Environment.NewLine);
				}
				else
				{
					Console.WriteLine(e.Data + Environment.NewLine);
				}
			}
		}

		public void RunCommand(string command)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = "cmd.exe";
			processStartInfo.Verb = "runas";
			processStartInfo.WorkingDirectory = Path.Combine(Application.StartupPath, "bin\\ref\\x");
			processStartInfo.Arguments = $"/C {command}";
			processStartInfo.CreateNoWindow = true;
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			Process.Start(processStartInfo).WaitForExit();
		}

		public void call_DFU_Mode()
		{
			string arg = Path.Combine(Application.StartupPath, "bin\\ref\\x\\DFU_Mode.vbs");
			RunCommand($"cscript {arg}");
			RunCommand("TIMEOUT 3 >nul");
		}

		public string pnputil_cmd(string cmd)
		{
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				UseShellExecute = false,
				CreateNoWindow = true,
				FileName = ".\\bin\\pnputil.exe",
				Verb = "runas",
				Arguments = cmd,
				WorkingDirectory = Path.Combine(Application.StartupPath),
				RedirectStandardOutput = true,
				RedirectStandardError = true
			};
			Process process2 = process;
			process2.Start();
			return process2.StandardOutput.ReadToEnd() + process2.StandardError.ReadToEnd();
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

		public bool Check_LibusbPort(int vid, int pid)
		{
			UsbRegDeviceList allWinUsbDevices = UsbDevice.AllWinUsbDevices;
			for (int i = 0; i < allWinUsbDevices.Count; i++)
			{
				if (allWinUsbDevices[i].Vid == vid && allWinUsbDevices[i].Pid == pid)
				{
					return true;
				}
			}
			return false;
		}
	}

	internal static BackgroundWorker backgroundWorker_0;

	internal static BackgroundWorker backgroundWorker_1;

	private Form1 form1_0;

	private string temp = Path.GetTempPath() + "\\";

	private static string UserTemporaryFolder = Path.GetTempPath();

	private static string ApplicationTemporaryFolderName = "User";

	private static string ApplicationTemporaryFolder = Path.Combine(UserTemporaryFolder, ApplicationTemporaryFolderName);

	private string usbdk = Path.Combine(Application.StartupPath, "bin\\ref\\UsbDkController.exe");

	internal void method_4(object sender, DoWorkEventArgs e)
	{
		try
		{
			ResetTemporaryFolder();
			commandExtract();
			form1_0.method_9(10, "Exploiting device..");
			pnputil pnputil = new pnputil();
			pnputil.Get_SSH_hotkey();
			string arg = pnputil.get_oeminf("apple");
			string arg2 = pnputil.get_oeminf("libusbK");
			string cmd = $" /delete-driver {arg} /uninstall /force";
			string cmd2 = $" /delete-driver {arg2} /uninstall /force";
			pnputil.pnputil_cmd(cmd);
			pnputil.pnputil_cmd(cmd2);
			pnputil.scan_device();
			pnputil.call_DFU_Mode();
			form1_0.method_9(20, "Exploiting device (this is checkm8)..");
			pnputil.install_oeminf_1("");
			pnputil.install_oeminf_2("");
			Thread.Sleep(100);
			Uninstall_UsbDk();
			while (!pnputil.Check_LibusbPort(1452, 4647))
			{
			}
			form1_0.method_9(30, "Exploiting device (this is payload)..");
			Send_Payload();
			while (!pnputil.Check_LibusbPort(1452, 16705))
			{
			}
			form1_0.method_9(60, "Booting..");
			Thread.Sleep(100);
			Star_Jailbreak();
			ResetTemporaryFolder();
			form1_0.method_9(100, "All Done");
			pnputil.uninstall_dfu_driver();
			string oeminf = Path.Combine(Application.StartupPath, "bin\\ref\\usbaapl64.inf");
			pnputil.install_oeminf_1(oeminf);
			pnputil.install_oeminf_2(oeminf);
			Uninstall_UsbDk();
			pnputil.InstallDriversFull();
		}
		catch (Exception ex)
		{
			Console.WriteLine("errors -> " + ex.Message);
		}
	}

	public string Send_Payload()
	{
		string text = "Checkra1n.exe";
		if (Form1.iOSPublic == "12.x" || Form1.iOSPublic == "13.x" || Form1.iOSPublic == "14.x")
		{
			text = "openra1n.exe";
		}
		else if (Form1.iOSPublic == "15.x" || Form1.iOSPublic == "16.x")
		{
			text = "HASNIT3CH.exe";
		}
		else if (Form1.iOSPublic == "16.4x")
		{
			text = "Checkra1n.exe";
		}
		Process process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				UseShellExecute = false,
				CreateNoWindow = true,
				FileName = temp + "User\\resx\\" + text,
				Verb = "runas",
				Arguments = "",
				WorkingDirectory = ".\\bin\\ref\\",
				RedirectStandardOutput = true,
				RedirectStandardError = true
			}
		};
		process.Start();
		return process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd();
	}

	public string Star_Jailbreak()
	{
		Process process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				UseShellExecute = false,
				CreateNoWindow = true,
				FileName = "cmd.exe",
				Verb = "runas",
				Arguments = "/C pongoterm <pongo.txt",
				WorkingDirectory = temp + "User\\resx\\",
				RedirectStandardOutput = true,
				RedirectStandardError = true
			}
		};
		process.Start();
		return process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd();
	}

	public void commandExtract()
	{
		File.WriteAllBytes(temp + "iAlByHASNIT3CH.cd", Class1.ikey);
		FileDecryptAndSave(temp + "iAlByHASNIT3CH.cd", temp + "iAlByHASNIT3CH.zip");
		ZipFile.ExtractToDirectory(temp + "iAlByHASNIT3CH.zip", temp + "User");
		File.Delete(temp + "iAlByHASNIT3CH.zip");
		File.Delete(temp + "iAlByHASNIT3CH.cd");
		FileDecryptAndSave(temp + "User\\resx\\pongo.xx", temp + "User\\resx\\pongo.txt");
		Console.WriteLine(temp);
	}

	public static void ResetTemporaryFolder()
	{
		if (Directory.Exists(ApplicationTemporaryFolder))
		{
			Directory.Delete(ApplicationTemporaryFolder, recursive: true);
		}
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
		string path = Path.Combine(FileNameInput);
		byte[] data = File.ReadAllBytes(path);
		byte[] bytes = AES256Decrypt(data, EncryptionKey());
		string path2 = Path.Combine(FileNameOutput);
		File.WriteAllBytes(path2, bytes);
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

	private static string TemporaryDir()
	{
		return Path.GetTempPath();
	}

	public string Uninstall_UsbDk()
	{
		Process process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				UseShellExecute = false,
				CreateNoWindow = true,
				FileName = "cmd.exe",
				Verb = "runas",
				Arguments = $"/C \"{usbdk}\" -u",
				WorkingDirectory = Path.GetDirectoryName(usbdk),
				RedirectStandardOutput = true,
				RedirectStandardError = true
			}
		};
		process.Start();
		Thread.Sleep(1000);
		return process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd();
	}

	public async Task Start(Form1 main)
	{
		form1_0 = main;
		backgroundWorker_1 = null;
		backgroundWorker_1 = new BackgroundWorker();
		backgroundWorker_1.DoWork += method_4;
		await Task.Delay(10);
		backgroundWorker_1.RunWorkerAsync();
	}

	public async Task Start15(Form1 main)
	{
		form1_0 = main;
		backgroundWorker_1 = null;
		backgroundWorker_1 = new BackgroundWorker();
		backgroundWorker_1.DoWork += method_4;
		await Task.Delay(10);
		backgroundWorker_1.RunWorkerAsync();
	}

	public async Task method_7(Form1 main)
	{
		form1_0 = main;
		backgroundWorker_1 = null;
		backgroundWorker_1 = new BackgroundWorker();
		backgroundWorker_1.DoWork += method_4;
		await Task.Delay(10);
		backgroundWorker_1.RunWorkerAsync();
	}

	public async Task method_8(Form1 main)
	{
		form1_0 = main;
		backgroundWorker_1 = null;
		backgroundWorker_1 = new BackgroundWorker();
		backgroundWorker_1.DoWork += method_4;
		await Task.Delay(10);
		backgroundWorker_1.RunWorkerAsync();
	}
}
