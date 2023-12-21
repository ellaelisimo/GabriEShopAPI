using GabriEShopAPI.Entities;

namespace GabriEShopAPI.Interfaces
{
    public interface IItemRepository
    {
        public List<Item> GetItems();
        public Task<Item> GetItemById(int id);
        public Task<bool> UpdateItem(int id, string name, decimal price, int quantity);
        public Task<bool> DeleteItem(int id);
        public Task<int> AddNewItem(Item item);
        public Task<bool> CheckIfItemExists(string name);
        public Task<bool> CheckIfItemExistsById(int id);
    }
}
