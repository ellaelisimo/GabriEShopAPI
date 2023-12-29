using System.ComponentModel.DataAnnotations;

namespace GabriEShopAPI.DTOs
{
    public class AddShop
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
