using Microsoft.EntityFrameworkCore;
using Rajan_Project.Models.Account;

namespace Rajan_Project.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Employee_Reg> Employee_Regs { get; set; }
        public DbSet<Employee_Login> Employee_Logins { get; set; }
        public DbSet<User>Users { get; set; }
    
    }

}
