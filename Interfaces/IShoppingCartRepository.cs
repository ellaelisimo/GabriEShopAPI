using GabriEShopAPI.Entities;

namespace GabriEShopAPI.Interfaces
{
    public interface IShoppingCartRepository
    {
        public Task<Item> FindItemById(int id);

        public Task TranferItemsPlace(int itemId, string itemName, decimal itemPrice);
    }
}
