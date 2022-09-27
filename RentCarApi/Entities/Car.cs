using System.Collections.Generic;

namespace RentCarApi.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Hp { get; set; }
        public string Color { get; set; }
        public int BrandId { get; set; }
        public virtual List<Rental> Rental { get; set; }
        public virtual Brand Brand { get; set; }




    }
}
