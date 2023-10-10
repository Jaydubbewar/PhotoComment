using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PhotoComment.Models
{
    public class PhotoContext : DbContext
    {
        public PhotoContext()
        {
        }

        public PhotoContext(DbContextOptions<PhotoContext> options)
     : base(options)
        {
        }
        public DbSet<PhotoModel> Photos { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database provider and connection string
            optionsBuilder.UseSqlServer("Data Source=(local); Initial Catalog=PhotoDB; TrustServerCertificate=True; Trusted_Connection=True;");
        }

    }
}
