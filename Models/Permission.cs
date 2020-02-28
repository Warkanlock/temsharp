using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temsharp.Models
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Permission")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfPermission { get; set; }

        [ForeignKey("TypePermissionId")]
        [Display(Name = "Type of Permission")]
        public TypePermission TypePermission { get; set; }

        [Required]
        [Display(Name = "Permission Category")]
        public int TypePermissionId { get; set; }
    }
}
