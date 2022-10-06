using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentCarApi.Entities;
using RentCarApi.Exceptions;
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

        public void Delete(int id);

        public void Update(int id, UpdateRentalDto dto);
    }
    public class RentalService : IRentalService
    {
        private readonly RentalDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RentalService> _logger;

        public RentalService(RentalDbContext dbContext, IMapper mapper, ILogger<RentalService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public RentalDto GetById(int id)
        {
            var rental = _dbContext
                .Rentals
                .Include(r => r.Car)
                .Include(r => r.Car.Brand)
                .Include(r => r.Address)
                .FirstOrDefault(x => x.Id == id);
            if (rental is null)
                throw new NotFoundException("Rental not found");

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
        public void Delete(int id)
        {
            _logger.LogError($"Restaurant with id : {id} DELETE action invoked");

            var rental = _dbContext
                .Rentals
                .FirstOrDefault(x => x.Id == id);
            if (rental is null)
                throw new NotFoundException("Rental not found");

            _dbContext.Rentals.Remove(rental);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateRentalDto dto)
        {
            var rental = _dbContext
                .Rentals
                .FirstOrDefault(x => x.Id == id);
            if (rental is null)
                throw new NotFoundException("Rental not found");

            rental.StartDate = dto.StartDate;
            rental.EndDate = dto.EndDate;
            rental.Price = dto.Price;

            _dbContext.SaveChanges();
        }

    }
}
