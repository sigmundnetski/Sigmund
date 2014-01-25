using System;

public class Logger
{
    private string m_name;

    public Logger(string name)
    {
        this.m_name = name;
    }

    public bool IsConsolePrintingEnabled()
    {
        return Log.Get().IsConsolePrintingEnabled(this.m_name);
    }

    public bool IsPrintingEnabled()
    {
        return Log.Get().IsPrintingEnabled(this.m_name);
    }

    public bool IsScreenPrintingEnabled()
    {
        return Log.Get().IsScreenPrintingEnabled(this.m_name);
    }

    public void Print(string message)
    {
        Log.Get().Print(this.m_name, message);
    }

    public void Print(string format, params object[] args)
    {
        string message = string.Format(format, args);
        this.Print(message);
    }

    public void ScreenPrint(string format, params object[] args)
    {
        string message = string.Format(format, args);
        Log.Get().ScreenPrint(this.m_name, message);
    }
}

