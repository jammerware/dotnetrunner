using System;
using Newtonsoft.Json;

namespace DotNetRunner.Models
{
    public class Set
    {
        [JsonProperty(PropertyName = "available")]
        public DateTime? AvailableDate { get; set; }
        [JsonProperty(PropertyName = "total")]
        public int? CardCount { get; set; }
        public string Code { get; set; }
        public int CycleNumber { get; set; }
        public string Name { get; set; }
        [JsonProperty(PropertyName = "number")]
        public int SetNumber { get; set; }
        public string Url { get; set; }
    }
}