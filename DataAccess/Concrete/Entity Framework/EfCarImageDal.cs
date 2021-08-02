﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage,ReCapContext>,ICarImageDal
    {
    }
}
