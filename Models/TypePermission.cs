using System.ComponentModel.DataAnnotations;

namespace Temsharp.Models
{
    public class TypePermission
    {
        [Key]
        public int TypePermissionId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
