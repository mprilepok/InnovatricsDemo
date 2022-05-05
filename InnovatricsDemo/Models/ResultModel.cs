using InnovatricsDemo.SmartfaceClient.Models;
using System.ComponentModel.DataAnnotations;

namespace InnovatricsDemo.Models
{
    public class ResultModel
    {
        public ResultModel() { }

        public ResultModel(SearchInWatchlistResponse sr, string name, string watchlist)
        {
            Quality = sr.Quality;
            LeftEyeX = sr.LeftEyeX;
            LeftEyeY = sr.LeftEyeY;
            RightEyeX = sr.RightEyeX;
            RightEyeY = sr.RightEyeY;
            Age = sr.Age;
            Gender = sr.Gender.ToString();
            FaceMaskConfidence = sr.FaceMaskConfidence;
            NoseTipConfidence = sr.NoseTipConfidence;
            FaceMaskStatus = sr.FaceMaskStatus.ToString();
            Name = name;
            WatchListName = watchlist;
        }

        [Display(Name = "Quality")]
        public int Quality { get; set; }

        [Display(Name = "Left eye x")]
        [DisplayFormat(DataFormatString = "{0:0.####}")]
        public double? LeftEyeX { get; set; }

        [Display(Name = "Left eye y")]
        [DisplayFormat(DataFormatString = "{0:0.####}")]
        public double? LeftEyeY { get; set; }

        [Display(Name = "Right eye x")]
        [DisplayFormat(DataFormatString = "{0:0.####}")]
        public double? RightEyeX { get; set; }

        [Display(Name = "Right eye y")]
        [DisplayFormat(DataFormatString = "{0:0.####}")]
        public double? RightEyeY { get; set; }

        [Display(Name = "Age")]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public double Age { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Face mask confidence")]
        [DisplayFormat(DataFormatString = "{0:0.####}")]
        public double? FaceMaskConfidence { get; set; }

        [Display(Name = "Nose tip confidence")]
        [DisplayFormat(DataFormatString = "{0:0.####}")]
        public double? NoseTipConfidence { get; set; }

        [Display(Name = "Face mask status")]
        public string FaceMaskStatus { get; set; }

        [Display(Name = "Watch list name")]
        public string WatchListName { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
