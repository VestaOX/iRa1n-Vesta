using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ns2;

public static class GClass1
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GStruct6
	{
		public byte byte_0;

		public byte byte_1;

		public ushort ushort_0;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public ushort ushort_1;

		public ushort ushort_2;

		public ushort ushort_3;

		public byte byte_6;

		public byte byte_7;

		public byte byte_8;

		public byte byte_9;
	}

	public struct GStruct7
	{
		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public ushort ushort_0;

		public byte byte_4;

		public byte byte_5;

		public byte byte_6;

		public unsafe byte* pByte_0;

		public int int_0;
	}

	public struct GStruct8
	{
		public IntPtr intptr_0;

		public int int_0;

		public unsafe IntPtr* pIntPtr_0;

		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public IntPtr intptr_1;

		public unsafe IntPtr* pIntPtr_1;

		public ulong ulong_0;

		public byte byte_3;
	}

	public struct GStruct9
	{
		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public byte byte_6;

		public byte byte_7;

		public byte byte_8;

		public unsafe GStruct7* pGstruct7_0;

		public unsafe byte* pByte_0;

		public int int_0;
	}

	public struct GStruct10
	{
		public unsafe GStruct9* pGstruct9_0;

		public int int_0;
	}

	public struct GStruct11
	{
		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public byte byte_6;

		public byte byte_7;

		public unsafe GStruct10* pGstruct10_0;

		public unsafe byte* pByte_0;

		public int int_0;
	}

	public struct GStruct12
	{
		public IntPtr intptr_0;

		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public uint uint_0;

		public byte byte_3;

		public int int_0;

		public int int_1;

		public IntPtr intptr_1;

		public IntPtr intptr_2;

		public IntPtr intptr_3;

		public int int_2;

		public IntPtr intptr_4;
	}

	public struct GStruct13
	{
		public byte byte_0;

		public byte byte_1;

		public ushort ushort_0;

		public ushort ushort_1;

		public ushort ushort_2;
	}

	private const CallingConvention callingConvention_0 = CallingConvention.Winapi;

	private const string string_0 = "libusb-1.0.dll";

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_init(out IntPtr ctx);

	[DllImport("libusb-1.0.dll")]
	public static extern void libusb_exit(IntPtr ctx);

	[DllImport("libusb-1.0.dll")]
	public static extern void libusb_set_debug(IntPtr ctx, int level);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_handle_events(IntPtr ctx);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_set_option(IntPtr context, int option);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern byte* libusb_error_name(int errcode);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern int libusb_get_device_list(IntPtr ctx, out GStruct8** list);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_handle_events_completed(IntPtr pContext, IntPtr completed);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern void libusb_free_device_list(GStruct8** list, int unref_devices);

	[DllImport("libusb-1.0.dll")]
	public static extern IntPtr libusb_ref_device(IntPtr dev);

	[DllImport("libusb-1.0.dll")]
	public static extern void libusb_unref_device(IntPtr dev);

	[DllImport("libusb-1.0.dll")]
	private static extern int libusb_get_configuration(IntPtr dev, out int config);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern int libusb_get_device_descriptor(GStruct8* dev, out GStruct6 desc);

	[DllImport("libusb-1.0.dll")]
	private unsafe static extern int libusb_get_active_config_descriptor(IntPtr dev, GStruct11** config);

	[DllImport("libusb-1.0.dll")]
	private unsafe static extern int libusb_get_config_descriptor(IntPtr dev, byte config_index, GStruct11** config);

	[DllImport("libusb-1.0.dll")]
	private unsafe static extern int libusb_get_config_descriptor_by_value(IntPtr dev, byte bConfigurationValue, GStruct11** config);

	[DllImport("libusb-1.0.dll")]
	private unsafe static extern void libusb_free_config_descriptor(GStruct11* config);

	[DllImport("libusb-1.0.dll")]
	public static extern byte libusb_get_bus_number(IntPtr dev);

	[DllImport("libusb-1.0.dll")]
	public static extern byte libusb_get_device_address(IntPtr dev);

	[DllImport("libusb-1.0.dll")]
	private static extern int libusb_get_device_speed(IntPtr dev);

	[DllImport("libusb-1.0.dll")]
	private static extern int libusb_get_max_packet_size(IntPtr dev, byte endpoint);

	[DllImport("libusb-1.0.dll")]
	private static extern int libusb_get_max_iso_packet_size(IntPtr dev, byte endpoint);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern int libusb_open(GStruct8* dev, out IntPtr handle);

	[DllImport("libusb-1.0.dll")]
	public static extern void libusb_close(IntPtr dev_handle);

	[DllImport("libusb-1.0.dll")]
	public static extern IntPtr libusb_get_device(IntPtr dev_handle);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_set_configuration(IntPtr dev, int configuration);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_claim_interface(IntPtr dev, int interface_number);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_release_interface(IntPtr dev, int interface_number);

	[DllImport("libusb-1.0.dll")]
	public static extern IntPtr libusb_open_device_with_vid_pid(IntPtr ctx, ushort vendor_id, ushort product_id);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_set_interface_alt_setting(IntPtr dev, int interface_number, int alternate_setting);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_clear_halt(IntPtr dev, byte endpoint);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_reset_device(IntPtr dev);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_control_transfer(IntPtr dev_handle, byte request_type, byte bRequest, ushort wValue, ushort wIndex, byte[] data, ushort wLength, uint timeout);

	[DllImport("libusb-1.0.dll", EntryPoint = "libusb_control_transfer")]
	public static extern int libusb_control_transfer_1(IntPtr dev_handle, byte request_type, byte bRequest, ushort wValue, ushort wIndex, IntPtr data, ushort wLength, uint timeout);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern int libusb_bulk_transfer(IntPtr dev_handle, byte endpoint, byte* data, int length, out int actual_length, uint timeout);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern int libusb_interrupt_transfer(IntPtr dev_handle, byte endpoint, byte* data, int length, out int actual_length, uint timeout);

	[DllImport("libusb-1.0.dll")]
	public static extern void libusb_fill_control_setup(byte[] buffer, byte request_type, byte bRequest, ushort wValue, ushort wIndex, ushort wLength);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern void libusb_fill_control_transfer(GStruct12* transfer, IntPtr dev_handle, byte[] buffer, IntPtr callback, IntPtr user_data, uint timeout);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern GStruct12* libusb_alloc_transfer(int isoPackeets);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern int libusb_submit_transfer(GStruct12* transfer);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern int libusb_cancel_transfer(GStruct12* transfer);

	[DllImport("libusb-1.0.dll")]
	public unsafe static extern void libusb_free_transfer(GStruct12* transfer);

	[DllImport("libusb-1.0.dll")]
	public static extern int libusb_get_string_descriptor_ascii(IntPtr dev, byte desc_index, [MarshalAs(UnmanagedType.LPStr)] StringBuilder data, int length);
}
