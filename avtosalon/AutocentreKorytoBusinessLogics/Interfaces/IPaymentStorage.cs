using AutocentreKorytoClientBusinessLogics.BindingModels;
using AutocentreKorytoClientBusinessLogics.ViewModels;
using System.Collections.Generic;

namespace AutocentreKorytoClientBusinessLogics.Interfaces
{
    public interface IPaymentStorage
    {
        List<PaymentViewModel> GetFullList();

        List<PaymentViewModel> GetFilteredList(PaymentBindingModel model);

        PaymentViewModel GetElement(PaymentBindingModel model);

        void Insert(PaymentBindingModel model);

        void Update(PaymentBindingModel model);

        void Delete(PaymentBindingModel model);
    }
}
