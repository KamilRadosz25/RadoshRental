using RentCarApi.Models;
using System.Collections.Generic;

namespace RentCarApi.Services
{
    public interface ICarService
    {
        int Create(CreateCarDto dto);
        IEnumerable<CarDto> GetAll();
        CarDto GetById(int id);
        void Delete(int id);

        void Update(int id, UpdateCarDto dto);


    }
}