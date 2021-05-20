using AutocentreKorytoBusinessLogics.BindingModels;
using AutocentreKorytoBusinessLogics.ViewModels;
using System.Collections.Generic;

namespace AutocentreKorytoBusinessLogics.Interfaces
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
