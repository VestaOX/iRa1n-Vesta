using System;
using System.Runtime.InteropServices;

namespace ns0;

internal class Class0
{
	public enum Enum0
	{
		const_0 = 0,
		const_1 = -1,
		const_2 = -2,
		const_3 = -3,
		const_4 = -4,
		const_5 = -256
	}

	public struct Struct0
	{
		public ushort ushort_0;

		public char char_0;
	}

	private const CallingConvention callingConvention_0 = CallingConvention.Winapi;

	private const string string_0 = "imobiledevice";

	private const string string_1 = "plist";

	[DllImport("plist")]
	public static extern IntPtr plist_new_array();

	[DllImport("plist")]
	public static extern void plist_array_append_item(IntPtr node, IntPtr item);

	[DllImport("plist")]
	public static extern IntPtr plist_new_string(string val);

	[DllImport("plist")]
	public static extern void plist_free(IntPtr plist);

	[DllImport("plist", CallingConvention = CallingConvention.Cdecl)]
	public static extern void plist_to_xml(IntPtr plist, out IntPtr xml, out int length);

	[DllImport("imobiledevice")]
	public static extern int idevice_new_with_options(out IntPtr device, string udid, int options);

	[DllImport("imobiledevice")]
	public static extern Enum0 diagnostics_relay_client_new(IntPtr device, IntPtr lockdownSvc, out IntPtr client);

	[DllImport("imobiledevice")]
	public static extern Enum0 diagnostics_relay_query_mobilegestalt(IntPtr client, IntPtr keys, out IntPtr resultPlist);

	[DllImport("imobiledevice")]
	public static extern Enum0 diagnostics_relay_goodbye(IntPtr client);

	[DllImport("imobiledevice")]
	public static extern Enum0 diagnostics_relay_client_free(IntPtr client);

	[DllImport("imobiledevice")]
	public static extern int lockdownd_client_new_with_handshake(IntPtr device, out IntPtr client, string label);

	[DllImport("imobiledevice")]
	public static extern int lockdownd_start_service(IntPtr client, string identifier, out IntPtr service);

	[DllImport("imobiledevice")]
	public static extern int lockdownd_client_free(IntPtr client);

	[DllImport("imobiledevice")]
	public static extern int lockdownd_service_descriptor_free(IntPtr service);

	[DllImport("imobiledevice")]
	public static extern int idevice_free(IntPtr deviceHandle);
}
