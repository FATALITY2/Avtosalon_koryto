using AutocentreKorytoBusinessLogics.ViewModels;
using System.Collections.Generic;

namespace AutocentreKorytoBusinessLogics.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportPurchaseCarViewModel> PurchaseCars { get; set; }
    }
}
