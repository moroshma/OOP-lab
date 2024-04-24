using System.Globalization;

namespace lab_1_2;

public class EUDataTime : IDataFormat
{
    public string FormatDateTime()
    {
        var culture = CultureInfo.CreateSpecificCulture("ru-RU");
        return DateTime.Now.ToString(culture);
    }
}