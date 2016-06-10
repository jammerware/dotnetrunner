using System;
using Newtonsoft.Json;

namespace DotNetRunner.Json
{
    public class CostConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.Value != null)
            {
                int parseOutput = 0;
                if(int.TryParse(reader.Value.ToString(), out parseOutput))
                {
                    return parseOutput;
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}