using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapContext> , ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join co in context.Colors
                        on c.ColorId equals co.ColorId
                    select new CarDetailDTO
                    {
                        Id = c.Id, ModelYear = c.ModelYear, Description = c.Description,
                        DailyPrice = c.DailyPrice,
                        BrandName = b.BrandName,
                        ColorName = co.ColorName
                    };
                return result.ToList();
            }
        }
    }
}
