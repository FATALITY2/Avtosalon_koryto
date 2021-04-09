using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutocentreKorytoBusinessLogics.Enums;

namespace AutocentreKorytoDatabaseImplement.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Purchase> Purchases { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Car> Car { get; set; }
    }
}
