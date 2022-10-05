using System.ComponentModel.DataAnnotations;

namespace RentCarApi.Models
{
    public class CreateRentalDto
    {
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public decimal Price { get; set; }
        [Required]
        [MaxLength(25)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int CarId { get; set; }
    }
}
