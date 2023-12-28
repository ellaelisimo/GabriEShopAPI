using GabriEShopAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GabriEShopAPI.Controllers
{
    [ApiController]
    [Route("api/shopping_cart")]
    public class ShoppingCartController : ControllerBase //fluent validation - ?
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPut]
        public async Task<IActionResult> TranferItemsPlace(int id, int itemId, string name, decimal price)
        {
            await _shoppingCartService.TranferItemsPlace(id, itemId, name, price);
            return Ok("Items transfered to shopping cart succesfully");
        }
    }
}
