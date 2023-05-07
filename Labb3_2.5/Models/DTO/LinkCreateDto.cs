using System.ComponentModel.DataAnnotations;

namespace Labb3_2._5.Models.DTO
{
    public class LinkCreateDto
    {

        [Required]
        public string Url { get; set; }

        [Required]
        public int InterestId { get; set; }
       
    }
}
