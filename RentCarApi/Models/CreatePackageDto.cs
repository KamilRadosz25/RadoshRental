﻿namespace RentCarApi.Models
{
    public class CreatePackageDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RentalId { get; set; }
    }
}

