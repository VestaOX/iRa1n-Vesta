using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ns2;

internal class Class11
{
	public static ushort ushort_0 = 1452;

	public static ushort ushort_1 = 4647;

	public static ushort ushort_2 = 4920;

	private static IntPtr intptr_0;

	private IntPtr intptr_1;

	private unsafe GClass1.GStruct8* pGstruct8_0;

	private string string_0;

	private GClass1.GStruct6 gstruct6_0;

	public string String_0 => string_0;

	public unsafe int method_0(ushort mode, bool srnm, bool nousbdk = true)
	{
		if (GClass1.libusb_init(out intptr_0) < 0)
		{
			return -1;
		}
		if (nousbdk && GClass1.libusb_set_option(intptr_0, 1) < 0)
		{
			return -1;
		}
		int num = 0;
		num = GClass1.libusb_get_device_list(intptr_0, out var list);
		pGstruct8_0 = method_1(list, num, mode);
		if (pGstruct8_0 == null)
		{
			GClass1.libusb_exit(intptr_0);
			return -1;
		}
		if (GClass1.libusb_open(pGstruct8_0, out intptr_1) < 0)
		{
			GClass1.libusb_exit(intptr_0);
			return -662;
		}
		if (GClass1.libusb_claim_interface(intptr_1, 0) < 0)
		{
			GClass1.libusb_exit(intptr_0);
			return -662;
		}
		if (srnm)
		{
			StringBuilder stringBuilder = new StringBuilder(2048);
			if (GClass1.libusb_get_string_descriptor_ascii(intptr_1, gstruct6_0.byte_8, stringBuilder, stringBuilder.Capacity) < 0)
			{
				return -664;
			}
			string_0 = stringBuilder.ToString();
		}
		return 0;
	}

	private unsafe GClass1.GStruct8* method_1(GClass1.GStruct8** devs, int count, ushort stage)
	{
		int num = 0;
		while (true)
		{
			if (num < count)
			{
				if (GClass1.libusb_get_device_descriptor(devs[num], out var desc) < 0)
				{
					break;
				}
				if (desc.ushort_2 != stage)
				{
					num++;
					continue;
				}
				gstruct6_0 = desc;
				return devs[num];
			}
			return null;
		}
		return null;
	}

	public int method_2(uint time, ushort stage, bool srnm, bool nousbdk = true)
	{
		int num = 0;
		while (true)
		{
			if (num < time)
			{
				if (intptr_1 != IntPtr.Zero)
				{
					method_4();
				}
				if (method_0(stage, srnm, nousbdk) == 0)
				{
					break;
				}
				Thread.Sleep(500);
				num++;
				continue;
			}
			intptr_0 = IntPtr.Zero;
			intptr_1 = IntPtr.Zero;
			return -1;
		}
		return 0;
	}

	public int method_3()
	{
		return GClass1.libusb_reset_device(intptr_1);
	}

	public unsafe void method_4()
	{
		GClass1.libusb_release_interface(intptr_1, 0);
		GClass1.libusb_close(intptr_1);
		GClass1.libusb_exit(intptr_0);
		intptr_1 = IntPtr.Zero;
		pGstruct8_0 = null;
		intptr_0 = IntPtr.Zero;
	}

	public int method_5(byte bm_request_type, byte b_request, ushort w_value, ushort w_index, byte[] data, ushort w_length)
	{
		return GClass1.libusb_control_transfer(intptr_1, bm_request_type, b_request, w_value, w_index, data, w_length, 0u);
	}

	public unsafe int method_6(byte bmRequestType, byte bRequest, ushort wValue, ushort wIndex, byte[] data, ushort fsfs)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(bmRequestType);
		binaryWriter.Write(bRequest);
		binaryWriter.Write(wValue);
		binaryWriter.Write(wIndex);
		binaryWriter.Write(fsfs);
		binaryWriter.Write(data);
		GCHandle gCHandle = GCHandle.Alloc(memoryStream.ToArray(), GCHandleType.Pinned);
		IntPtr intptr_ = gCHandle.AddrOfPinnedObject();
		GClass1.GStruct12* ptr = GClass1.libusb_alloc_transfer(0);
		ptr->intptr_0 = intptr_1;
		ptr->byte_1 = 0;
		ptr->byte_2 = 0;
		ptr->uint_0 = 0u;
		ptr->intptr_3 = intptr_;
		ptr->int_0 = 8 + fsfs;
		ptr->intptr_2 = IntPtr.Zero;
		ptr->intptr_1 = IntPtr.Zero;
		ptr->int_2 = 0;
		ptr->intptr_4 = IntPtr.Zero;
		int num = GClass1.libusb_submit_transfer(ptr);
		if (num != 0)
		{
			throw new Exception($"libusb_submit_transfer failed: {num}");
		}
		num = GClass1.libusb_cancel_transfer(ptr);
		if (num != 0)
		{
			throw new Exception($"libusb_cancel_transfer failed: {num}");
		}
		GClass1.libusb_handle_events(intptr_0);
		while (ptr->byte_3 != 3)
		{
		}
		int int_ = ptr->int_1;
		gCHandle.Free();
		return int_;
	}

	public unsafe int method_7(byte bmRequestType, byte bRequest, ushort wValue, ushort wIndex, byte[] data, ushort fsfddf)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(bmRequestType);
		binaryWriter.Write(bRequest);
		binaryWriter.Write(wValue);
		binaryWriter.Write(wIndex);
		binaryWriter.Write(fsfddf);
		binaryWriter.Write(data);
		GCHandle gCHandle = GCHandle.Alloc(memoryStream.ToArray(), GCHandleType.Pinned);
		IntPtr intptr_ = gCHandle.AddrOfPinnedObject();
		GClass1.GStruct12* ptr = GClass1.libusb_alloc_transfer(0);
		ptr->intptr_0 = intptr_1;
		ptr->byte_1 = 0;
		ptr->byte_2 = 0;
		ptr->uint_0 = 0u;
		ptr->intptr_3 = intptr_;
		ptr->int_0 = 8 + fsfddf;
		ptr->intptr_2 = IntPtr.Zero;
		ptr->intptr_1 = IntPtr.Zero;
		ptr->int_2 = 0;
		ptr->intptr_4 = IntPtr.Zero;
		int num = GClass1.libusb_submit_transfer(ptr);
		if (num != 0)
		{
			throw new Exception($"libusb_submit_transfer failed: {num}");
		}
		num = GClass1.libusb_cancel_transfer(ptr);
		if (num != 0)
		{
			throw new Exception($"libusb_cancel_transfer failed: {num}");
		}
		GClass1.libusb_handle_events(intptr_0);
		int int_ = ptr->int_1;
		gCHandle.Free();
		return int_;
	}

	public int method_8(byte bm_request_type, byte b_request, ushort w_value, ushort w_index, byte[] data, ushort w_length, uint time)
	{
		return GClass1.libusb_control_transfer(intptr_1, bm_request_type, b_request, w_value, w_index, data, w_length, time);
	}

	public int method_9(Class4.Class5 payload)
	{
		int num = 0;
		while (true)
		{
			if (num < payload.ushort_2)
			{
				int num2 = 2048;
				if (2048 + num > payload.ushort_2)
				{
					num2 = payload.ushort_2 - num;
				}
				byte[] array = new byte[num2];
				Array.Copy(payload.byte_2, num, array, 0, num2);
				if (method_5(33, 1, 0, 0, array, (ushort)array.Length) != num2)
				{
					break;
				}
				num += 2048;
				continue;
			}
			Class10.smethod_1(1000L);
			method_8(33, 4, 0, 0, null, 0, 0u);
			Class10.smethod_1(1000L);
			return 0;
		}
		return -1;
	}

	public int method_10(Class4.Class5 payload_)
	{
		byte[] data = new byte[8];
		byte[] byte_ = payload_.byte_3;
		method_5(64, 64, 1000, 500, null, 0);
		int num = 0;
		while (true)
		{
			if (num < byte_.Length)
			{
				int num2 = 2048;
				if (2048 + num > byte_.Length)
				{
					num2 = byte_.Length - num;
				}
				byte[] array = new byte[num2];
				Array.Copy(byte_, num, array, 0, num2);
				if (method_5(33, 1, 0, 0, array, (ushort)array.Length) != num2)
				{
					break;
				}
				num += 2048;
				continue;
			}
			Class10.smethod_1(10000L);
			method_5(33, 1, 0, 0, null, 0);
			method_5(161, 3, 0, 0, data, 8);
			method_5(161, 3, 0, 0, data, 8);
			method_5(161, 3, 0, 0, data, 8);
			Class10.smethod_1(10000L);
			return 0;
		}
		return -1;
	}

	public int method_11(Class4.Class5 payload)
	{
		method_3();
		method_4();
		int num = 0;
		while (true)
		{
			if (method_2(15u, ushort_2, srnm: false, nousbdk: false) != 0)
			{
				if (num == 15000)
				{
					break;
				}
				Thread.Sleep(500);
				num += 500;
				continue;
			}
			Class10.smethod_1(10000L);
			if (method_10(payload) != 0)
			{
				return -1;
			}
			method_3();
			method_4();
			return 0;
		}
		return -1;
	}
}
