//not used here
using helloworld;
using Microsoft.EntityFrameworkCore;

namespace Helloworld.Data{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected DataContext()
        {
        }

        public DbSet<Staff> AdminStaffs { get; set; }
        public DbSet<Staff> TeachingStaffs { get; set; }
        public DbSet<Staff> SupportStaffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data source= database.db");
    }
}