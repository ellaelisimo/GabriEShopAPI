using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;

namespace GabriEShopAPI.Interfaces
{
    public interface IShoppingCartService
    {
        public Task<Item> FindItemById(int id);
        public Task BuyLogic(int userId, ItemResponse itemDetails);
    }
}
