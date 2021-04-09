using AutocentreKorytoClientBusinessLogics.BindingModels;
using AutocentreKorytoClientBusinessLogics.ViewModels;
using System.Collections.Generic;

namespace AutocentreKorytoClientBusinessLogics.Interfaces
{
    public interface IPurchaseStorage
    {
        List<PurchaseViewModel> GetFullList();

        List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model);

        PurchaseViewModel GetElement(PurchaseBindingModel model);

        void Insert(PurchaseBindingModel model);

        void Update(PurchaseBindingModel model);

        void Delete(PurchaseBindingModel model);
    }
}
