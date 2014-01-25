using System;
using System.IO;
using System.Security;
using System.Text;
using UnityEngine;

public class Watermark : MonoBehaviour
{
    private const string blankWatermark = "0000000000000000000000000000000000000000\r\n";
    private static string contents_;
    private static Encoding encoding_ = Encoding.UTF8;
    private static bool failedToLoad_;
    private const string watermarkFilePath_ = "Data/cache/d/da39a3ee5e6b4b0d3255bfef95601890afd80709";

    public static bool create()
    {
        object[] args = new object[] { Environment.UserName, Environment.MachineName, DateTime.UtcNow };
        return write("{0}@{1} {2} UTC", args);
    }

    private static string read()
    {
        try
        {
            Encryption encryption = new Encryption();
            return encryption.DecryptString(System.IO.File.ReadAllText("Data/cache/d/da39a3ee5e6b4b0d3255bfef95601890afd80709", encoding_));
        }
        catch (SecurityException)
        {
            failedToLoad_ = true;
        }
        catch (UnauthorizedAccessException)
        {
            failedToLoad_ = true;
        }
        catch (FileNotFoundException)
        {
            failedToLoad_ = true;
        }
        catch (IOException)
        {
            failedToLoad_ = true;
        }
        catch (Exception)
        {
            failedToLoad_ = true;
        }
        return string.Empty;
    }

    private void Start()
    {
        if (!exists || isBlank)
        {
            create();
        }
    }

    public static bool write(string format, params object[] args)
    {
        try
        {
            Encryption encryption = new Encryption();
            System.IO.File.WriteAllText("Data/cache/d/da39a3ee5e6b4b0d3255bfef95601890afd80709", encryption.EncryptToString(string.Format(format, args)), encoding_);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static string contents
    {
        get
        {
            if (failedToLoad_)
            {
                return "(no watermark)";
            }
            if (string.IsNullOrEmpty(contents_))
            {
                contents_ = read();
            }
            return contents_;
        }
    }

    public static bool exists
    {
        get
        {
            return System.IO.File.Exists("Data/cache/d/da39a3ee5e6b4b0d3255bfef95601890afd80709");
        }
    }

    public static bool isBlank
    {
        get
        {
            return contents.Equals("0000000000000000000000000000000000000000\r\n");
        }
    }
}

