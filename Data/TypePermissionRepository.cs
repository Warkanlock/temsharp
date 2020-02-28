using Temsharp.Interfaces;
using Temsharp.Models;

namespace Temsharp.Data
{
    public class TypePermissionRepository : GenericRepository<TypePermission>, ITypePermissionRepository
    {
        public TypePermissionRepository(PermissionsContext context) : base(context)
        {

        }
    }
}
