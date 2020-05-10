
///-----------------------------------------------------------------
///   Namespace:      MetCheckAPI
///   Description:    JSON type converters JSON<->POCO. Not to be consumed outside library
///-----------------------------------------------------------------

using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace MetCheckAPI.Private
{
    public class YYMMToTimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    string valStr = reader.GetString();
                    int hrInt = 0;
                    int minInt = 0;

                    if ( valStr.Contains(':') )
                    {
                        string[] splitStr = valStr.Split(':');
                        string hrString = splitStr[0];
                        string minString = splitStr[1];
                        hrInt = int.Parse(hrString);
                        minInt = int.Parse(minString);
                    }

                    return new TimeSpan(hrInt, minInt, 0);

                default:
                    return new TimeSpan();
            }
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.Hours}:{value.Minutes}");
        }
    }

    public class StringFloatNullableConverter : JsonConverter<float?>
    {
        public override float? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    string floatStr = reader.GetString();
                    return float.Parse(floatStr);

                case JsonTokenType.Number:
                    return (float)reader.GetDouble();

                default:
                    return 0;
            }
        }

        public override void Write(Utf8JsonWriter writer, float? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue((value ?? 0).ToString());
        }
    }

    public class StringFloatConverter : JsonConverter<float>
    {
        public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    string floatStr = reader.GetString();
                    return float.Parse(floatStr);

                case JsonTokenType.Number:
                    return (float)reader.GetDouble();

                default:
                    return 0;
            }
        }

        public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    public class StringInt32Converter : JsonConverter<Int32>
    {
        public override Int32 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    string intStr = reader.GetString();
                    return Int32.Parse(intStr);

                case JsonTokenType.Number:
                    return (Int32)reader.GetInt32();

                default:
                    return 0;
            }
        }

        public override void Write(Utf8JsonWriter writer, Int32 value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    public class StringUInt32Converter : JsonConverter<UInt32>
    {
        public override UInt32 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    string intStr = reader.GetString();
                    return UInt32.Parse(intStr);

                case JsonTokenType.Number:
                    return (UInt32)reader.GetInt32();

                default:
                    return 0;
            }
        }

        public override void Write(Utf8JsonWriter writer, UInt32 value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
