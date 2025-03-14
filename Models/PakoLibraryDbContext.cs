using Microsoft.EntityFrameworkCore;

namespace PakoLibrary.Models
{
   public class PakoLibraryDbContext : DbContext
    {
        public PakoLibraryDbContext(DbContextOptions<PakoLibraryDbContext> options)
    : base(options){}

        public DbSet<Document> Document { get; set; }
        public DbSet<Admin> Admin { get; set; }

    }
}
