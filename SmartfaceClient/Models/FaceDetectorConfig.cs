using Newtonsoft.Json;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class FaceDetectorConfig
    {
        [JsonProperty("minFaceSize")]
        public int MinFaceSize { get; set; } = 35;

        [JsonProperty("maxFaceSize")]
        public int MaxFaceSize { get; set; } = 600;

        [JsonProperty("maxFaces")]
        public int MaxFaces { get; set; } = 20;

        [JsonProperty("confidenceThreshold")]
        public int ConfidenceThreshold { get; set; } = 450;
    }
}
