using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //RentalTest();

            //CoreClassTest();
            //CarManagerTest();
            //BrandManagerTest();
            //ColorManagerTest();
        }

        private static void RentalTest()
        {            
            //customer added
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 2, CompanyName = "restaxe" });

            //rental car
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = new DateTime(2021, 02, 18) });
        }

        private static void CoreClassTest()
        {
            Console.WriteLine("\t\t\t...::: Araç Detay :::...");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Araç:{0} Marka:{1} Renk:{2} Fiyat:{3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
                Console.WriteLine();
            }


            Console.WriteLine("\t\t\t...::: Marka Ekle :::...");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Id = 6, Name = "Ford" });
            Console.WriteLine();

            Console.WriteLine("\t\t\t...::: Renk Ekle :::...");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Id = 6, Name = "Orange" });
            Console.WriteLine();

            Console.WriteLine("\t\t\t...::: Araç Ekle :::...");
            carManager.Add(new Car { BrandId = 6, ColorId = 6, DailyPrice = 60000, ModelYear = 6060, Description = "Ford-Turuncu" });
            Console.WriteLine();

            Console.WriteLine("\t\t\t...::: Yeni Araç Detay :::...");
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Araç:{0} Marka:{1} Renk:{2} Fiyat:{3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
                Console.WriteLine();
            }
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("\t\t\t...::: Renkler :::...\n");
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine("Id: {0} Name: {1}", item.Id, item.Name);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("\t\t\t...::: Markalar :::...\n");
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine("Id: {0} Name: {1}", item.Id, item.Name);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("\t\t\t...::: Araçlar :::...\n");
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine("Id: {0} MarkaId: {1} ColorId: {2} ModelYear: {3} DailyPrice: {4} Description: {5}", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
