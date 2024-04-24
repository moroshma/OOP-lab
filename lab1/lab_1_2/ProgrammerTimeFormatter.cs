using System.Text;

namespace lab_1_2;

public class ProgrammerTimeFormatter : IDataFormat
{
    private readonly IDataFormat _data;

    public ProgrammerTimeFormatter(IDataFormat data)
    {
        _data = data;
    }

    public string? FormatDateTime()
    {
        var sb = new StringBuilder();
        sb.Append("What time is it? \n");
        sb.Append(_data.FormatDateTime());
        sb.Append(" \nTime to Code, Born to code \u2764\ufe0f\u200d\ud83d\udd25");
        return sb.ToString();
    }
}