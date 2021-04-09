using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AutocentreKorytoClientBusinessLogics.BindingModels
{
    [DataContract]
    public class CarBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int? CostsId { get; set; }

        [DataMember]
        public string CarName { get; set; }

        [DataMember]
        public string Equipment { get; set; }

        [DataMember]
        public decimal CarPrice { get; set; }

        [DataMember]
        public DateTime DateOfCreation { get; set; }

        [DataMember]
        public DateTime? DateFrom { get; set; }

        [DataMember]
        public DateTime? DateTo { get; set; }
    }
}
