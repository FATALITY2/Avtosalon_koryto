using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutocentreKorytoDatabaseImplement.Models
{
    public class Cost
    {
        public int Id { get; set; }

        [Required]
        public string PurchaseName { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal CostPrice { get; set; }

        [ForeignKey("CostsId")]
        public virtual List<Car> Car { get; set; }
    }
}
