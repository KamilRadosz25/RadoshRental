
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities;
using RentCarApi.Models;
using RentCarApi.Services;
using System.Collections.Generic;
using System.Linq;

namespace RentCarApi.Controllers
{
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateCarDto dto, [FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isUpdated = _carService.Update(id, dto);
            if(!isUpdated)
            {
                return NotFound();
            }
            return Ok();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var isDeleted = _carService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();

        }

        [HttpGet]
        public ActionResult<List<Car>> GetAll()
        {
            var carsDtos = _carService.GetAll();
            return Ok(carsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            var carDto = _carService.GetById(id);
            if (carDto is null)
            {
                return NotFound();
            }
            return Ok(carDto);
        }

        [HttpPost]
        public ActionResult CreateCar([FromBody] CreateCarDto dto)
        {
            var id = _carService.Create(dto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created($"/api/car/{id}", null);
        }

    }
}
