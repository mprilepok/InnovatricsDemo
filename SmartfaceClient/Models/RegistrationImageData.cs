using Newtonsoft.Json;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class RegistrationImageData
    {
        [JsonProperty("faceId")]
        public string FaceId { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
