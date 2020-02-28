using Temsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temsharp.Interfaces
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        //If we need something special not releated with CRUD functionality, we could implement that here
    }
}
