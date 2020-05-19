using System.Data.Entity;
using System.Web.UI.WebControls.WebParts;
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
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<InstrumentServices> InstrumentServices { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<PartType> PartTypes { get; set; }
        public DbSet<GuitarPart> GuitarParts { get; set; }
        public DbSet<CustomInstrument> CustomInstruments { get; set; }
        public DbSet<CustomInstrumentParts> CustomInstrumentParts { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageGallery>()
                .HasKey(c => new { c.GalleryId, c.ImageId });

            modelBuilder.Entity<InstrumentServices>()
                .HasKey(c => new { c.InstrumentId, c.ServiceId});

            modelBuilder.Entity<CustomInstrumentParts>()
                .HasKey(c => new { c.CustomInstrumentId, c.GuitarPartId});

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}