using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore
{
    public class EFCarsRepository : ICarRepository
    {
        private readonly AppDbContextMySql context;

        public EFCarsRepository(AppDbContextMySql context)
        {
            this.context = context;
        }

        public Car GetCarById(int id)
        {
            return context.Cars.FirstOrDefault(x => x.Id == id);
        }

        public List<Car> GetCars()
        {
            return context.Cars.ToList();
        }

        public void SaveCar(Car car)
        {
            if (car.Id == default)
            {
                context.Entry(car).State = EntityState.Added;
            }
            else
            {
                context.Entry(car).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            context.Cars.Remove(new Car() { Id = id });
            context.SaveChanges();
        }

        public void CreateCar(Car car)
        {
            var car2 = new Car(){Model = "Ford", Price = 100, Produced = DateTime.Now};
            // if (car.Id == 0)
            // {
                context.Cars.Add(car2);
                context.SaveChanges();
            // }
        }

        public void UpdateCar(int id, Car car)
        {
            // bool isExist = context.Cars.Any(x => x.Id == id);
            // if (isExist)
            // {
                context.Cars.Update(car);
                context.SaveChanges();
            // }
        }
    }
}