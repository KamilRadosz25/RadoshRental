using RentCarApi.Models;
using System.Collections.Generic;

namespace RentCarApi.Services
{
    public interface ICarService
    {
        int Create(CreateCarDto dto);
        IEnumerable<CarDto> GetAll();
        CarDto GetById(int id);
        bool Delete(int id);
    }
}