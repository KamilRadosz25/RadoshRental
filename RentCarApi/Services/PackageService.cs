using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities;
using RentCarApi.Exceptions;
using RentCarApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentCarApi.Services
{
    public class PackageService : IPackageService
    {
        private readonly RentalDbContext _context;
        private readonly IMapper _mapper;

        public PackageService(RentalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int rentalId, CreatePackageDto dto)
        {
            var rental = _context.Rentals.FirstOrDefault(x => x.Id == rentalId);

            if (rental is null)
            {
                throw new NotFoundException("Rental not found");
            }
            var packageEntity = _mapper.Map<Package>(dto);
            packageEntity.RentalId = rentalId;
            _context.Packages.Add(packageEntity);
            _context.SaveChanges();

            return packageEntity.Id;

        }

        public PackageDto GetById(int rentalId, int packageId)
        {
            var rental = GetRestaurantById(rentalId);

            var package = _context.Packages.FirstOrDefault(x => x.Id == packageId);
            if (package is null || package.RentalId != rentalId)
            {
                throw new NotFoundException("Rental not Found");
            }

            var packageDto = _mapper.Map<PackageDto>(package);

            return packageDto;
        }
        public List<PackageDto> GetAll(int rentalId)
        {
            var rental = GetRestaurantById(rentalId);

            var packageDto = _mapper.Map<List<PackageDto>>(rental.Packages);

            return packageDto;
        }

        public void RemoveAll(int rentalId)
        {
            var rental = GetRestaurantById(rentalId);

            _context.RemoveRange(rental.Packages);
            _context.SaveChanges();

        }

        private Rental GetRestaurantById(int rentalId)
        {
            var rental = _context
                .Rentals
                .Include(x => x.Packages)
                .FirstOrDefault(x => x.Id == rentalId);

            if (rental is null)
                throw new NotFoundException("Rental not Found");

            return rental;
        }
    }
}
