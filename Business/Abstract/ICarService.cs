using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<Car> GetbyId(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<CarDetailsDto> GetCarDetailsByCarId(int carId);
        IDataResult<List<CarDetailsDto>> GetCarsDetailsByCarId(int carId);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId);
    }
}
