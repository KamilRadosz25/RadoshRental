using System.Collections.Generic;

namespace RentCarApi.Models
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Hp { get; set; }
        public string Color { get; set; }
    }
}
