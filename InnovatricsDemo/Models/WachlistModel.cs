using System.ComponentModel.DataAnnotations;

namespace InnovatricsDemo.Models
{
    public class WachlistModel
    {
        public string Id { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, Range(0, 100)]
        public int Threshold { get; set; }

        public string PreviewColor { get; set; }
    }
}
