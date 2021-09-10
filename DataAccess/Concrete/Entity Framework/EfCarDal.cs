using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {

            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 Description = c.Description,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 ImagePath =
                              (from i in context.CarImages where i.CarId == c.Id select i.ImagePath).ToList()
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            };
        }

        public CarDetailsDto GetCarDetailsByCarId(Expression<Func<CarDetailsDto, bool>> filter = null)
        {

            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 Description = c.Description,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 ImagePath =
                              (from i in context.CarImages where i.CarId == c.Id select i.ImagePath).ToList()
                             };
                 return result.FirstOrDefault(filter);

            };
        }
    }

}

