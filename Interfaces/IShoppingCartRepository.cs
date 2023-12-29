using GabriEShopAPI.Entities;

namespace GabriEShopAPI.Interfaces
{
    public interface IShoppingCartRepository
    {
        public Task<Item> FindItemById(int id);

        public Task BuyLogic(int userId, int itemId, string itemName, decimal itemPrice);
    }
}
