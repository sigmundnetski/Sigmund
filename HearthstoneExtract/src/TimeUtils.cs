using System;

public class TimeUtils
{
    public const int DAY = 0x15180;
    public static readonly DateTime EPOCH_TIME = new DateTime(0x7b2, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public const int HOUR = 0xe10;
    public const int MINUTE = 60;
    public const int WEEK = 0x93a80;

    public static DateTime ConvertEpochMicrosecToDateTime(ulong microsec)
    {
        return EPOCH_TIME.AddMilliseconds(((double) microsec) / 1000.0);
    }

    public static string GetBnetElapsedTimeString(ulong epochMicrosec)
    {
        DateTime time = ConvertEpochMicrosecToDateTime(epochMicrosec);
        TimeSpan span = (TimeSpan) (DateTime.UtcNow - time);
        int totalSeconds = (int) span.TotalSeconds;
        if (totalSeconds < 60)
        {
            return GameStrings.Get("GLOBAL_DATETIME_ELAPSED_LESS_THAN_MINUTE");
        }
        if (totalSeconds < 0xe10)
        {
            object[] objArray1 = new object[] { totalSeconds / 60 };
            return GameStrings.Format("GLOBAL_DATETIME_ELAPSED_MINUTES", objArray1);
        }
        int num2 = totalSeconds / 0x15180;
        switch (num2)
        {
            case 0:
            {
                object[] objArray2 = new object[] { totalSeconds / 0xe10 };
                return GameStrings.Format("GLOBAL_DATETIME_ELAPSED_HOURS", objArray2);
            }
            case 1:
                return GameStrings.Get("GLOBAL_DATETIME_ELAPSED_YESTERDAY");
        }
        int num3 = totalSeconds / 0x93a80;
        if (num3 == 0)
        {
            object[] objArray3 = new object[] { num2 };
            return GameStrings.Format("GLOBAL_DATETIME_ELAPSED_DAYS", objArray3);
        }
        object[] args = new object[] { num3 };
        return GameStrings.Format("GLOBAL_DATETIME_ELAPSED_WEEKS", args);
    }
}

