using System;
using System.Runtime.InteropServices;

namespace ns2;

public class GClass0
{
	public enum GEnum0
	{
		const_0 = 4736,
		const_1 = 4737,
		const_2 = 4738,
		const_3 = 4739,
		const_4 = 4642,
		const_5 = 4647
	}

	public enum GEnum1
	{
		const_0 = 0,
		const_1 = -1,
		const_2 = -2,
		const_3 = -3,
		const_4 = -4,
		const_5 = -5,
		const_6 = -6,
		const_7 = -7,
		const_8 = -8,
		const_9 = -9,
		const_10 = -10,
		const_11 = -11,
		const_12 = -254,
		const_13 = -255
	}

	public enum GEnum2
	{
		const_0 = 1,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5
	}

	public struct GStruct0
	{
		public int int_0;

		public IntPtr intptr_0;

		public double double_0;

		public GEnum2 genum2_0;
	}

	public struct GStruct1
	{
		public string string_0;

		public string string_1;

		public uint uint_0;

		public uint uint_1;

		public string string_2;
	}

	public struct GStruct2
	{
		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public uint uint_4;

		public ulong ulong_0;

		public uint uint_5;

		public string string_0;

		public string string_1;

		public string string_2;

		public string string_3;
	}

	public enum GEnum3
	{
		const_0 = 1,
		const_1
	}

	public struct GStruct3
	{
		private GEnum3 genum3_0;

		private GEnum0 genum0_0;

		private GStruct2 gstruct2_0;
	}

	public struct GStruct4
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public uint uint_0;

		public GStruct2 gstruct2_0;
	}

	public struct GStruct5
	{
		public GStruct4 gstruct4_0;
	}

	private const CallingConvention callingConvention_0 = CallingConvention.Winapi;

	private const string string_0 = "libira1n-1.0.dll";

	[DllImport("libira1n-1.0.dll")]
	public static extern void irecv_set_debug_level(int level);

	[DllImport("libira1n-1.0.dll")]
	public static extern void ira1n_checkm8_timeout(int timeout);

	[DllImport("libira1n-1.0.dll")]
	public static extern bool ira1n_checkm8(out IntPtr handle);

	[DllImport("libira1n-1.0.dll")]
	public static extern string irecv_strerror(GEnum1 error);

	[DllImport("libira1n-1.0.dll")]
	[Obsolete("deprecated: libirecovery has constructor now", true)]
	public static extern void irecv_init(IntPtr a);

	[DllImport("libira1n-1.0.dll")]
	[Obsolete("deprecated: libirecovery has constructor now", true)]
	public static extern void irecv_exit(IntPtr a);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_open_with_ecid(out IntPtr client, ulong ecid);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_open_with_ecid_and_attempts(out IntPtr pclient, ulong ecid, int attempts);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_reset(IntPtr client);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_close(IntPtr client);

	[DllImport("libira1n-1.0.dll")]
	public static extern IntPtr irecv_reconnect(IntPtr client, int initial_pause);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_receive(IntPtr client);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_execute_script(IntPtr client, string script);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_reset_counters(IntPtr client);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_finish_transfer(IntPtr client);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_trigger_limera1n_exploit(IntPtr client);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_usb_set_configuration(IntPtr client, int configuration);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_usb_set_interface(IntPtr client, int usb_interface, int usb_alt_interface);

	[DllImport("libira1n-1.0.dll")]
	public static extern int irecv_usb_control_transfer(IntPtr client, byte bmRequestType, byte bRequest, ushort wValue, ushort wIndex, byte[] data, ushort wLength, uint timeout);

	[DllImport("libira1n-1.0.dll")]
	public static extern int irecv_usb_bulk_transfer(IntPtr client, byte endpoint, byte[] data, int length, ref int transferred, uint timeout);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_device_event_subscribe(out IntPtr context, IntPtr callback, IntPtr user_data);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_device_event_unsubscribe(IntPtr context);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_event_subscribe(IntPtr client, GEnum2 type, IntPtr callback, IntPtr user_data);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_event_unsubscribe(IntPtr client, GEnum2 type);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_send_file(IntPtr client, string filename, int dfu_notify_finished);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_send_command(IntPtr client, string command);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_send_command_breq(IntPtr client, string command, byte b_request);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_send_buffer(IntPtr client, byte[] buffer, ulong length, int dfu_notify_finished);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_recv_buffer(IntPtr client, byte[] buffer, ulong length);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_saveenv(IntPtr client);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_getenv(IntPtr client, string variable, out IntPtr value);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_setenv(IntPtr client, string variable, string value);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_setenv_np(IntPtr client, string variable, string value);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_reboot(IntPtr client);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_getret(IntPtr client, ref uint value);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_get_mode(IntPtr client, ref int mode);

	[DllImport("libira1n-1.0.dll")]
	public static extern GStruct1 irecv_devices_get_all(IntPtr a);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_devices_get_device_by_client(IntPtr client, out GStruct1 device);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_devices_get_device_by_product_type(string product_type, out GStruct1 device);

	[DllImport("libira1n-1.0.dll")]
	public static extern GEnum1 irecv_devices_get_device_by_hardware_model(string hardware_model, out GStruct1 device);
}
