using System.Collections.Generic;

namespace RentCarApi.Entities
{
    public class Rental
    {
        public int Id { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public decimal Price { get; set; }

        public int CarId { get; set; }
        public int AddressId { get; set; }

        public virtual List<Package> Packages { get; set; }
        public virtual Address Address { get; set; }
        public virtual Car Car { get; set; }







    }
}
