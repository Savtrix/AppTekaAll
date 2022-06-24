using Microsoft.EntityFrameworkCore;
using AppTeka.Models;

namespace AppTeka.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Prescribtion> Prescribtions { get; set; }
        public DbSet<PrescribtionDetails> PrescribtionDetails { get; set; }
        public DbSet<ShopAssistant> ShopAssistants { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}