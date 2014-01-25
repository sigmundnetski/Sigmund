using System;
using System.Runtime.InteropServices;
using System.Text;

public class DLLUtils
{
    [DllImport("kernel32.dll")]
    public static extern bool FreeLibrary(IntPtr module);
    public static void FreeNativeUtf8(IntPtr nativeString)
    {
        if (nativeString != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(nativeString);
        }
    }

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetProcAddress(IntPtr module, string funcName);
    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string filename);
    public static int NativeUtf8ByteLen(IntPtr nativeString)
    {
        if (nativeString == IntPtr.Zero)
        {
            return 0;
        }
        int ofs = 0;
        while (Marshal.ReadByte(nativeString, ofs) != 0)
        {
            ofs++;
        }
        return ofs;
    }

    public static IntPtr NativeUtf8FromString(string managedString)
    {
        if (managedString == null)
        {
            return IntPtr.Zero;
        }
        int cb = 1 + Encoding.UTF8.GetByteCount(managedString);
        byte[] bytes = new byte[cb];
        Encoding.UTF8.GetBytes(managedString, 0, managedString.Length, bytes, 0);
        IntPtr destination = Marshal.AllocHGlobal(cb);
        Marshal.Copy(bytes, 0, destination, cb);
        return destination;
    }

    public static string StringFromNativeUtf8(IntPtr nativeString)
    {
        if (nativeString == IntPtr.Zero)
        {
            return null;
        }
        int length = NativeUtf8ByteLen(nativeString);
        if (length == 0)
        {
            return null;
        }
        byte[] destination = new byte[length];
        Marshal.Copy(nativeString, destination, 0, length);
        return Encoding.UTF8.GetString(destination);
    }
}

