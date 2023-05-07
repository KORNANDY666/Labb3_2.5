using System.ComponentModel.DataAnnotations;

namespace Labb3_2._5.Models.DTO
{
    public class PersonCreateDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
