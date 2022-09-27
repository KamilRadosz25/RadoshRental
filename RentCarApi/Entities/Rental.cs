namespace RentCarApi.Entities
{
    public class Rental
    {
        public int Id{ get; set; }

        public string DeliveryPlaceId { get; set; }

        public string StartDate { get; set; }
        
        public string EndDate { get; set; }

        public decimal Price { get; set; }

        public int CarId { get; set; }
        public int UserId { get; set; }


        public virtual Car Car { get; set; }

        public virtual User User { get; set; }






    }
}
