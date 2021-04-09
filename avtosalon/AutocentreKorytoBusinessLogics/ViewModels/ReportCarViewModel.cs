using System;
using System.Collections.Generic;
using System.Text;

namespace AutocentreKorytoClientBusinessLogics.ViewModels
{
    public class ReportCarViewModel
    {
        public DateTime DateOfCreation { get; set; }

        public string CarName { get; set; }

        public string Equipment { get; set; }

        public decimal CarPrice { get; set; }
    }
}
