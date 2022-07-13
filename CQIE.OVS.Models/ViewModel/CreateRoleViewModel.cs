using System.ComponentModel.DataAnnotations;

namespace CQIE.OVS.Models.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "角色")]
        public string RoleName { get; set; }
    }
}
