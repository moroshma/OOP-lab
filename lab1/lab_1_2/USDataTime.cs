using System.Globalization;

namespace lab_1_2;

public class USDataTime : IDataFormat
{
    public string? FormatDateTime()
    {
        var culture = CultureInfo.CreateSpecificCulture("en-US");
        return DateTime.Now.ToString(culture);
    }
}