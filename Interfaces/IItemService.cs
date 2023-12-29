using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;

namespace GabriEShopAPI.Interfaces
{
    public interface IItemService
    {
        public List<Item> GetAll();

        public Task<Item> GetById(int id);

        public Task<Item> Update(int id, string name, decimal price, int quantity);

        public Task<bool> Delete(int id);

        public Task<Item> Add(AddItem newItem);

        public Task<bool> CheckIfItemExists(string name);

        public Task<bool> CheckIfItemExistsById(int id);
    }
}
