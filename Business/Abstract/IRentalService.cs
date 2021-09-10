using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int id);
        IResult Deliver(int rentId, DateTime dateTime);
        IResult Rent(Rental rental);
        IResult Update(Rental rental);

        IDataResult<List<RentalDetailsDto>> GetRentalDetails();
        IDataResult<List<RentalDetailsDto>> GetRentalDetailsReturnDateIsNull();
        IDataResult<List<RentalDetailsDto>> GetRentalDetailsByCarId(int carId);
        IDataResult<List<RentalDetailsDto>> GetRentalDetailsByCustomerId(int customerId);
        IResult CheckCarStatus(Rental rental);
    }
}
