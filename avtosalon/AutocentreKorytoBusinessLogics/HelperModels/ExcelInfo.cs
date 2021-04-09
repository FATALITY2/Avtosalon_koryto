using AutocentreKorytoClientBusinessLogics.ViewModels;
using System.Collections.Generic;

namespace AutocentreKorytoClientBusinessLogics.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportPurchaseCarViewModel> PurchaseCars { get; set; }
    }
}
