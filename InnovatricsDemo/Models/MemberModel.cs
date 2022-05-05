using System.ComponentModel.DataAnnotations;

namespace InnovatricsDemo.Models
{
    public class MemberModel
    {
        [Required]

        public string Name { get; set; }

        [Required]
        public string WatchListId { get; set; }

        [Required]
        public string Photo { get; set; }
    }
}
