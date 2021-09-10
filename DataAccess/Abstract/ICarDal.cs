using Core.DataAccess;
using Core.Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null);
        CarDetailsDto GetCarDetailsByCarId(Expression<Func<CarDetailsDto, bool>> filter = null);
    }
}
