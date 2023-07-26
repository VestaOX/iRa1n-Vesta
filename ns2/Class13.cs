using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace ns2;

internal class Class13
{
	internal static string string_0 = "";

	internal static string string_1 = "";

	internal static string string_2 = "";

	internal static string string_3 = "";

	internal static string string_4 = "";

	internal static string string_5 = "";

	internal static string string_6 = "";

	internal static string string_7 = "";

	private static void smethod_0(int n)
	{
		Thread.Sleep(1000 * n);
	}

	public static string smethod_1(string huuhiehfuegz)
	{
		byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes("FTY3OTAxSjk3UjMwMjcyNDU4NjkxOTg8"));
		byte[] iV = new byte[16];
		Aes aes = Aes.Create();
		aes.Mode = CipherMode.CBC;
		aes.Key = key;
		aes.IV = iV;
		MemoryStream memoryStream = new MemoryStream();
		ICryptoTransform transform = aes.CreateEncryptor();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		byte[] bytes = Encoding.ASCII.GetBytes(huuhiehfuegz);
		cryptoStream.Write(bytes, 0, bytes.Length);
		cryptoStream.FlushFinalBlock();
		byte[] array = memoryStream.ToArray();
		memoryStream.Close();
		cryptoStream.Close();
		return Convert.ToBase64String(array, 0, array.Length);
	}

	internal static string smethod_2(string jgiohzegihezuihu)
	{
		byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes("FTY3OTAxSjk3UjMwMjcyNDU4NjkxOTg8"));
		byte[] iV = new byte[16];
		Aes aes = Aes.Create();
		aes.Mode = CipherMode.CBC;
		aes.Key = key;
		aes.IV = iV;
		MemoryStream memoryStream = new MemoryStream();
		ICryptoTransform transform = aes.CreateDecryptor();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		string empty = string.Empty;
		try
		{
			byte[] array = Convert.FromBase64String(jgiohzegihezuihu);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			byte[] array2 = memoryStream.ToArray();
			return Encoding.ASCII.GetString(array2, 0, array2.Length);
		}
		finally
		{
			memoryStream.Close();
			cryptoStream.Close();
		}
	}

	internal static IntPtr smethod_3()
	{
		GClass0.irecv_set_debug_level(0);
		IntPtr client = IntPtr.Zero;
		for (int i = 0; i <= 10; i++)
		{
			GClass0.GEnum1 gEnum = GClass0.irecv_open_with_ecid(out client, ulong.Parse(string_0));
			switch (gEnum)
			{
			default:
				smethod_0(1);
				if (i != 10)
				{
					continue;
				}
				break;
			case GClass0.GEnum1.const_12:
				Console.WriteLine("ERROR: " + GClass0.irecv_strerror(gEnum));
				break;
			case GClass0.GEnum1.const_0:
				break;
			}
			break;
		}
		return client;
	}

	internal static byte[] smethod_4(byte[] jgiohzegihezuihu)
	{
		byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes("FTY3OTAxSjk3UjMwMjcyNDU4NjkxOTg8"));
		byte[] iV = new byte[16];
		Aes aes = Aes.Create();
		aes.Mode = CipherMode.CBC;
		aes.Key = key;
		aes.IV = iV;
		MemoryStream memoryStream = new MemoryStream();
		ICryptoTransform transform = aes.CreateDecryptor();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		try
		{
			cryptoStream.Write(jgiohzegihezuihu, 0, jgiohzegihezuihu.Length);
			cryptoStream.FlushFinalBlock();
			return memoryStream.ToArray();
		}
		finally
		{
			memoryStream.Close();
			cryptoStream.Close();
		}
	}
}
