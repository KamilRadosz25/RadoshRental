using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities;
using RentCarApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RentCarApi.Services
{
    public interface IRentalService
    {
        public RentalDto GetById(int id);
        public IEnumerable<RentalDto> GetAll();

        public int Create(CreateRentalDto dto);

        public bool Delete(int id);
    }
    public class RentalService : IRentalService
    {
        private readonly RentalDbContext _dbContext;
        private readonly IMapper _mapper;

        public RentalService(RentalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public RentalDto GetById(int id)
        {
            var rental = _dbContext
                .Rentals
                .Include(r => r.Car)
                .Include(r => r.Car.Brand)
                .Include(r => r.Address)
                .FirstOrDefault(x => x.Id == id);
            if (rental is null) return null;

            var result = _mapper.Map<RentalDto>(rental);
            return result;
        }

        public IEnumerable<RentalDto> GetAll()
        {
            var rentals = _dbContext
                .Rentals
                .Include(r => r.Car)
                .Include(r => r.Car.Brand)
                .Include(r => r.Address)
                .ToList();

            var rentalsDtos = _mapper.Map<List<RentalDto>>(rentals);

            return rentalsDtos;
        }
        public int Create(CreateRentalDto dto)
        {
            var rental = _mapper.Map<Rental>(dto);
            _dbContext.Rentals.Add(rental);
            _dbContext.SaveChanges();
            return rental.Id;
        }
        public bool Delete(int id)
        {
            var rental = _dbContext
                .Rentals
                .FirstOrDefault(x => x.Id == id);
            if (rental is null) return false;

            _dbContext.Rentals.Remove(rental);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
