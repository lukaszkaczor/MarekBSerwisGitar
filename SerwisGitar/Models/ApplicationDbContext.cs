using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ContentEditor> ContentEditor { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<ImageGallery> ImageGalleries { get; set; }
        public DbSet<MainGallery> MainGallery { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageGallery>()
                .HasKey(c => new { c.GalleryId, c.ImageId });


            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}