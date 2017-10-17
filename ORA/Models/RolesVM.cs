using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ORA.Models
{
    public class RolesVM
    {
        public int RoleId { get; set; }

        [Required]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        [Required]
        [DisplayName("Role Description")]
        public string RoleDescription { get; set; }
    }
}