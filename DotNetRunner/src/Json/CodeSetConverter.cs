using System;
using System.Collections.Generic;
using System.Linq;
using DotNetRunner.Models;
using Newtonsoft.Json;

namespace DotNetRunner.Json
{
    internal class CodeSetConverter : JsonConverter
    {
        private IEnumerable<Set> _sets;

        public CodeSetConverter(IEnumerable<Set> sets)
        {
            _sets = sets;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Set);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.Value != null)
            {
                string value = reader.Value.ToString();
                return _sets.Where(s => s.Code == value).FirstOrDefault();
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
