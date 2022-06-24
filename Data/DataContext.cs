using Microsoft.EntityFrameworkCore;
using AppTeka.Models;
namespace AppTeka.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Drug> Drug { get; set; }
    }
}
