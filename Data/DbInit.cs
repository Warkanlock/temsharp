using System;
using System.Collections.Generic;
using System.Linq;

namespace Temsharp.Data
{
    public static class DbInit
    {
        public static void Initialize(PermissionsContext context)
        {
            context.Database.EnsureCreated();

            //Use this method to seed the database (If you want)

            context.SaveChangesAsync();
        }
    }
}
