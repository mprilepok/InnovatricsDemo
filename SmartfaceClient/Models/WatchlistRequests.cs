using Newtonsoft.Json;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class WatchlistRequests
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("threshold")]
        public int Threshold { get; set; }

        [JsonProperty("previewColor")]
        public string PreviewColor { get; set; }
    }
}
