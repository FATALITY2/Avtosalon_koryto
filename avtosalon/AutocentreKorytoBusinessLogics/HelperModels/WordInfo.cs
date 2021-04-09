using AutocentreKorytoClientBusinessLogics.ViewModels;
using System.Collections.Generic;

namespace AutocentreKorytoClientBusinessLogics.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<CarViewModel> Cars { get; set; }

        public List<PurchaseViewModel> Purchases { get; set; }
    }
}
