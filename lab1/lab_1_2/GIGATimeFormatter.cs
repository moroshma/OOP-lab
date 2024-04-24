using System.Text;

namespace lab_1_2;

public class GigaTimeFormatter : IDataFormat
{
    private readonly IDataFormat _data;

    public GigaTimeFormatter(IDataFormat data)
    {
        _data = data;
    }

    public string? FormatDateTime()
    {
        var sb = new StringBuilder();
        sb.Append("What time is it?\n");
        sb.Append(_data.FormatDateTime());
        sb.Append("\nTime to go to the gym");
        return sb.ToString();
    }
}