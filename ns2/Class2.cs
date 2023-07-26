using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using iMobileDevice;
using iMobileDevice.DiagnosticsRelay;
using iMobileDevice.Lockdown;
using iMobileDevice.Usbmuxd;
using ns1;

namespace ns2;

internal class Class2
{
	private static IUsbmuxdApi iusbmuxdApi_0 = LibiMobileDevice.Instance.Usbmuxd;

	private static IDiagnosticsRelayApi idiagnosticsRelayApi_0 = LibiMobileDevice.Instance.DiagnosticsRelay;

	private static ILockdownApi ilockdownApi_0 = LibiMobileDevice.Instance.Lockdown;

	private static readonly UsbmuxdEventCallBack usbmuxdEventCallBack_0 = smethod_0();

	public static bool bool_0 = false;

	private static Socket socket_0;

	private static Form1 form1_0;

	public void method_0(Form1 main)
	{
		try
		{
			form1_0 = main;
			bool_0 = false;
			socket_0 = null;
			socket_0 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket_0.Bind(new IPEndPoint(IPAddress.Loopback, 1337));
			socket_0.Listen(100);
			method_1();
		}
		catch
		{
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
			int @event = devEvent.@event;
			if (@event == 1)
			{
				smethod_1(devEvent.device.udid, devEvent.device.handle);
			}
		};
	}

	private static void smethod_1(string newUdid, uint handle)
	{
		int num = iusbmuxdApi_0.usbmuxd_connect(handle, 1337);
		if (num == 0)
		{
			if (form1_0 != null)
			{
				form1_0.method_9(100, "Failed to upload bootstrap.. (0x1)");
			}
			bool_0 = true;
		}
		else
		{
			smethod_2(num);
		}
	}

	private static void smethod_2(int connection)
	{
		Task.Run(delegate
		{
			while (!bool_0)
			{
				uint recvBytes = 0u;
				byte[] array = new byte[1];
				iusbmuxdApi_0.usbmuxd_recv(connection, array, 1u, ref recvBytes);
				uint recvBytes2 = 0u;
				byte[] data = new byte[8];
				iusbmuxdApi_0.usbmuxd_recv(connection, data, 8u, ref recvBytes2);
				string text = BitConverter.ToString(array);
				if (recvBytes != 0 || recvBytes2 != 0)
				{
					if (form1_0 != null)
					{
						form1_0.method_9(90, "Uploading bootstrap..");
					}
					if (text == "42")
					{
						byte[] byte_ = Class1.Byte_0;
						uint sentBytes = 0u;
						int num = iusbmuxdApi_0.usbmuxd_send(connection, byte_, (uint)byte_.Length, ref sentBytes);
						if (sentBytes < byte_.Length && num != 0)
						{
							if (form1_0 != null)
							{
								form1_0.method_9(100, "Failed to upload bootstrap.. (0x2)");
							}
							bool_0 = true;
							break;
						}
						if (form1_0 != null)
						{
							form1_0.method_9(95, "Bootstrap uploaded..");
						}
					}
					iusbmuxdApi_0.usbmuxd_disconnect(connection);
					iusbmuxdApi_0.usbmuxd_unsubscribe();
					socket_0.Close();
					if (form1_0 != null)
					{
						form1_0.method_9(100, "All Done");
					}
					bool_0 = true;
					break;
				}
			}
		});
	}
}
