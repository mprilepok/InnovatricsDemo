using InnovatricsDemo.SmartfaceClient.Emuns;
using Newtonsoft.Json;
using System;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class Face
    {
        [JsonProperty("trackletId")]
        public string TrackletId { get; set; }
       
        [JsonProperty("quality")]
        public int Quality { get; set; }
        
        [JsonProperty("templateQuality")]
        public int? TemplateQuality { get; set; }
        
        [JsonProperty("state")]
        public EFaceState State { get; set; }
        
        [JsonProperty("imageDataId")]
        public string ImageDataId { get; set; }
        
        [JsonProperty("processedAt")]
        public DateTime? ProcessedAt { get; set; }
        
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
        
        [JsonProperty("leftEyeX")]
        public double? LeftEyeX { get; set; }
        
        [JsonProperty("leftEyeY")]
        public double? LeftEyeY { get; set; }
        
        [JsonProperty("rightEyeX")]
        public double? RightEyeX { get; set; }
        
        [JsonProperty("rightEyeY")]
        public double? RightEyeY { get; set; }
        
        [JsonProperty("frameId")]
        public string FrameId { get; set; }
        
        [JsonProperty("type")]
        public EFaceType Type { get; set; }
        
        [JsonProperty("age")]
        public double? Age { get; set; }
        
        [JsonProperty("gender")]
        public double? Gender { get; set; }
        
        [JsonProperty("faceMaskConfidence")]
        public double? FaceMaskConfidence { get; set; }
        
        [JsonProperty("noseTipConfidence")]
        public double? NoseTipConfidence { get; set; }
        
        [JsonProperty("faceMaskStatus")]
        public EFaceMaskStatus FaceMaskStatus { get; set; }
        
        [JsonProperty("faceArea")]
        public double? FaceArea { get; set; }
        
        [JsonProperty("faceOrder")]
        public int? FaceOrder { get; set; }
        
        [JsonProperty("facesOnFrameCount")]
        public int? FacesOnFrameCount { get; set; }
        
        [JsonProperty("faceAreaChange")]
        public double FaceAreaChange { get; set; }
        
        [JsonProperty("yawAngle")]
        public double? YawAngle { get; set; }
        
        [JsonProperty("pitchAngle")]
        public double? PitchAngle { get; set; }
        
        [JsonProperty("rollAngle")]
        public double? RollAngle { get; set; }
        
        [JsonProperty("autolearnClusterType")]
        public string AutolearnClusterType { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
