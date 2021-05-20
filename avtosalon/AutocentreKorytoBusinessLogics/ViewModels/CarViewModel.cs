using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AutocentreKorytoBusinessLogics.ViewModels
{
    [DataContract]
    public class CarViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int? CostId { get; set; }

        [DataMember]
        [DisplayName("Название")]
        public string CarName { get; set; }

        [DataMember]
        [DisplayName("Комплектация")]
        public string Equipment { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal CarPrice { get; set; }

        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateOfCreation { get; set; }
    }
}
