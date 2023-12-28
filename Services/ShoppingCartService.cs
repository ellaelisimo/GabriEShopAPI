using GabriEShopAPI.Entities;
using GabriEShopAPI.Exceptions;
using GabriEShopAPI.Interfaces;

namespace GabriEShopAPI.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<Item> FindItemById(int id)
        {
            var checkItem = await _shoppingCartRepository.FindItemById(id);
            if (checkItem == null)
            {
                throw new NotFoundItem($"Item with {id} does not exists");
            }
            return checkItem;
        }

        public async Task TranferItemsPlace(int id, int itemId, string name, decimal price)
        {
            var itemExists = await _shoppingCartRepository.FindItemById(id);
            if(itemExists == null)
            {
                throw new Exception("This item doesn't exists");
            }

            await _shoppingCartRepository.TranferItemsPlace(itemId, name, price);
        }
    }
}
