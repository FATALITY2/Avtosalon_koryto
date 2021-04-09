using System;
using System.Collections.Generic;
using System.Linq;
using AutocentreKorytoClientBusinessLogics.BindingModels;
using AutocentreKorytoClientBusinessLogics.Interfaces;
using AutocentreKorytoClientBusinessLogics.ViewModels;
using AutocentreKorytoClientDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AutocentreKorytoClientDatabaseImplement.Implements
{
    public class CarStorage : ICarStorage
    {
        public List<CarViewModel> GetFullList()
        {
            using (var context = new AutocentreKorytoDatabase())
            {
                return context.Cars.Include(rec => rec.PurchaseCar)
                .ThenInclude(rec => rec.Purchases).Select(rec => new CarViewModel
                {
                    Id = rec.Id,
                    UserId = rec.UserId,
                    CostId = rec.CostsId,
                    CarName = rec.CarName,
                    Equipment = rec.Equipment,
                    CarPrice = rec.CarPrice,
                    DateOfCreation = rec.DateOfCreation
                })
                .ToList();
            }
        }

        public List<CarViewModel> GetFilteredList(CarBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AutocentreKorytoDatabase())
            {
                return context.Cars.Include(rec => rec.PurchaseCar)
                .ThenInclude(rec => rec.Purchases).Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateOfCreation.Date == model.DateOfCreation.Date) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateOfCreation.Date >= model.DateFrom.Value.Date && rec.DateOfCreation.Date <= model.DateTo.Value.Date))
                .Select(rec => new CarViewModel
                {
                    Id = rec.Id,
                    UserId = rec.UserId,
                    CostId = rec.CostsId,
                    CarName = rec.CarName,
                    Equipment = rec.Equipment,
                    CarPrice = rec.CarPrice,
                    DateOfCreation = rec.DateOfCreation
                })
                .ToList();
            }
        }

        public CarViewModel GetElement(CarBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AutocentreKorytoDatabase())
            {
                var car = context.Cars.Include(rec => rec.PurchaseCar)
                .ThenInclude(rec => rec.Purchases)
                .FirstOrDefault(rec => rec.CarName == model.CarName || rec.Id == model.Id);
                return car != null ?
                new CarViewModel
                {
                    Id = car.Id,
                    UserId = car.UserId,
                    CostId = car.CostsId,
                    CarName = car.CarName,
                    Equipment = car.Equipment,
                    CarPrice = car.CarPrice,
                    DateOfCreation = car.DateOfCreation
                } :
                null;
            }
        }

        public void Insert(CarBindingModel model)
        {
            using (var context = new AutocentreKorytoDatabase())
            {
                context.Cars.Add(CreateModel(model, new Car()));
                context.SaveChanges();
            }
        }

        public void Update(CarBindingModel model)
        {
            using (var context = new AutocentreKorytoDatabase())
            {
                var element = context.Cars.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Машина не найдена");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(CarBindingModel model)
        {
            using (var context = new AutocentreKorytoDatabase())
            {
                Car element = context.Cars.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Cars.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("машина не найдена");
                }
            }
        }

        private Car CreateModel(CarBindingModel model, Car car)
        {
            car.UserId = model.UserId;
            car.CostsId = model.CostsId;
            car.CarName = model.CarName;
            car.Equipment = model.Equipment;
            car.CarPrice = model.CarPrice;
            car.DateOfCreation = model.DateOfCreation;
            return car;
        }
    }
}
