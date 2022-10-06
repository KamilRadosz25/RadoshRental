using System.ComponentModel.DataAnnotations;

namespace RentCarApi.Models
{
    public class UpdateRentalDto
    {
        [Required]
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public decimal Price { get; set; }

    }
}
