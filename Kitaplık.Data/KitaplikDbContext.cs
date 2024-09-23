using Kitaplik.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kitaplik.Data
{


    public class KitaplikDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public KitaplikDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<Kitap> Kitaplar { get; set; }
    }

}
