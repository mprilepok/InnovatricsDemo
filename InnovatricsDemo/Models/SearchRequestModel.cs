using System.ComponentModel.DataAnnotations;

namespace InnovatricsDemo.Models
{
    public class SearchRequestModel
    {

        [Required]

        public string WatchlistId { get; set; }

        [Required]
        public int Threshold { get; set; }

        [Required]
        public int MinFaceSize { get; set; }

        [Required]
        public int MaxFaceSize { get; set; }

        [Required]
        public string Photo { get; set; }
    }
}
