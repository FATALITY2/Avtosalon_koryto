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
    public class PurchaseStorage : IPurchaseStorage
    {
        public List<PurchaseViewModel> GetFullList()
        {
            using (var context = new AutocentreKorytoDatabase())
            {
                return context.Purchases
                .Include(rec => rec.PurchaseCar)
                .ThenInclude(rec => rec.Car).Include(rec => rec.Payment)
                .ToList()
                .Select(rec => new PurchaseViewModel
                {
                    Id = rec.Id,
                    UserId = rec.UserId,
                    PurchaseName = rec.PurchaseName,
                    PurchaseSum = rec.PurchaseSum,
                    PurchaseSumToPayment = rec.Payment.FirstOrDefault(x => x.PurchaseId == rec.Id)?.PaymentSum,
                    DateOfCreation = rec.DateOfCreation,
                    DateOfPayment = rec.Payment.FirstOrDefault(x => x.PurchaseId == rec.Id)?.DateOfPayment,
                    PurchaseCar = rec.PurchaseCar
                .ToDictionary(recPC => recPC.CarId, recPC => (recPC.Car?.CarName, recPC.Count, recPC.Car.CarPrice))
                })
                .ToList();
            }
        }

        public List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AutocentreKorytoDatabase())
            {
                return context.Purchases
                .Include(rec => rec.PurchaseCar)
                .ThenInclude(rec => rec.Car).Include(rec => rec.Payment)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateOfCreation.Date == model.DateOfCreation.Date) ||
(model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateOfCreation.Date >= model.DateFrom.Value.Date && rec.DateOfCreation.Date <= model.DateTo.Value.Date) || (rec.UserId.HasValue && rec.UserId == model.UserId))
                .ToList()
                .Select(rec => new PurchaseViewModel
                {
                    Id = rec.Id,
                    UserId = rec.UserId,
                    PurchaseName = rec.PurchaseName,
                    PurchaseSum = rec.PurchaseSum,
                    PurchaseSumToPayment = rec.Payment.FirstOrDefault(x => x.PurchaseId == rec.Id)?.PaymentSum,
                    DateOfCreation = rec.DateOfCreation,
                    DateOfPayment = rec.Payment.FirstOrDefault(x => x.PurchaseId == rec.Id)?.DateOfPayment,
                    PurchaseCar = rec.PurchaseCar
                .ToDictionary(recPC => recPC.CarId, recPC => (recPC.Car?.CarName, recPC.Count, recPC.Car.CarPrice))
                }).ToList();
            }
        }

        public PurchaseViewModel GetElement(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AutocentreKorytoDatabase())
            {
                var purchase = context.Purchases
                .Include(rec => rec.PurchaseCar)
                .ThenInclude(rec => rec.Car).Include(rec => rec.Payment)
                .FirstOrDefault(rec => rec.PurchaseName == model.PurchaseName || rec.Id == model.Id);
                return purchase != null ?
                new PurchaseViewModel
                {
                    Id = purchase.Id,
                    UserId = purchase.UserId,
                    PurchaseName = purchase.PurchaseName,
                    PurchaseSum = purchase.PurchaseSum,
                    PurchaseSumToPayment = purchase.Payment.FirstOrDefault(x => x.PurchaseId == purchase.Id)?.PaymentSum,
                    DateOfCreation = purchase.DateOfCreation,
                    DateOfPayment = purchase.Payment.FirstOrDefault(x => x.PurchaseId == purchase.Id)?.DateOfPayment,
                    PurchaseCar = purchase.PurchaseCar
                .ToDictionary(recPC => recPC.CarId, recPC => (recPC.Car?.CarName, recPC.Count, recPC.Car.CarPrice))
                } :
                null;
            }
        }

        public void Insert(PurchaseBindingModel model)
        {
            using (var context = new AutocentreKorytoDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Purchase purchase = CreateModel(model, new Purchase());
                        context.Purchases.Add(purchase);
                        context.SaveChanges();
                        CreateModel(model, purchase, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(PurchaseBindingModel model)
        {
            using (var context = new AutocentreKorytoDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Purchases.Include(rec => rec.PurchaseCar)
                            .ThenInclude(rec => rec.Car).FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(PurchaseBindingModel model)
        {
            using (var context = new AutocentreKorytoDatabase())
            {
                Purchase element = context.Purchases.Include(rec => rec.PurchaseCar)
                .ThenInclude(rec => rec.Car).FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Purchases.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Покупка не найдена");
                }
            }
        }

        private Purchase CreateModel(PurchaseBindingModel model, Purchase purchase)
        {
            purchase.UserId = model.UserId;
            purchase.PurchaseName = model.PurchaseName;
            purchase.PurchaseSum = model.PurchaseSum;
            purchase.DateOfCreation = model.DateOfCreation;
            return purchase;
        }

        private Purchase CreateModel(PurchaseBindingModel model, Purchase purchase, AutocentreKorytoDatabase context)
        {
            purchase.UserId = model.UserId;
            purchase.PurchaseName = model.PurchaseName;
            purchase.PurchaseSum = model.PurchaseSum;
            purchase.DateOfCreation = model.DateOfCreation;

            if (model.Id.HasValue)
            {
                var purchaseCar = context.PurchaseCars.Where(rec => rec.PurchasesId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.PurchaseCars.RemoveRange(purchaseCar.Where(rec => !model.PurchaseCars.ContainsKey(rec.CarId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateCar in purchaseCar)
                {
                    updateCar.Count = model.PurchaseCars[updateCar.CarId].Item2;
                    model.PurchaseCars.Remove(updateCar.CarId);
                }
                context.SaveChanges();
            }
            //добавили новые
            foreach (var pc in model.PurchaseCars)
            {
                context.PurchaseCars.Add(new PurchaseCar
                {
                    PurchasesId = purchase.Id,
                    CarId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }

            return purchase;
        }
    }
}
