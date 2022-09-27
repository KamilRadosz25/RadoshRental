using System.Collections.Generic;

namespace RentCarApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual List<Rental> Rentals { get; set; }

  
    }
}
