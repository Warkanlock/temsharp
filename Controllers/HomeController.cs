using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Temsharp.Data;
using Temsharp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Temsharp.Interfaces;
using System;
using System.Linq.Expressions;

namespace Temsharp.Controllers
{
    public class HomeController : Controller
    {
        private IPermissionRepository _permissionRepository;
        private ITypePermissionRepository _typePermissionRepository;

        public HomeController(IPermissionRepository permission, ITypePermissionRepository typerepository)
        {
            _permissionRepository = permission;
            _typePermissionRepository = typerepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeePermissions()
        {
            Expression<Func<Permission, TypePermission>> expressionTo = p => p.TypePermission;

            var permissions = _permissionRepository.Get(expressionTo);

            return View(permissions);
        }


        public IActionResult ApplyPermissions()
        {
            var query = from d in _typePermissionRepository.GetAll()
                        orderby d.Description
                        select d;

            ViewBag.TypePermissionId = new SelectList(query.AsNoTracking(), "TypePermissionId", "Description", null);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
