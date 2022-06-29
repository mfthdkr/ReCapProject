using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars = null;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2009, DailyPrice = 400,
                    Description = "Sağ çamurluk boyanacak."
                },
                new Car
                {
                    Id = 2, BrandId = 1, ColorId = 2, ModelYear = 2022, DailyPrice = 700,
                    Description = "Bakıma gidecek."
                },
                new Car
                {
                    Id = 3, BrandId = 2, ColorId = 1, ModelYear = 2019, DailyPrice = 600, Description = "Arızalı, garajda.",
                }
            };

        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c=>c.Id == id).ToList();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }
    }
}
