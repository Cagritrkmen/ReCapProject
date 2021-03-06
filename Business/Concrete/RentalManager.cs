using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        
        
        //[SecuredOperation("admin,rental.admin")]
        public IResult Rent(Rental rental)
        {
            if (!_rentalDal.CheckCarStatus(rental.CarId, rental.RentDate, rental.ReturnDate))
            {
                return new ErrorResult(Messages.RentalReturnDateIsNull);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        //[TransactionScopeAspect]
        //[SecuredOperation("admin,rental.admin")]
        public IResult Deliver(int rentId, DateTime dateTime)
        {
            var result = _rentalDal.Get(r => r.Id == rentId && r.ReturnDate == null);
            if (result != null)
            {
                result.ReturnDate = dateTime;
                _rentalDal.Update(result);
                return new SuccessResult(Messages.RentalDelivered);
            }
            return new ErrorResult(Messages.RentalReturnDateIsNotNull);
        }

        //[TransactionScopeAspect]
        //[CacheRemoveAspect("IRentalManager.Get")]
        //[SecuredOperation("admin,rental.admin")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [PerformanceAspect(5)]
        // [CacheAspect]
        public IDataResult<List<RentalDetailsDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails());
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailsDto>> GetRentalDetailsReturnDateIsNull()
        {

            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetailsReturnDateIsNull());
        }

        public IDataResult<List<RentalDetailsDto>> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetailsByCarId(carId));
        }

        public IDataResult<List<RentalDetailsDto>> GetRentalDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetailsByCustomerId(customerId));
        }

        public IResult CheckCarStatus(Rental rental)
        {
            if (_rentalDal.CheckCarStatus(rental.CarId, rental.RentDate, rental.ReturnDate))
            {
                return new SuccessResult(Messages.RentalDateOk);
            }
            return new ErrorResult(Messages.RentalReturnDateIsNull);
        }

    }
}
