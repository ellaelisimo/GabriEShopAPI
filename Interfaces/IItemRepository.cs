using GabriEShopAPI.Entities;

namespace GabriEShopAPI.Interfaces
{
    public interface IItemRepository
    {
        public List<Item> GetAll();

        public Task<Item> GetById(int id);

        public Task<bool> Update(int id, string name, decimal price, int quantity);

        public Task<bool> Delete(int id);

        public Task<int> Add(Item item);

        public Task<bool> CheckIfItemExists(string name);

        public Task<bool> CheckIfItemExistsById(int id);
    }
}
