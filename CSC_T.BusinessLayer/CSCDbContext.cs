using CSC_T.BusinessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSC_T.BusinessLayer
{
    public class CSCDbContext:IdentityDbContext<BaseUser>
    {
        public CSCDbContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
