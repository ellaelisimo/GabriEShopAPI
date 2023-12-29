using System.ComponentModel.DataAnnotations;

namespace GabriEShopAPI.DTOs
{
    public class UpdateShop
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
