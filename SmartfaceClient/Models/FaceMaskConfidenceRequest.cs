using Newtonsoft.Json;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class FaceMaskConfidenceRequest
    {
        [JsonProperty("faceMaskThreshold")]
        public double FaceMaskThreshold { get; set; } = 3000;
    }
}
