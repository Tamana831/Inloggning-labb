using InloggningSystem;
using Microsoft.EntityFrameworkCore;

 

namespace InloggSystem;

public class UserContext : DbContext, IUserContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=InloggSystem;Trusted_Connection=True;");
        }
        }
        
    



