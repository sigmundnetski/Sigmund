using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using UnityEngine;

public class PhoneHome : MonoBehaviour
{
    private static StreamWriter log_ = null;
    private const string submitURL_ = "http://iir.blizzard.com:3724/submit/";
    private static IPAddress unknownAddress_ = new IPAddress(new byte[4]);

    private static void Log(string format, params object[] args)
    {
        if (ApplicationMgr.IsInternal())
        {
            Blizzard.Log.SayToFile(log_, format, args);
        }
    }

    private void OnDestroy()
    {
        if (log_ != null)
        {
            log_.Close();
        }
    }

    private static void reportAccessProblem()
    {
        Error.AddDevFatal("Network Error", "Pegasus cannot access your system environment.", new object[0]);
        Log("Reported access problem", new object[0]);
    }

    private void reportCannotPlay()
    {
        Error.AddDevFatal("Network Error", "You cannot play this game outside of Blizzard.", new object[0]);
        Log("Reported network problem", new object[0]);
    }

    private void sendEscapeMessage()
    {
        string format = null;
        try
        {
            Log("Start building escape message", new object[0]);
            format = this.message;
            Log(format, new object[0]);
        }
        catch (Exception exception)
        {
            Log("Unhandled exception in PhoneHome.sendEscapeMessage() #1: " + exception.Message, new object[0]);
        }
        byte[] contents = null;
        try
        {
            contents = Encoding.UTF8.GetBytes(format);
            Log("Encoded report as UTF-8", new object[0]);
        }
        catch (Exception exception2)
        {
            Log("Unhandled exception in PhoneHome.sendEscapeMessage() #2: " + exception2.Message, new object[0]);
        }
        WWWForm form = new WWWForm();
        try
        {
            form.AddBinaryData("file", contents, "ReportedIssue.xml", "application/octet-stream");
            Log("Added report to escape message", new object[0]);
        }
        catch (Exception exception3)
        {
            Log("Unhandled exception in PhoneHome.sendEscapeMessage() #3: " + exception3.Message, new object[0]);
        }
        WWW www = null;
        try
        {
            www = new WWW("http://iir.blizzard.com:3724/submit/", form);
            Log("Created POST object", new object[0]);
        }
        catch (Exception exception4)
        {
            Log("Unhandled exception in PhoneHome.sendEscapeMessage() #4: " + exception4.Message, new object[0]);
        }
        try
        {
            base.StartCoroutine(this.WaitForRequest(www));
            Log("Started co-routine", new object[0]);
            if (ApplicationMgr.IsInternal())
            {
                Blizzard.Log.Write(format);
            }
        }
        catch (Exception exception5)
        {
            Log("Unhandled exception in PhoneHome.sendEscapeMessage() #5: " + exception5.Message, new object[0]);
        }
    }

    private void Start()
    {
    }

    [DebuggerHidden]
    private IEnumerator WaitForRequest(WWW www)
    {
        return new <WaitForRequest>c__IteratorBD { www = www, <$>www = www };
    }

    private string dnsdomain
    {
        get
        {
            try
            {
                string environmentVariable = Environment.GetEnvironmentVariable("USERDNSDOMAIN");
                return (!string.IsNullOrEmpty(environmentVariable) ? environmentVariable : "(unknown)");
            }
            catch (SecurityException exception)
            {
                Log("Unhandled security exception in PhoneHome.dnsdomain: " + exception.Message, new object[0]);
                return "(unknown)";
            }
        }
    }

    private bool inBlizzardDomain
    {
        get
        {
            return ((this.inIrvineOffice || this.inEuropeOffice) || this.inKoreaOffice);
        }
    }

    private bool inEuropeOffice
    {
        get
        {
            return Environment.MachineName.StartsWith("V4A-GR2-");
        }
    }

    private bool inIrvineOffice
    {
        get
        {
            return (this.userdomain.Equals("BLIZZARD", StringComparison.CurrentCultureIgnoreCase) && this.dnsdomain.Equals("CORP.BLIZZARD.NET", StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private bool inKoreaOffice
    {
        get
        {
            return Environment.MachineName.StartsWith("KR-TEST0");
        }
    }

    private IPAddress ipAddress
    {
        get
        {
            try
            {
                foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return address;
                    }
                }
                return unknownAddress_;
            }
            catch (SocketException exception)
            {
                Log("Unhandled socket exception in PhoneHome.ipAddress: " + exception.Message, new object[0]);
                return unknownAddress_;
            }
            catch (ArgumentException exception2)
            {
                Log("Unhandled exception in PhoneHome.ipAddress: " + exception2.Message, new object[0]);
                return unknownAddress_;
            }
        }
    }

    private string localTime
    {
        get
        {
            return DateTime.Now.ToString("F", CultureInfo.CreateSpecificCulture("en-US"));
        }
    }

    private string machineName
    {
        get
        {
            return Environment.MachineName;
        }
    }

    private string manifestHash
    {
        get
        {
            if (!Streaming.Enabled)
            {
                return "(disabled)";
            }
            string hash = Streaming.Manifest.Hash;
            if (hash != null)
            {
                return hash;
            }
            return "(no local manifest)";
        }
    }

    private string message
    {
        get
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                builder.Append("user=" + this.userName + "\n");
                builder.Append("machine=" + this.machineName + "\n");
                builder.Append("domain=" + this.userdomain + "\n");
                builder.Append("dnsdomain=" + this.dnsdomain + "\n");
                builder.Append("ipaddress=" + this.ipAddress + "\n");
                builder.Append("localtime=" + this.localTime + "\n");
                builder.Append("manifest=" + this.manifestHash + "\n");
                builder.Append("clientkey=" + Watermark.contents + "\n");
            }
            catch (Exception exception)
            {
                Log("Unhandled exception in PhoneHome.message() #1: " + exception.Message, new object[0]);
            }
            string str = "(null)";
            try
            {
                str = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<ReportedIssue xmlns=\"http://schemas.datacontract.org/2004/07/Inspector.Models\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">\n\t<BuildNumber>{0}</BuildNumber>\n\t<EnteredBy>0</EnteredBy>\n\t<IssueType>Task</IssueType>\n\t<Milestone>Alpha</Milestone>\n\t<Module>Client</Module>\n\t<Platform>All Win</Platform>\n\t<PrimaryAssignment>.phonehome</PrimaryAssignment>\n\t<Priority>1 - Critical</Priority>\n\t<ProjectId>70</ProjectId>\n\t<QaTeam>Development</QaTeam>\n\t<Status>Active</Status>\n\t<Steps>{1}</Steps>\n\t<Summary>Client Escape Report</Summary>\n</ReportedIssue>\n", 0xd3c, builder.ToString());
            }
            catch (Exception exception2)
            {
                Log("Unhandled exception in PhoneHome.message() #2: " + exception2.Message, new object[0]);
            }
            if (str != null)
            {
                return str;
            }
            return "(null)";
        }
    }

    private string userdomain
    {
        get
        {
            try
            {
                string environmentVariable = Environment.GetEnvironmentVariable("USERDOMAIN");
                return (!string.IsNullOrEmpty(environmentVariable) ? environmentVariable : "(unknown)");
            }
            catch (PlatformNotSupportedException exception)
            {
                Log("Unhandled platform support exception in PhoneHome.userdomain: " + exception.Message, new object[0]);
                return "(unknown)";
            }
            catch (InvalidOperationException exception2)
            {
                Log("Unhandled operation exception in PhoneHome.userdomain: " + exception2.Message, new object[0]);
                return "(unknown)";
            }
        }
    }

    private string userName
    {
        get
        {
            return Environment.UserName;
        }
    }

    [CompilerGenerated]
    private sealed class <WaitForRequest>c__IteratorBD : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal WWW <$>www;
        internal WWW www;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    PhoneHome.Log("Waiting for escape report result", new object[0]);
                    this.$current = this.www;
                    this.$PC = 1;
                    return true;

                case 1:
                    PhoneHome.Log("Received escape report result", new object[0]);
                    if (this.www.error != null)
                    {
                        PhoneHome.Log("Failed to submit escape report result: " + this.www.error, new object[0]);
                        if (ApplicationMgr.IsInternal())
                        {
                            Blizzard.Log.Write("Failed to submit escape report.  Error was: " + this.www.error);
                        }
                    }
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }
}

