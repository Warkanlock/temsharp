using Microsoft.AspNetCore.Mvc;
using Temsharp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Temsharp.Models;
using Temsharp.Interfaces;
using System;

namespace Temsharp.Controllers
{
    public class PermissionController : Controller
    {
        private IPermissionRepository _permissionRepository;
        private ITypePermissionRepository _typePermissionRepository;

        public PermissionController(IPermissionRepository permission, ITypePermissionRepository typerepository)
        {
            _permissionRepository = permission;
            _typePermissionRepository = typerepository;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var personPermission = await _permissionRepository.FindById(id);

            if (personPermission == null)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await _permissionRepository.Delete(personPermission);
                return Ok("Delete successfuly");
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name","LastName","DateOfPermission","TypePermissionId")] Permission permissionToCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _permissionRepository.Create(permissionToCreate);
                }
                PopulateDropdownList(permissionToCreate.TypePermissionId);
                return RedirectToAction("SeePermissions", "Home");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void PopulateDropdownList(object selectedPermission = null)
        {
            var query = from d in _typePermissionRepository.GetAll()
                        orderby d.Description
                        select d;

            ViewBag.TypePermissionId = new SelectList(query.AsNoTracking(), "TypePermissionId", "Description", selectedPermission);
        }
    }
}