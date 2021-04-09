using System;
using System.Collections.Generic;
using System.Text;

namespace AutocentreKorytoClientBusinessLogics.ViewModels
{
    public class ReportPurchaseCarViewModel
    {
        public string PurchaseName { get; set; }

        public string CarName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Purchases { get; set; }

        public List<Tuple<string, int>> Cars { get; set; }
    }
}
