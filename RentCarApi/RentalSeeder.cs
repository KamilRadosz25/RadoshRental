using RentCarApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RentCarApi
{
    public class RentalSeeder
    {
        private readonly RentalDbContext _dbContext;

        public RentalSeeder(RentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Rentals.Any())
                {
                    var rentals = GetRentals();
                    _dbContext.Rentals.AddRange(rentals);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Rental> GetRentals()
        {
            var rentals = new List<Rental>()
            {
             new Rental()
            {
                DeliveryPlaceId ="Kraków Lidl Ul Długa",
                StartDate="20.09.2022",
                EndDate ="11.10.2022",
                Price = 3200,
                Car = new Car()
                {
                    Model= "Seria 3",
                    Hp = 190,
                    Color = "Szary",
                    Brand = new Brand()
                    {
                        Name="BMW"
                    }

                },
                User = new User()
                {
                    Name= "Adam",
                    SurName ="Nowak",
                    UserName="adamanowak",
                    Password="test123"
                }
            },
            new Rental()
            {
                DeliveryPlaceId = "Kraków Czyżyny 26",
                StartDate = "07.08.2022",
                EndDate = "18.11.2022",
                Price = 4300,
                Car = new Car()
                {
                    Model = "Corolla",
                    Hp = 140,
                    Color = "Biały",
                    Brand = new Brand()
                    {
                        Name = "Toyota"
                    }
                },
                User = new User()
                {
                    Name= "Paweł",
                    SurName ="Pliszka",
                    UserName="pawelpliszka",
                    Password="test321"
                }
            },
            new Rental()
            {
                DeliveryPlaceId = "Kraków Lidl Ul Długa",
                StartDate = "29.11.2022",
                EndDate = "2.12.2022",
                Price = 4800,
                Car = new Car()
                {
                    Model = "Focus RS",
                    Hp = 350,
                    Color = "Niebieski",
                    Brand = new Brand()
                    {
                        Name = "Ford"
                    }

                },
                User = new User()
                {
                    Name= "Wojciech",
                    SurName ="Kowalski",
                    UserName="wojtekowalski",
                    Password="test231"
                }

            }

            };
            return rentals;
        }
    }
}