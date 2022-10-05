using System.ComponentModel.DataAnnotations;

namespace RentCarApi.Models
{
    public class CreateCarDto
    {
        [Required]
        [MaxLength(40)]
        public string Model { get; set; }
        public int Hp { get; set; }
        public string Color { get; set; }
        public int BrandId { get; set; }

    }
}
