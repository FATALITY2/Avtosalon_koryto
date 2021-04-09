using System;
using System.Collections.Generic;
using AutocentreKorytoClientBusinessLogics.BindingModels;
using AutocentreKorytoClientBusinessLogics.Interfaces;
using AutocentreKorytoClientBusinessLogics.ViewModels;

namespace AutocentreKorytoClientBusinessLogics.BusinessLogics
{
    public class CarLogic
    {
        private readonly ICarStorage _carStorage;

        public CarLogic(ICarStorage carStorage)
        {
            _carStorage = carStorage;
        }

        public List<CarViewModel> Read(CarBindingModel model)
        {
            if (model == null)
            {
                return _carStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CarViewModel> { _carStorage.GetElement(model) };
            }
            return _carStorage.GetFilteredList(model);
        }

        public void CreateFurniture(CarBindingModel model)
        {
            var element = _carStorage.GetElement(new CarBindingModel
            {
                CarName = model.CarName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такое авто");
            }
            _carStorage.Insert(model);
        }

        public void UpdateFurniture(CarBindingModel model)
        {

            _carStorage.Update(model);

        }

        public void Delete(CarBindingModel model)
        {
            var element = _carStorage.GetElement(new CarBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Авто не найдено");
            }
            _carStorage.Delete(model);
        }
    }
}
