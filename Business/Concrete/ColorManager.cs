﻿using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            if (color.ColorName.Length <= 2)
            {
                return new ErrorResult(Messages.InvaidColorName);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Color color)
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(b => b.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length <= 2)
            {
                return new ErrorResult(Messages.InvaidColorName);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
