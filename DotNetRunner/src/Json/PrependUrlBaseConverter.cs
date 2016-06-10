using System;
using Newtonsoft.Json;

namespace DotNetRunner.Json
{
    public class PrependUrlBaseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.Value != null)
            {
                // TODO: not this
                return "https://netrunnerdb.com" + reader.Value.ToString();
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
