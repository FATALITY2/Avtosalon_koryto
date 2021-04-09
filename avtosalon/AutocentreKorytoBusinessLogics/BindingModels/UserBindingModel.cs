using System;
using System.Collections.Generic;
using System.Text;

namespace AutocentreKorytoBusinessLogics.BindingModels
{
    [DataContract]
    public class UserBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public UserRole Role { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> UserPurchases { get; set; }
    }
}
