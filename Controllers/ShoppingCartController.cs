using GabriEShopAPI.DTOs;
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
        [Route("buy")]
        public async Task<IActionResult> BuyLogic(int userId, [FromBody] ItemResponse itemDetails)
        {
            //var itemId = itemDetails.Id;
            //var name = itemDetails.Name;
            //var price = itemDetails.Price;

            await _shoppingCartService.BuyLogic(userId, itemDetails);
            return Ok("Items transfered to shopping cart succesfully");
        }
    }
}
