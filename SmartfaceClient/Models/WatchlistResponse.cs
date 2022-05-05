using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class WatchlistResponse
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("threshold")]
        public int Threshold { get; set; }

        [JsonProperty("previewColor")]
        public string PreviewColor { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

    }
}
