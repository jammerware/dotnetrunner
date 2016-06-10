using System;
using DotNetRunner.Json;
using Newtonsoft.Json;

namespace DotNetRunner.Models
{
    public class Card
    {
        public string Code { get; set; }
        [JsonProperty(PropertyName = "number")]
        public int CollectorNumber { get; set; }
        [JsonConverter(typeof(CostConverter))]
        public int? Cost { get; set; }
        public string Faction { get; set; }
        public int? FactionCost { get; set; }
        [JsonProperty(PropertyName = "flavor")]
        public string FlavorText { get; set; }
        public string Illustrator { get; set; }
        [JsonProperty(PropertyName = "imagesrc")]
        [JsonConverter(typeof(PrependUrlBaseConverter))]
        public string ImageUrl { get; set; }
        public bool IsUnique { get; set; }
        [JsonProperty(PropertyName = "last-modified")]
        public DateTime? LastModified { get; set; }
        [JsonProperty(PropertyName = "set_code")]
        public Set Set { get; set; }
        public string SubType { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
    }
}