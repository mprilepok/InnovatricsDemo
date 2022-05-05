using Newtonsoft.Json;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class AddNewFaceRequest
    {
        [JsonProperty("imageData")]
        public RegistrationImageData ImageData { get; set; } = new RegistrationImageData();

        [JsonProperty("faceDetectorConfig")]
        public FaceDetectorConfig FaceDetectorConfig { get; set; } = new FaceDetectorConfig();

        [JsonProperty("faceDetectorResourceId")]
        public string FaceDetectorResourceId { get; set; } = "cpu";

        [JsonProperty("templateGeneratorResourceId")]
        public string TemplateGeneratorResourceId { get; set; } = "cpu";
    }   
}
