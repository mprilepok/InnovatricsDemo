using Newtonsoft.Json;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class ImageData
    {
        [JsonProperty("data")]
        public string Data { get; set; }    
    }
}
