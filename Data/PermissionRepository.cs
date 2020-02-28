using Temsharp.Interfaces;
using Temsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temsharp.Data
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(PermissionsContext context) : base(context)
        {

        }
    }
}
