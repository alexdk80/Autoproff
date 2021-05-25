using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore{
    [Route("api/Car")]
    //[Produces("application/json")]  
    public class CarController : Controller
    {
        private readonly ICarRepository carRepository;

        public CarController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        
        [Route("~/api/GetAll")]
        [HttpGet]
        public ActionResult<List<Car>> GetAll(){
            return carRepository.GetCars();
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id){
            return carRepository.GetCarById(id);
        }

        [Route("~/api/Create")]
        [HttpPost]
        public void Create(Car car){
            //if(ModelState.IsValid){
                carRepository.CreateCar(car);
            //}
        }

        [Route("~/api/Update/{id}")]
        [HttpPut]
        public void Update(int id, Car car){
            //if(ModelState.IsValid){
                carRepository.UpdateCar(id, car);
            //}
        }

        [HttpDelete("~/api/Delete/{id}")]
        public ActionResult Delete(int id){
             carRepository.DeleteCar(id);
             return Ok();
        }
    }
}