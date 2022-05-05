using Newtonsoft.Json;
using System;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class WatchlistMemberResponse
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated")]
        public DateTime? UpdatedAt { get; set; }
    }
}
