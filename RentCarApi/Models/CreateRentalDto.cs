namespace RentCarApi.Models
{
    public class CreateRentalDto
    {
        public int Id { get; set; }

        public string DeliveryPlaceId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public decimal Price { get; set; }

        public string Model { get; set; }
        public string Name { get; set; }
    }
}
