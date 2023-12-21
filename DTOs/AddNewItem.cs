using System.ComponentModel.DataAnnotations;

namespace GabriEShopAPI.DTOs
{
    public class AddNewItem
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]    
        public int Quantity { get; set; }
    }
}
