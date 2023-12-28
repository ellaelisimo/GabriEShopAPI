using System.ComponentModel.DataAnnotations;

namespace GabriEShopAPI.DTOs
{
    public class AddUser
    {
        [Required]
        public string Name {  get; set; }

        [Required]
        public string Email { get; set; }
    }
}
