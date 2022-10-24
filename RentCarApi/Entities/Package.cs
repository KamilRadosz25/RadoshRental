namespace RentCarApi.Entities
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RentalId { get; set; }

        public virtual Rental Rental { get; set; }

    }
}
