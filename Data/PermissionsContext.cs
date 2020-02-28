using Microsoft.EntityFrameworkCore;
using Temsharp.Models;

namespace Temsharp.Data
{
    public class PermissionsContext : DbContext
    {
        public PermissionsContext(DbContextOptions<PermissionsContext> options) : base(options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<TypePermission> TypePermissions { get; set; }
    }
}
