using Newtonsoft.Json;
using System.Collections.Generic;

namespace InnovatricsDemo.SmartfaceClient.Models.Requests
{
    public class SearchInWatchlistRequest
    {
        [JsonProperty("image")]
        public ImageData Image { get; set; } = new ImageData();

        [JsonProperty("watchlistIds")]
        public List<string> WatchlistIds { get; set; } = new List<string>();

        [JsonProperty("threshold")]
        public int Threshold { get; set; } = 40;

        [JsonProperty("maxResultCount")]
        public int MaxResultCount { get; set; } = 1;

        [JsonProperty("faceDetectorConfig")]
        public FaceDetectorConfig FaceDetectorConfig { get; set; } = new FaceDetectorConfig();

        [JsonProperty("faceDetectorResourceId")]
        public string FaceDetectorResourceId { get; set; } = "cpu";

        [JsonProperty("templateGeneratorResourceId")]
        public string TemplateGeneratorResourceId { get; set; } = "cpu";

        [JsonProperty("faceMaskConfidenceRequest")]
        public FaceMaskConfidenceRequest FaceMaskConfidenceRequest { get; set; } = new FaceMaskConfidenceRequest();

        [JsonProperty("faceFeaturesConfig")]
        public FaceFeaturesConfig FaceFeaturesConfig { get; set; } = new FaceFeaturesConfig();
    }
}
