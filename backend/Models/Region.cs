using System.ComponentModel.DataAnnotations;

namespace Tython.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}