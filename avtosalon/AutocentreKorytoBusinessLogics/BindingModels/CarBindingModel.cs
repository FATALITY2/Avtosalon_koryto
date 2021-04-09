using System;
using System.Collections.Generic;
using System.Text;

namespace AutocentreKorytoBusinessLogics.BindingModels
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
        public string FurnitureName { get; set; }

        [DataMember]
        public string Material { get; set; }

        [DataMember]
        public decimal FurniturePrice { get; set; }

        [DataMember]
        public DateTime DateOfCreation { get; set; }

        [DataMember]
        public DateTime? DateFrom { get; set; }

        [DataMember]
        public DateTime? DateTo { get; set; }
    }
}
