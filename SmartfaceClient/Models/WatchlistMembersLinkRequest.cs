using Newtonsoft.Json;
using System.Collections.Generic;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class WatchlistMembersLinkRequest
    {
        [JsonProperty("watchlistId")]
        public string WatchlistId { get; set; }

        [JsonProperty("watchlistMembersIds")]
        public List<string> WatchlistMembersIds { get; set; } = new List<string>();
    }
}
