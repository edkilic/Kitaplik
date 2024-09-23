using Kitaplik.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kitaplik.Data 
{
    public class KGelenDbContext : DbContext
    {
        public KGelenDbContext(DbContextOptions<KGelenDbContext> options) : base(options)
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }
    }
}
