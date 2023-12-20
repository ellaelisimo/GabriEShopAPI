using GabriEShopAPI.Context;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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
             _dataContext.items.Add(new Item { name = name, price = price, quantity = quantity });
            return await _dataContext.SaveChangesAsync();
        }

        public Task<bool> CheckIfItemExists(string name)
        {
            return _dataContext.items.AnyAsync(item => item.name == name);
        }

        public Task<bool> CheckIfItemExistsById(int id)
        {
            return _dataContext.items.AnyAsync(item => item.id == id);
        }

        public async Task<bool> DeleteItem(int id)
        {
            var deleteItem = await _dataContext.items.FirstOrDefaultAsync(x => x.id == 1);
            if (deleteItem != null)
            {
                _dataContext.items.Remove(deleteItem);
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _dataContext.items.Where(i => i.id == id).SingleOrDefaultAsync();
        }

        public List<Item> GetItems()
        {
            return _dataContext.items.ToList();
            //ToListAsync naudojamas su Task<List<Item>> jei f-cija async; po ToList() negalima filtruoti, nes filtras tada eis ne per duombaze, o per musu irasus
        }

        public async Task<bool> UpdateItem(int id, string name, decimal price, int quantity)
        {
            var updateItem = await _dataContext.items.FirstOrDefaultAsync(x => x.id == id);
            if (updateItem != null)
            {
                updateItem.name = name;
                updateItem.price = price;
                updateItem.quantity = quantity;

                _dataContext.items.Update(updateItem);
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
