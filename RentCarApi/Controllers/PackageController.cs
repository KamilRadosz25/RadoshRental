using Microsoft.AspNetCore.Mvc;
using RentCarApi.Models;
using RentCarApi.Services;
using System.Collections.Generic;

namespace RentCarApi.Controllers
{
    [Route("api/rental/{rentalId}/package")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int rentalId)
        {
            _packageService.RemoveAll(rentalId);

            return NoContent();
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int rentalId,[FromBody] CreatePackageDto dto)
        {
            var newPackageId = _packageService.Create(rentalId, dto);

            return Created($"api/rental/{rentalId}/package/{newPackageId}", null);
        }

        [HttpGet("{packageId}")]
        public ActionResult<PackageDto> Get([FromRoute] int rentalId, [FromRoute] int packageId)
        {
            var package = _packageService.GetById(rentalId, packageId);
            return Ok(package);
        }
        [HttpGet]
        public ActionResult<List<PackageDto>> Get([FromRoute] int rentalId)
        {
            var result = _packageService.GetAll(rentalId);
            return Ok(result);
        }
    }
}
