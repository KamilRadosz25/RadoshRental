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
                .ForMember(m => m.Name, c => c.MapFrom(s => s.Car.Brand.Name))
                .ForMember(m => m.City, x => x.MapFrom(x => x.Address.City))
                .ForMember(m => m.Street, x => x.MapFrom(x => x.Address.Street))
                .ForMember(m => m.PostalCode, x => x.MapFrom(x => x.Address.PostalCode));

            CreateMap<CreateRentalDto, Rental>()
                .ForMember(m => m.Address, x => x.MapFrom(dto => new Address()
                { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));


        }

    }
}
