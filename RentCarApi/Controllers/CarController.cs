
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities;
using RentCarApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentCarApi.Controllers
{
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        private readonly RentalDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarController(RentalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ActionResult<List<Car>> GetAll()
        {
            var cars= _dbContext.Cars
                .Include(r => r.Brand)
                .ToList();
            var carsDtos = _mapper.Map<List<CarDto>>(cars);
            return Ok(carsDtos);  
        }

        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
           var car= _dbContext.Cars
                .FirstOrDefault(c => c.Id == id);
            if(car is null)
            {
                return NotFound();
            }
            var carDto = _mapper.Map<CarDto>(car);
            return Ok(carDto);
        }

        [HttpPost]
        public ActionResult CreateCar([FromBody] CreateCarDto dto)
        {
            var car = _mapper.Map<Car>(dto);
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();

            return Created($"/api/car/{car.Id}", null);
        }

    }
}
