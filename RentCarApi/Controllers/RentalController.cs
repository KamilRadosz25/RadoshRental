using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities;
using RentCarApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RentCarApi.Controllers
{
    [Route("api/rental")]
    public class RentalController : ControllerBase
    {
        private readonly RentalDbContext _dbContext;
        private readonly IMapper _mapper;

        public RentalController(RentalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateRental([FromBody] CreateRentalDto dto)
        {
            var rental = _mapper.Map<Rental>(dto);
            _dbContext.Rentals.Add(rental);
            _dbContext.SaveChanges();

            return Created($"/api/rental/{rental.Id}", null);

        }

        [HttpGet]
        public ActionResult<IEnumerable<RentalDto>> GetAll()
        {
            var rentals = _dbContext
                .Rentals
                .Include(r=> r.Car)
                .Include(r=> r.Car.Brand)
                .ToList();
            var rentalsDtos = _mapper.Map<List<RentalDto>>(rentals);
            return Ok(rentalsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<RentalDto> Get([FromRoute]int id)
        {
            var rental = _dbContext
                .Rentals
                .Include(r => r.Car)
                .Include(r => r.Car.Brand)
                .FirstOrDefault(x => x.Id == id);
            
            if (rental is null)
            {
                return NotFound();
            }
            var rentalDto = _mapper.Map<RentalDto>(rental);
            return Ok(rentalDto);
        }

    }
}
