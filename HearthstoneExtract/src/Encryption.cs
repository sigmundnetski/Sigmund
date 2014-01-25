using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Encryption
{
    private ICryptoTransform DecryptorTransform;
    private ICryptoTransform EncryptorTransform;
    private static readonly byte[] Key = new byte[] { 
        0x4a, 0xd9, 0x13, 0x53, 0x18, 0x1a, 0x4d, 0x2d, 0x6f, 0xb8, 0x1b, 0xa2, 0x2d, 0x70, 0xde, 0xb1, 
        0xf1, 0x18, 0xaf, 0x90, 0xad, 0xfe, 0xc4, 0x1d, 0x13, 0x1a, 0x11, 0x6a, 0x83, 0x36, 0x35, 0x49
     };
    private UTF8Encoding UTFEncoder;
    private static readonly byte[] Vector = new byte[] { 0x92, 0x63, 0xbf, 0x6f, 0xb2, 3, 0xb5, 0xcc, 4, 190, 200, 0x70, 0x4f, 0x20, 0x22, 0xc7 };

    public Encryption()
    {
        RijndaelManaged managed = new RijndaelManaged();
        this.EncryptorTransform = managed.CreateEncryptor(Key, Vector);
        this.DecryptorTransform = managed.CreateDecryptor(Key, Vector);
        this.UTFEncoder = new UTF8Encoding();
    }

    public string ByteArrToString(byte[] byteArr)
    {
        string str = string.Empty;
        for (int i = 0; i <= byteArr.GetUpperBound(0); i++)
        {
            byte num = byteArr[i];
            if (num < 10)
            {
                str = str + "00" + num.ToString();
            }
            else if (num < 100)
            {
                str = str + "0" + num.ToString();
            }
            else
            {
                str = str + num.ToString();
            }
        }
        return str;
    }

    public string Decrypt(byte[] EncryptedValue)
    {
        MemoryStream stream = new MemoryStream();
        CryptoStream stream2 = new CryptoStream(stream, this.DecryptorTransform, CryptoStreamMode.Write);
        stream2.Write(EncryptedValue, 0, EncryptedValue.Length);
        stream2.FlushFinalBlock();
        stream.Position = 0L;
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        stream.Close();
        return this.UTFEncoder.GetString(buffer);
    }

    public string DecryptString(string EncryptedString)
    {
        return this.Decrypt(this.StrToByteArray(EncryptedString));
    }

    public byte[] Encrypt(string TextValue)
    {
        byte[] bytes = this.UTFEncoder.GetBytes(TextValue);
        MemoryStream stream = new MemoryStream();
        CryptoStream stream2 = new CryptoStream(stream, this.EncryptorTransform, CryptoStreamMode.Write);
        stream2.Write(bytes, 0, bytes.Length);
        stream2.FlushFinalBlock();
        stream.Position = 0L;
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        stream2.Close();
        stream.Close();
        return buffer;
    }

    public string EncryptToString(string TextValue)
    {
        return this.ByteArrToString(this.Encrypt(TextValue));
    }

    public byte[] StrToByteArray(string str)
    {
        if (str.Length == 0)
        {
            throw new Exception("Invalid string value in StrToByteArray");
        }
        byte[] buffer = new byte[str.Length / 3];
        int startIndex = 0;
        int num3 = 0;
        do
        {
            byte num = byte.Parse(str.Substring(startIndex, 3));
            buffer[num3++] = num;
            startIndex += 3;
        }
        while (startIndex < str.Length);
        return buffer;
    }
}

