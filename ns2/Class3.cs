using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using iMobileDevice;
using iMobileDevice.DiagnosticsRelay;
using iMobileDevice.iDevice;
using iMobileDevice.Lockdown;
using iMobileDevice.Plist;
using iMobileDevice.Usbmuxd;
using ns0;

namespace ns2;

internal class Class3
{
	internal static IUsbmuxdApi iusbmuxdApi_0 = LibiMobileDevice.Instance.Usbmuxd;

	private static readonly UsbmuxdEventCallBack usbmuxdEventCallBack_0 = smethod_0();

	private static IiDeviceApi iiDeviceApi_0 = LibiMobileDevice.Instance.iDevice;

	private static ILockdownApi ilockdownApi_0 = LibiMobileDevice.Instance.Lockdown;

	private static IDiagnosticsRelayApi idiagnosticsRelayApi_0 = LibiMobileDevice.Instance.DiagnosticsRelay;

	private static IPlistApi iplistApi_0 = LibiMobileDevice.Instance.Plist;

	public static bool bool_0 = false;

	private static Socket socket_0;

	private static Form1 form1_0;

	private static Process process_0;

	private static bool bool_1 = false;

	internal static bool bool_2 = false;

	public static iDeviceHandle iDeviceHandle_0;

	private static int int_0 = 2;

	private static int int_1 = 4;

	private static bool bool_3 = false;

	public void method_0(Form1 main)
	{
		try
		{
			form1_0 = main;
			bool_0 = false;
			method_1();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void method_1()
	{
		iusbmuxdApi_0.usbmuxd_subscribe(usbmuxdEventCallBack_0, IntPtr.Zero);
	}

	private static UsbmuxdEventCallBack smethod_0()
	{
		return delegate(ref UsbmuxdEvent devEvent, IntPtr data)
		{
			switch (devEvent.@event)
			{
			case 2:
				bool_2 = false;
				break;
			case 1:
				smethod_7(devEvent.device.udid, devEvent.device.handle);
				break;
			}
		};
	}

	internal static string smethod_1()
	{
		try
		{
			process_0 = new Process
			{
				StartInfo = 
				{
					FileName = Environment.CurrentDirectory + "/bin/iproxy.exe",
					Arguments = "2088 2088",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				}
			};
			process_0.Start();
			string address = "http://127.0.0.1:2088/526F758C811711EDA1EB0242AC120002";
			using WebClient webClient = new WebClient();
			string text = webClient.DownloadString(address);
			Console.WriteLine(text);
			File.WriteAllText("infos", text);
			return text;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message + ex.StackTrace);
			File.WriteAllText("err3", ex.Message);
			return "";
		}
	}

	internal static string smethod_2()
	{
		try
		{
			process_0 = new Process
			{
				StartInfo = 
				{
					FileName = Environment.CurrentDirectory + "/bin/iproxy.exe",
					Arguments = "2088 2088",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				}
			};
			process_0.Start();
			string address = "http://127.0.0.1:2088/hello";
			using WebClient webClient = new WebClient();
			string text = webClient.DownloadString(address);
			Console.WriteLine(text);
			return text;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message + ex.StackTrace);
			return "";
		}
	}

	internal static string smethod_3()
	{
		try
		{
			process_0 = new Process
			{
				StartInfo = 
				{
					FileName = Environment.CurrentDirectory + "/bin/iproxy.exe",
					Arguments = "2088 2088",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				}
			};
			process_0.Start();
			string address = "http://127.0.0.1:2088/reboot";
			using WebClient webClient = new WebClient();
			string text = webClient.DownloadString(address);
			Console.WriteLine(text);
			return text;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message + ex.StackTrace);
			return "";
		}
	}

	internal static string smethod_4()
	{
		try
		{
			process_0 = new Process
			{
				StartInfo = 
				{
					FileName = Environment.CurrentDirectory + "/bin/iproxy.exe",
					Arguments = "2088 2088",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				}
			};
			process_0.Start();
			string address = "http://127.0.0.1:2088/09732dee-870f-11ed-a1eb-0242ac120002";
			string data = "{\"mb\": \"TlVM==\"}";
			using WebClient webClient = new WebClient();
			webClient.Proxy = null;
			webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
			return webClient.UploadString(address, data);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message + ex.StackTrace);
			return "";
		}
	}

	internal static string smethod_5(string blob)
	{
		try
		{
			process_0 = new Process
			{
				StartInfo = 
				{
					FileName = Environment.CurrentDirectory + "/bin/iproxy.exe",
					Arguments = "2088 2088",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				}
			};
			process_0.Start();
			string address = "http://127.0.0.1:2088/8E7F5671524994AC2939DD1E240CA157";
			string data = "{\"mb\": \"TlVM==\", \"data\": \"" + blob + "\"}";
			using WebClient webClient = new WebClient();
			webClient.Proxy = null;
			webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
			return webClient.UploadString(address, data);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message + ex.StackTrace);
			return "";
		}
	}

	internal static void smethod_6()
	{
	}

	private static void smethod_7(string newUdid, uint handle)
	{
	}

	internal static bool smethod_8()
	{
		try
		{
			process_0 = new Process
			{
				StartInfo = 
				{
					FileName = Environment.CurrentDirectory + "/bin/iproxy.exe",
					Arguments = "2088 2088",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				}
			};
			process_0.Start();
			Thread.Sleep(2000);
			string address = Class13.smethod_2("dx3KlUV/3H/GgsonvAoJH3AnxVAa9dMlHqChW/Pj4Y4=");
			using (WebClient webClient = new WebClient())
			{
				string text = webClient.DownloadString(address);
				Console.WriteLine(text);
				if (text.Contains("IFPDZ"))
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			Console.WriteLine("here " + ex.Message + ex.StackTrace);
			return false;
		}
	}

	internal static string smethod_9(string udid)
	{
		int num = -666;
		IntPtr device = IntPtr.Zero;
		IntPtr service = IntPtr.Zero;
		IntPtr resultPlist = IntPtr.Zero;
		string result = "";
		IntPtr intPtr = Class0.plist_new_array();
		IntPtr item = Class0.plist_new_string("Qq9/Mya05P4ToEr1pMpGGg");
		Class0.plist_array_append_item(intPtr, item);
		if (Class0.idevice_new_with_options(out device, udid, bool_3 ? int_1 : int_0) != 0)
		{
			Console.WriteLine("No device found with udid " + udid);
		}
		else
		{
			IntPtr client = IntPtr.Zero;
			if ((num = Class0.lockdownd_client_new_with_handshake(device, out client, "idevicediagnostics")) != 0)
			{
				Class0.idevice_free(device);
				Console.WriteLine("ERROR: Could not connect to lockdownd");
			}
			else
			{
				num = Class0.lockdownd_start_service(client, "com.apple.mobile.diagnostics_relay", out service);
				if (num == -17)
				{
					num = Class0.lockdownd_start_service(client, "com.apple.iosdiagnostics.relay", out service);
				}
				Class0.lockdownd_client_free(client);
				if (num != 0)
				{
					Class0.idevice_free(device);
					Console.WriteLine("ERROR: Could not start diagnostics relay service");
				}
				else
				{
					Class0.Struct0 @struct = (Class0.Struct0)Marshal.PtrToStructure(service, typeof(Class0.Struct0));
					if (num == 0 && service != IntPtr.Zero && @struct.ushort_0 > 0)
					{
						IntPtr client2 = IntPtr.Zero;
						if (Class0.diagnostics_relay_client_new(device, service, out client2) != 0)
						{
							Console.WriteLine("ERROR: Could not connect to diagnostics_relay!");
						}
						else
						{
							if (Class0.diagnostics_relay_query_mobilegestalt(client2, intPtr, out resultPlist) == Class0.Enum0.const_0)
							{
								if (resultPlist != IntPtr.Zero)
								{
									Class0.plist_to_xml(resultPlist, out var xml, out var length);
									byte[] array = new byte[length];
									Marshal.Copy(xml, array, 0, length);
									result = Regex.Replace(Encoding.UTF8.GetString(array).Split(new string[1] { "<data>" }, StringSplitOptions.None)[1].Split(new string[1] { "</data>" }, StringSplitOptions.None)[0], "\\s+", "");
								}
								Class0.diagnostics_relay_goodbye(client2);
								Class0.diagnostics_relay_client_free(client2);
								if (service != IntPtr.Zero)
								{
									Class0.lockdownd_service_descriptor_free(service);
									service = IntPtr.Zero;
								}
								Class0.idevice_free(device);
								return result;
							}
							Console.WriteLine("ERROR: Unable to query mobilegestalt keys.");
						}
					}
					else
					{
						Console.WriteLine("ERROR: Could not start diagnostics service!");
					}
				}
			}
		}
		if (resultPlist != IntPtr.Zero)
		{
			Class0.plist_free(resultPlist);
		}
		if (intPtr != IntPtr.Zero)
		{
			Class0.plist_free(intPtr);
		}
		return result;
	}
}
