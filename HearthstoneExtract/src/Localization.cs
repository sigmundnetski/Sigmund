using System;
using System.Globalization;
using System.Threading;

public class Localization
{
    public const Locale DEFAULT_LOCALE = Locale.enUS;
    public static readonly string DEFAULT_LOCALE_NAME = Locale.enUS.ToString();
    private Locale m_locale;
    private static Localization s_instance = new Localization();

    public static Locale GetLocale()
    {
        return s_instance.m_locale;
    }

    public static string GetLocaleName()
    {
        return s_instance.m_locale.ToString();
    }

    public static void Initialize()
    {
        if (!SetLocaleName(Vars.Key("Localization.Locale").GetStr(DEFAULT_LOCALE_NAME)))
        {
            SetLocale(Locale.enUS);
        }
    }

    public static bool IsValidLocaleName(string localeName)
    {
        return Enum.IsDefined(typeof(Locale), localeName);
    }

    public static void SetLocale(Locale locale)
    {
        s_instance.SetPegLocale(locale);
    }

    public static bool SetLocaleName(string localeName)
    {
        if (!IsValidLocaleName(localeName))
        {
            return false;
        }
        s_instance.SetPegLocaleName(localeName);
        return true;
    }

    private void SetPegLocale(Locale locale)
    {
        string localeName = locale.ToString();
        this.SetPegLocaleName(localeName);
    }

    private void SetPegLocaleName(string localeName)
    {
        this.m_locale = (Locale) ((int) Enum.Parse(typeof(Locale), localeName));
        string str = localeName.Substring(0, 2);
        string str2 = localeName.Substring(2, 2).ToUpper();
        string name = string.Format("{0}-{1}", str, str2);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(name);
    }
}

