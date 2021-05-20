using AutocentreKorytoBusinessLogics.BindingModels;
using AutocentreKorytoBusinessLogics.ViewModels;
using System.Collections.Generic;

namespace AutocentreKorytoBusinessLogics.Interfaces
{
    public interface ICostStorage
    {
        List<CostViewModel> GetFullList();

        List<CostViewModel> GetFilteredList(CostBindingModel model);

        CostViewModel GetElement(CostBindingModel model);

        void Insert(CostBindingModel model);

        void Update(CostBindingModel model);

        void Delete(CostBindingModel model);
    }
}
