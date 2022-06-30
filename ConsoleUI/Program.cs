using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;



//GetCarsByBrandId();

// Add();

//GetCarDetails();





void GetCarsByBrandId()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetCarsByBrandId(1))
    {
        Console.WriteLine(car.ModelYear);
    }
}

void Add()
{
    CarManager carManager = new CarManager(new EfCarDal());
    List<Car> cars = new List<Car>
    {
        new Car {BrandId = 2, ColorId = 2, DailyPrice = 600, Description = "Manuel 7 kişi"},
        new Car {BrandId = 1, ColorId = 3, DailyPrice = 0, Description = "Otomatik 1 kişi", ModelYear = 1990}
    };
    carManager.Add(cars[1]);
}

void GetCarDetails()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var carDetailDto in carManager.GetCarDetails())
    {
        Console.WriteLine(carDetailDto.Id + " " + carDetailDto.BrandName + " " + carDetailDto.ColorName + " " +
                          carDetailDto.DailyPrice);
    }
}

