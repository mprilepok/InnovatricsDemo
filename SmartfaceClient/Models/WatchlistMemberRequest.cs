using Newtonsoft.Json;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class WatchlistMemberRequest
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}
