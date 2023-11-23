using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DuAnQuanLyBatDongSan.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Full_Contract> Full_Contracts { get; set; }
        public DbSet<Installment_Contract> Installment_Contracts { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Property_Service> Property_Services { get; set; }
        public DbSet<Property_Status> Property_Statuses { get; set; }
        public DbSet<Property_Type> Property_Types { get; set; }
        public DbSet<Service> Services { get; set; }




        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}