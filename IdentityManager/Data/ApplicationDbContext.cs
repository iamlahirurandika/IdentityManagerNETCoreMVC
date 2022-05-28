using IdentityManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityManager.Data
{
    //Inherited IdentityDbContext contains all necessary tables. 
    public class ApplicationDbContext : IdentityDbContext   
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {   
               
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
