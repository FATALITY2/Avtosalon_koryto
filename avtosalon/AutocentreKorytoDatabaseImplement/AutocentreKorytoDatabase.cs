using AutocentreKorytoDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AutocentreKorytoDatabaseImplement
{
    class AutocentreKorytoDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                //optionsBuilder.UseSqlServer(@"Data Source=WIN-7QPLO386PS9;Initial Catalog=AutocentreKorytoDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
                optionsBuilder.UseSqlServer(@"Data Source=Maksim;Initial Catalog=AutocentreKorytoDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Cost> Costs { set; get; }
        public virtual DbSet<Car> Cars { set; get; }
        public virtual DbSet<Payment> Payments { set; get; }
        public virtual DbSet<Purchase> Purchases { set; get; }
        public virtual DbSet<PurchaseCar> PurchaseCars { set; get; }
        public virtual DbSet<User> Users { set; get; }
    }
}
