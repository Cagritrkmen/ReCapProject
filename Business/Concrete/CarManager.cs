using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        IBrandService _brandService;
        ICarDal _carDal;
        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }
        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("product.get")]
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            IResult result = BusinessRules.Run(CheckIfCarCountBrandCorrect(car.BrandId)
                , CheckIfBrandLimitExceded());
            
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        //[SecuredOperation("admin,user")]
        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetbyId(int carId)
        {
            
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(),Messages.CarDetailsListed);
        }
        public IDataResult<List<CarDetailsDto> >GetCarsDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(c => c.CarId == carId));
        }
        public IDataResult<CarDetailsDto> GetCarDetailsByCarId(int carId)
        {
            
            return new SuccessDataResult<CarDetailsDto>(_carDal.GetCarDetailsByCarId(c => c.CarId == carId));
        }
        public IDataResult<List<Car>>GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId)
        {
             
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId),Messages.CarsListedByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.ColorId == colorId),Messages.CarsListedByColorId);
        }
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId), Messages.CarsListedByColorId);
        }
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(o => o.BrandId == brandId && o.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        private IResult CheckIfCarCountBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll().Data.Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.BrandLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
