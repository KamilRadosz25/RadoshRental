namespace RentCarApi.Models
{
    public class CreateCarDto
    {
        public string Model { get; set; }
        public int Hp { get; set; }
        public string Color { get; set; }
        public int BrandId { get; set; }

    }
}
