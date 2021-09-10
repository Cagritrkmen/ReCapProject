using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailsDto> GetRentalDetails();
        List<RentalDetailsDto> GetRentalDetailsReturnDateIsNull();
        List<RentalDetailsDto> GetRentalDetailsByCarId(int carId);
        List<RentalDetailsDto> GetRentalDetailsByCustomerId(int customerId);

        bool CheckCarStatus(int carId, DateTime rentDate, DateTime? returnDate);
    }
}
