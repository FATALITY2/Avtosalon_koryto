using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutocentreKorytoClientDatabaseImplement.Models
{
    public class Car
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int? CostsId { get; set; }

        [Required]
        public string Carame { get; set; }

        [Required]
        public decimal CarPrice { get; set; }

        [Required]
        public string Equipment { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }

        [ForeignKey("CarId")]
        public virtual List<PurchaseCar> PurchaseCar { get; set; }
    }
}
