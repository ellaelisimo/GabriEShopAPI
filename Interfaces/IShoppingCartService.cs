using GabriEShopAPI.Entities;

namespace GabriEShopAPI.Interfaces
{
    public interface IShoppingCartService
    {
        public Task<Item> FindItemById(int id);
        public Task TranferItemsPlace(int id, int itemId, string name, decimal price);

    }
}
