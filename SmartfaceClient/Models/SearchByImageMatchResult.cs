using Newtonsoft.Json;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class SearchByImageMatchResult
    {
        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("watchlistMemberId")]
        public string WatchlistMemberId{get;set;}

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("watchlistDisplayName")]
        public string WatchlistDisplayName { get; set; }

        [JsonProperty("watchlistFullName")]
        public string WatchlistFullName { get; set; }

        [JsonProperty("watchlistId")]
        public string WatchlistId { get; set; }
    }
}
