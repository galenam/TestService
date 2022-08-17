using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DateTimeConverter : JsonConverter<DateTime>
{
    private const string _format = "yyyy-MM-ddTHH:mm:ss.fffffffK";
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString(), _format, System.Globalization.CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}