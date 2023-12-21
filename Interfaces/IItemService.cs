using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;

namespace GabriEShopAPI.Interfaces
{
    public interface IItemService
    {
        public List<Item> GetItems();
        public Task<Item> GetItemById(int id);
        public Task<Item> UpdateItem(int id, string name, decimal price, int quantity);
        public Task<bool> DeleteItem(int id);
        public Task<Item> AddNewItem(AddNewItem newItem);
        public Task<bool> CheckIfItemExists(string name);
        public Task<bool> CheckIfItemExistsById(int id);
    }
}
