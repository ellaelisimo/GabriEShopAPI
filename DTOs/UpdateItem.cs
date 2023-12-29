using System.ComponentModel.DataAnnotations;

namespace GabriEShopAPI.DTOs
{
    public class UpdateItem
    {
        public int Id { get; set; }

        [Required]
        public string ? Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
