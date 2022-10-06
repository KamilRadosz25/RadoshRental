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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var isUpdated = _rentalService.Update(id, dto);
            if(!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            var isDeleted = _rentalService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateRental([FromBody] CreateRentalDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
              
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
