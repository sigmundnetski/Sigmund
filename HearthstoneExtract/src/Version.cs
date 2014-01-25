using System;

public abstract class Version
{
    private static string bobNetAddress_;
    public const int clientChangelist = 0x9d7e;
    private static int clientChangelist_;
    private static string report_;
    private static string serverChangelist_;
    public const int version = 0xd3c;

    protected Version()
    {
    }

    private static void createReport()
    {
        object[] args = new object[] { 0xd3c, 0x9d7e, serverChangelist, bobNetAddress };
        report_ = string.Format("Version {0} (client {1}{2}{3})", args);
    }

    public static void Reset()
    {
        report_ = string.Empty;
    }

    public static string bobNetAddress
    {
        get
        {
            // This item is obfuscated and can not be translated.
            if (bobNetAddress_ != null)
            {
                goto Label_0011;
            }
            return string.Empty;
        }
        set
        {
            bobNetAddress_ = string.Format(", Battle.net {0}", value);
            Reset();
        }
    }

    public static string FullReport
    {
        get
        {
            if (string.IsNullOrEmpty(report_))
            {
                createReport();
            }
            return report_;
        }
    }

    public static string serverChangelist
    {
        get
        {
            // This item is obfuscated and can not be translated.
            if (serverChangelist_ != null)
            {
                goto Label_0011;
            }
            return string.Empty;
        }
        set
        {
            serverChangelist_ = string.Format(", server {0}", value);
            Reset();
        }
    }
}

