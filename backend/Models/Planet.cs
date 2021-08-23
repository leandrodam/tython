using System.ComponentModel.DataAnnotations;

namespace Tython.Models
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid region.")]
        public int RegionId { get; set; }

        public Region Region { get; set; }
    }
}