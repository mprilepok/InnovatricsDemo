using Newtonsoft.Json;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class FaceFeaturesConfig
    {
        [JsonProperty("age")]
        public bool Age { get; set; } = true;

        [JsonProperty("gender")]
        public bool Gender { get; set; } = true;

        [JsonProperty("faceMask")]
        public bool FaceMask { get; set; } = true;

        [JsonProperty("noseTip")]
        public bool NoseTip { get; set; } = true;

        [JsonProperty("yawAngle")]
        public bool YawAngle { get; set; } = true;

        [JsonProperty("pitchAngle")]
        public bool PitchAngle { get; set; } = true;

        [JsonProperty("rollAngle")]
        public bool RollAngle { get; set; } = true;
    }
}
