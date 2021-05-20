using AutocentreKorytoBusinessLogics.BindingModels;
using AutocentreKorytoBusinessLogics.HelperModels;
using AutocentreKorytoBusinessLogics.Interfaces;
using AutocentreKorytoBusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using AutocentreKorytoBusinessLogics.Enums;
using System.Linq;

namespace AutocentreKorytoBusinessLogics.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ICarStorage _carStorage;
        private readonly IPurchaseStorage _purchaseStorage;

        public ReportLogic(IPurchaseStorage purchaseStorage, ICarStorage carStorage)
        {
            _purchaseStorage = purchaseStorage;
            _carStorage = carStorage;
        }

        public List<ReportPurchaseCarViewModel> GetPurchasesCar()
        {
            var cars = _carStorage.GetFullList();
            var purchases = _purchaseStorage.GetFullList();
            var list = new List<ReportPurchaseCarViewModel>();
            foreach (var purchase in purchases)
            {
                var record = new ReportPurchaseCarViewModel
                {
                    PurchaseName = purchase.PurchaseName,
                    Cars = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var car in cars)
                {
                    if (purchase.PurchaseCar.ContainsKey(car.Id))
                    {
                        record.Cars.Add(new Tuple<string, int>(car.CarName,
                        purchase.PurchaseCar[car.Id].Item2));
                        record.TotalCount += purchase.PurchaseCar[car.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportPurchaseCarViewModel> GetCarPurchases()
        {
            var cars = _carStorage.GetFullList();
            var purchases = _purchaseStorage.GetFullList();
            var list = new List<ReportPurchaseCarViewModel>();
            foreach (var car in cars)
            {
                var record = new ReportPurchaseCarViewModel
                {
                    CarName = car.CarName,
                    Purchases = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var purchase in purchases)
                {
                    if (purchase.PurchaseCar.ContainsKey(car.Id))
                    {
                        record.Purchases.Add(new Tuple<string, int>(purchase.PurchaseName,
                        purchase.PurchaseCar[car.Id].Item2));
                        record.TotalCount += purchase.PurchaseCar[car.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportPurchaseViewModel> GetPurchases(ReportBindingModel model)
        {
            return _purchaseStorage.GetFilteredList(new PurchaseBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            }).Select(x => new ReportPurchaseViewModel
            {
                DateOfCreation = x.DateOfCreation,
                PurchaseName = x.PurchaseName,
                PurchaseSum = x.PurchaseSum,
                PurchaseSumToPayment = x.PurchaseSumToPayment,
            }).ToList();
        }

        public List<ReportCarViewModel> GetCars(ReportBindingModel model)
        {
            return _carStorage.GetFilteredList(new CarBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            }).Select(x => new ReportCarViewModel
            {
                DateOfCreation = x.DateOfCreation,
                CarName = x.CarName,
                Equipment = x.Equipment,
                CarPrice = x.CarPrice
            }).ToList();
        }

        public void SavePurchaseToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocPurchase(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список покупок",
                Purchases = _purchaseStorage.GetFullList()
            });
        }

        public void SaveFurnitureToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocCar(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список авто",
                Cars = _carStorage.GetFullList()
            });
        }

        public void SavePurchaseInfoToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocPurchase(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список покупок",
                PurchaseCars = GetPurchasesCar()
            });
        }

        public void SaveCarInfoToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocCar(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список авто",
                PurchaseCars = GetCarPurchases()
            });
        }

        public void SavePurchasesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocPurchase(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список покупок",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Purchases = GetPurchases(model)
            });
        }

        public void SaveCarToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocFurniture(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список авто",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Cars = GetCars(model)
            });
        }
    }
}
