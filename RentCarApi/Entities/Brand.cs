using System.Collections.Generic;

namespace RentCarApi.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}
