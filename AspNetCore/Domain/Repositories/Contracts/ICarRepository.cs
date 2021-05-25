using System.Collections.Generic;
using System.Linq;

namespace AspNetCore
{
    public interface ICarRepository
    {
        List<Car> GetCars();
        Car GetCarById(int id);
        void CreateCar(Car car);
        void UpdateCar(int id, Car car);
        void DeleteCar(int id);
    }
}