using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public bool CheckCarStatus(int carId, DateTime rentDate, DateTime? returnDate)
        {
            using (ReCapContext context = new ReCapContext())
            {
                bool checkReturnDateIsNull = context.Set<Rental>().Any(p => p.CarId == carId && p.ReturnDate == null);
                bool isValidRentDate = context.Set<Rental>()
                    .Any(r => r.CarId == carId && (
                            (rentDate >= r.RentDate && rentDate <= r.EstReturnDate) ||
                            (returnDate >= r.RentDate && returnDate <= r.EstReturnDate) ||
                            (r.RentDate >= rentDate && r.RentDate <= returnDate)
                            )
                    );

                if ((!checkReturnDateIsNull) && (!isValidRentDate))
                {
                    return true;
                }

                return false;
            }
        }

        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join p in context.Payments
                             on r.CarId equals p.CarId
                             select new RentalDetailsDto
                             {
                                 RentalId = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 Decription = c.Description,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 EstReturnDate = r.EstReturnDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CardNameSurname = p.CardNameSurname,
                                 CardNumber = p.CardNumber,
                                 CardExpiryDate = p.CardExpiryDate,
                                 CardCvv = p.CardCvv,
                                 TotalPaye = p.TotalPaye
                             };

                return result.ToList();
            }
        }

        public List<RentalDetailsDto> GetRentalDetailsByCarId(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join p in context.Payments
                             on r.CarId equals p.CarId
                             where r.CarId == carId
                             select new RentalDetailsDto
                             {
                                 RentalId = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 Decription = c.Description,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 EstReturnDate = r.EstReturnDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CardNameSurname = p.CardNameSurname,
                                 CardNumber = p.CardNumber,
                                 CardExpiryDate = p.CardExpiryDate,
                                 CardCvv = p.CardCvv,
                                 TotalPaye = p.TotalPaye

                             };

                return result.ToList();
            }
        }

        public List<RentalDetailsDto> GetRentalDetailsByCustomerId(int customerId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join p in context.Payments
                             on r.CarId equals p.CarId
                             where r.CustomerId == customerId
                             select new RentalDetailsDto
                             {
                                 RentalId = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 Decription = c.Description,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 EstReturnDate = r.EstReturnDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CardNameSurname = p.CardNameSurname,
                                 CardNumber = p.CardNumber,
                                 CardExpiryDate = p.CardExpiryDate,
                                 CardCvv = p.CardCvv,
                                 TotalPaye = p.TotalPaye

                             };

                return result.ToList();
            }
        }

        public List<RentalDetailsDto> GetRentalDetailsReturnDateIsNull()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             join p in context.Payments
                             on r.CarId equals p.CarId
                             where r.ReturnDate == null
                             select new RentalDetailsDto
                             {
                                 RentalId = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 Decription = c.Description,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 EstReturnDate = r.EstReturnDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CardNameSurname = p.CardNameSurname,
                                 CardNumber = p.CardNumber,
                                 CardExpiryDate = p.CardExpiryDate,
                                 CardCvv = p.CardCvv,
                                 TotalPaye = p.TotalPaye
                             };

                return result.ToList();
            }
        }
    }
}
