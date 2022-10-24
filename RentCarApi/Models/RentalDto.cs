using System.Collections.Generic;

namespace RentCarApi.Models
{
    public class RentalDto
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal Price { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public List<PackageDto> Packages { get; set; }


    }
}
