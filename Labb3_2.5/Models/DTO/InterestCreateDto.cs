using System.ComponentModel.DataAnnotations;

namespace Labb3_2._5.Models.DTO
{
    public class InterestCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int PersonId { get; set; }

    }
}
