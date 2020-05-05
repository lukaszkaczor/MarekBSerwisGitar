using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ContentEditor> ContentEditor { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}