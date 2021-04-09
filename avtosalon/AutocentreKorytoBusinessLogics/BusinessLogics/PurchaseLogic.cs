﻿using System;
using System.Collections.Generic;
using AutocentreKorytoBusinessLogics.BindingModels;
using AutocentreKorytoBusinessLogics.Interfaces;
using AutocentreKorytoBusinessLogics.ViewModels;

namespace AutocentreKorytoBusinessLogics.BusinessLogics
{
    public class PurchaseLogic
    {
        private readonly IPurchaseStorage _purchasesStorage;

        public PurchaseLogic(IPurchaseStorage purchasesStorage)
        {
            _purchasesStorage = purchasesStorage;
        }

        public List<PurchaseViewModel> Read(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return _purchasesStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PurchaseViewModel> { _purchasesStorage.GetElement(model) };
            }
            return _purchasesStorage.GetFilteredList(model);
        }

        public void CreatePurchase(PurchaseBindingModel model)
        {
            _purchasesStorage.Insert(model); 
        }

        public void UpdatePurchase(PurchaseBindingModel model)
        {
            
            _purchasesStorage.Update(model);
            
        }

        public void Delete(PurchaseBindingModel model)
        {
            var element = _purchasesStorage.GetElement(new PurchaseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Покупка не найдена");
            }
            _purchasesStorage.Delete(model);
        }
    }
}
