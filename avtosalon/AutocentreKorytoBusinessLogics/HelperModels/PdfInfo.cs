﻿using System;
using System.Collections.Generic;
using AutocentreKorytoBusinessLogics.ViewModels;

namespace AutocentreKorytoBusinessLogics.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportPurchaseViewModel> Purchases { get; set; }
        public List<ReportCarViewModel> Cars { get; set; }
    }
}
