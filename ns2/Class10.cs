using System;
using System.Runtime.InteropServices;

namespace ns2;

internal class Class10
{
	[StructLayout(LayoutKind.Explicit)]
	private struct Struct1
	{
		[FieldOffset(0)]
		public int int_0;

		[FieldOffset(4)]
		public int int_1;

		[FieldOffset(0)]
		public long long_0;
	}

	private delegate void Delegate0();

	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	internal struct Struct2
	{
		[FieldOffset(0)]
		public readonly ushort ushort_0;

		[FieldOffset(0)]
		public readonly byte byte_0;

		[FieldOffset(1)]
		public readonly byte byte_1;

		public Struct2(ushort x)
		{
			ushort_0 = 0;
			byte_1 = (byte)(x >> 8);
			byte_0 = (byte)(x & 0xFFu);
		}
	}

	[DllImport("kernel32.dll")]
	private static extern IntPtr CreateWaitableTimer(IntPtr lpTimerAttributes, bool bManualReset, string lpTimerName);

	[DllImport("kernel32.dll")]
	private static extern bool SetWaitableTimer(IntPtr hTimer, [In] ref Struct1 pDueTime, int lPeriod, Delegate0 pfnCompletionRoutine, IntPtr lpArgToCompletionRoutine, bool fResume);

	[DllImport("kernel32.dll")]
	private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

	[DllImport("kernel32.dll")]
	private static extern bool CloseHandle(IntPtr hObject);

	private static void smethod_0(long sleepTime)
	{
		IntPtr intPtr = CreateWaitableTimer(IntPtr.Zero, bManualReset: true, null);
		Struct1 @struct = default(Struct1);
		@struct.long_0 = sleepTime;
		Struct1 pDueTime = @struct;
		SetWaitableTimer(intPtr, ref pDueTime, 0, null, IntPtr.Zero, fResume: false);
		WaitForSingleObject(intPtr, uint.MaxValue);
		CloseHandle(intPtr);
	}

	public static void smethod_1(long microsec)
	{
		smethod_0(-(10 * Math.Abs(microsec)));
	}

	public static void smethod_2(long nanosec)
	{
		smethod_0(-(Math.Abs(nanosec) / 100));
	}

	public static ushort smethod_3(ushort swapValue)
	{
		return new Struct2(swapValue).ushort_0;
	}
}
