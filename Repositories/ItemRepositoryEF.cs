using GabriEShopAPI.Context;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GabriEShopAPI.Repositories
{
    public class ItemRepositoryEF : IItemRepository
    {
        private readonly DataContext _dataContext;
        public ItemRepositoryEF(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<int> AddNewItem(string name, decimal price, int quantity)
        {
            await _dataContext.Items.AddAsync(new Item { Name = name, Price = price, Quantity = quantity });
            return await _dataContext.SaveChangesAsync();
        }

        public Task<bool> CheckIfItemExists(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIfItemExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItem(int id)
        {
            var deleteItem = await _dataContext.Items.FirstOrDefaultAsync(x => x.Id == 1);
            if (deleteItem != null)
            {
                _dataContext.Items.Remove(deleteItem);
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _dataContext.Items.Where(i => i.Id == id).SingleOrDefaultAsync();
        }

        public List<Item> GetItems()
        {
            return _dataContext.Items.ToList();
        }

        public async Task<bool> UpdateItem(int id, string name, decimal price, int quantity)
        {
            var updateItem = await _dataContext.Items.FirstOrDefaultAsync(x => x.Id == 1);
            if (updateItem != null)
            {
                _dataContext.Items.Update(updateItem);
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
