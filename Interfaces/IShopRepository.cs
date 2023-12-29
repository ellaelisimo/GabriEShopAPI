using GabriEShopAPI.Entities;

namespace GabriEShopAPI.Interfaces
{
    public interface IShopRepository
    {
        public List<Shop> GetAll();

        public Task<Shop> GetById(int id);

        public Task<bool> Update(int id, string name, string address);

        public Task<bool> Delete(int id);

        public Task<int> Add(Shop shop);

        public Task<bool> CheckIfShopExists(string name);

        public Task<bool> CheckIfShopExistsById(int id);


    }
}
