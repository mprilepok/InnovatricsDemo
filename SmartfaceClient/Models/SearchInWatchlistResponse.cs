using InnovatricsDemo.SmartfaceClient.Emuns;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class SearchInWatchlistResponse
    {
        [JsonProperty("cropLeftTopX")]
        public double CropLeftTopX { get; set; }

        [JsonProperty("cropLeftTopY")]
        public double CropLeftTopY { get; set; }

        [JsonProperty("cropRightTopX")]
        public double CropRightTopX { get; set; }

        [JsonProperty("cropRightTopY")]
        public double CropRightTopY { get; set; }

        [JsonProperty("cropLeftBottomX")]
        public double CropLeftBottomX { get; set; }

        [JsonProperty("cropLeftBottomY")]
        public double CropLeftBottomY { get; set; }

        [JsonProperty("cropRightBottomX")]
        public double CropRightBottomX { get; set; }

        [JsonProperty("cropRightBottomY")]
        public double CropRightBottomY { get; set; }

        [JsonProperty("quality")]
        public int Quality { get; set; }

        [JsonProperty("leftEyeX")]
        public double? LeftEyeX { get; set; }

        [JsonProperty("leftEyeY")]
        public double? LeftEyeY { get; set; }

        [JsonProperty("rightEyeX")]
        public double? RightEyeX { get; set; }

        [JsonProperty("rightEyeY")]
        public double? RightEyeY { get; set; }

        [JsonProperty("age")]
        public double Age { get; set; }

        [JsonProperty("gender")]
        public EGender Gender { get; set; }

        [JsonProperty("faceMaskConfidence")]
        public double? FaceMaskConfidence { get; set; }

        [JsonProperty("noseTipConfidence")]
        public double? NoseTipConfidence { get; set; }

        [JsonProperty("faceMaskStatus")]
        public EFaceMaskStatus FaceMaskStatus { get; set; }

        [JsonProperty("matchResults")]
        public List<SearchByImageMatchResult> MatchResults { get; set; } = new List<SearchByImageMatchResult>();
    }
}
