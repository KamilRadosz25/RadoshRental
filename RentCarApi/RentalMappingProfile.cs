using AutoMapper;
using RentCarApi.Entities;
using RentCarApi.Models;

namespace RentCarApi
{
    public class RentalMappingProfile : Profile
    {
        public RentalMappingProfile()
        {
            CreateMap<Car, CarDto>()
                .ForMember(m => m.Brand, c => c.MapFrom(b => b.Brand.Name));
            CreateMap<CreateCarDto, Car>();
            CreateMap<Rental, RentalDto>()
                .ForMember(m => m.Model, c => c.MapFrom(s => s.Car.Model))
                .ForMember(m => m.UserName, c => c.MapFrom(s => s.User.UserName))
                .ForMember(m => m.Name, c => c.MapFrom(s => s.Car.Brand.Name));
                

        }

    }
}
