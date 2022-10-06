using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities;
using RentCarApi.Exceptions;
using RentCarApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentCarApi.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly RentalDbContext _dbContext;

        public CarService(RentalDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public CarDto GetById(int id)
        {
            var car = _dbContext.Cars
                .Include(x=>x.Brand)
               .FirstOrDefault(c => c.Id == id);
            if (car is null)
                throw new NotFoundException("Car not found");

            var result = _mapper.Map<CarDto>(car);
            return result;

        }

        public IEnumerable<CarDto> GetAll()
        {
            var cars = _dbContext.Cars
                .Include(r => r.Brand)
                .ToList();
            var carsDtos = _mapper.Map<List<CarDto>>(cars);
            return carsDtos;
        }

        public int Create(CreateCarDto dto)
        {
            var car = _mapper.Map<Car>(dto);
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
            return car.Id;
        }

        public void Delete(int id)
        {
            var car = _dbContext.Cars
            .FirstOrDefault(c => c.Id == id);
            
            if(car is null)
                throw new NotFoundException("Car not found");

            _dbContext.Cars.Remove(car);
            _dbContext.SaveChanges();
        }
        public void Update(int id, UpdateCarDto dto)
        {
            var car = _dbContext.Cars
               .FirstOrDefault(c => c.Id == id);
            if (car is null)
                throw new NotFoundException("Car not found");

            car.Model = dto.Model;
            car.Hp = dto.Hp;
            car.Color = dto.Color;

            _dbContext.SaveChanges();
        }
    }
}
