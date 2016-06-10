using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DotNetRunner.Json;
using DotNetRunner.Models;
using Newtonsoft.Json;

namespace DotNetRunner
{
    public class DnrClient
    {
        private const string API_ADDRESS_CARDS = "https://netrunnerdb.com/api/cards";        
        private const string API_ADDRESS_SETS = "https://netrunnerdb.com/api/sets/";

        public IEnumerable<Card> Cards { get; set; }
        public IEnumerable<Set> Sets { get; set; }

        private DnrClient() { }

        public static async Task<DnrClient> CreateAsync()
        {
            var client = new DnrClient();
            var httpClient = new HttpClient();

            var setData = await httpClient.GetStringAsync(API_ADDRESS_SETS);
            var sets = await Task.Factory.StartNew(() =>
            {
                return JsonConvert.DeserializeObject<IEnumerable<Set>>(setData);
            });

            var cardData = await httpClient.GetStringAsync(API_ADDRESS_CARDS);
            var cards = await Task.Factory.StartNew(() =>
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new CodeSetConverter(sets));

                return JsonConvert.DeserializeObject<IEnumerable<Card>>(cardData, settings);
            });

            return new DnrClient()
            {
                Cards = cards,
                Sets = sets
            };
        }
    }
}