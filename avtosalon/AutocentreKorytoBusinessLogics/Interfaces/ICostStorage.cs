using AutocentreKorytoClientBusinessLogics.BindingModels;
using AutocentreKorytoClientBusinessLogics.ViewModels;
using System.Collections.Generic;

namespace AutocentreKorytoClientBusinessLogics.Interfaces
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
