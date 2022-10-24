using RentCarApi.Models;
using System.Collections.Generic;

namespace RentCarApi.Services
{
    public interface IPackageService
    {
        int Create(int rentalId, CreatePackageDto dto);

        PackageDto GetById(int rentalId,int packageId);
        List<PackageDto> GetAll(int rentalId);
        void RemoveAll(int rentalId);
    }
}
