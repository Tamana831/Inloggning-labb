using InloggningSystem;
using Microsoft.EntityFrameworkCore;

namespace InloggSystem
{
    public interface IUserContext
    {
        DbSet<User> Users { get; set; }
    }
}