using Microsoft.EntityFrameworkCore;
using New.Context.EntityModel;

namespace New.Context
{
    public class NorthWindContext : DbContext
    {
        IConfiguration _configuration;
        public NorthWindContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-UUKUT9CD\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=True;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Category());
        }

        public DbSet<Category> Categories { get; set; }
    }
}
