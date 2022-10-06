using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities;
using RentCarApi.Models;
using RentCarApi.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RentCarApi.Controllers
{
    [Route("api/rental")]
    //Reposinble for Validation 
    [ApiController]
    public class RentalController : ControllerBase
    {

        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRentalDto dto, [FromRoute] int id)
        {
            _rentalService.Update(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _rentalService.Delete(id);

            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateRental([FromBody] CreateRentalDto dto)
        {              
            var id =_rentalService.Create(dto);

            return Created($"/api/rental/{id}", null);

        }

        [HttpGet]
        public ActionResult<IEnumerable<RentalDto>> GetAll()
        {
            var rentalsDtos = _rentalService.GetAll();
            return Ok(rentalsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<RentalDto> Get([FromRoute]int id)
        {
            var rental = _rentalService.GetById(id);

            if(rental is null)
            {
                return NotFound();
            }
            return Ok(rental);
        }

    }
}
