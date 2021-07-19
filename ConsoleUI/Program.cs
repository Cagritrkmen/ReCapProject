using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddingCarTest();
            //GetCarsByBrandIdTest();
            //GetCarByIdTest();
            //GetCarDetailsTest();
            //AddingBrandTest();
            //DeletingBrandTest();
            //UpdatingBrandTest();
            //GetBrandById();
            //GetBrandsTest();
            //UpdatingColorTest();
            //DeletingColorTest();
            //AddingColorTest();
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User { FirstName = "Ahmet", LastName = "Türkmen", Email = "ahmetturkmen_33@hotmail.com", Password = "123456" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void AddingCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(new Car { BrandId = 8, CarName = "Astra", ColorId = 8, DailyPrice = 380, ModelYear = 2014, Description = "Manuel" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DeletingColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.Delete(new Color { ColorName = "Purple" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UpdatingColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.Update(new Color { ColorId = 8, ColorName = "Pink" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetBrandsTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandId + "----" + brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetBrandById()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetById(8);
            if (result.Success == true)
            {
                Console.WriteLine(result.Data.BrandId + "/" + result.Data.BrandName);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByBrandId(2);
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetbyId(3);
            if (result.Success == true)
            {
                Console.WriteLine(result.Data.CarName);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void AddingColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result= colorManager.Add(new Color { ColorName = "Purple" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DeletingBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result= brandManager.Delete(new Brand { BrandId = 9 });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);  
            }
            
        }

        private static void UpdatingBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Update(new Brand { BrandId = 8, BrandName = "Opel" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddingBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Add(new Brand { BrandName = "Opel" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                     {
                           Console.WriteLine("{0}/{1}/{2}/{3}", car.BrandName, car.CarName, car.ColorName, car.DailyPrice);
                     }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
