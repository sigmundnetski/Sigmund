using System;

public class LogInfo
{
    private bool m_consolePrinting;
    private string m_name;
    private bool m_screenPrinting;

    public LogInfo(string name)
    {
        this.m_name = name;
    }

    public string GetName()
    {
        return this.m_name;
    }

    public bool IsConsolePrintingEnabled()
    {
        return this.m_consolePrinting;
    }

    public bool IsPrintingEnabled()
    {
        return (this.IsConsolePrintingEnabled() || this.IsScreenPrintingEnabled());
    }

    public bool IsScreenPrintingEnabled()
    {
        return this.m_screenPrinting;
    }

    public void SetConsolePrintingEnabled(bool enable)
    {
        this.m_consolePrinting = enable;
    }

    public void SetScreenPrintingEnabled(bool enable)
    {
        this.m_screenPrinting = enable;
    }
}

