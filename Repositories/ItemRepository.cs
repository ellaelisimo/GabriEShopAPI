using Dapper;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using System.Data;

namespace GabriEShopAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IDbConnection _connection;
        public ItemRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Item> GetItems()
        {
            return _connection.Query<Item>("SELECT id, name, price, is_deleted FROM items WHERE is_deleted = false");
        }

        public Task<int> AddNewItem(string name, decimal price)
        {
            string sql = $"INSERT INTO items (name, price) VALUES (@name, @price) returning id";
            var queryArguments = new
            {
                name = name,
                price = price
            };
            return _connection.ExecuteScalarAsync<int>(sql, queryArguments);
        }

        public async Task<bool> UpdateItem(int id, string name, decimal price)
        {
            string sql = $"UPDATE items SET name = @name, price = @price WHERE id = @id";
            var queryArguments = new
            {
                name = name,
                id = id,
                price = price
            };
            return (await _connection.ExecuteAsync(sql, queryArguments)) > 0;
        }

        public async Task<bool> DeleteItem(int id)
        {
            string sqlSecond = $"UPDATE items SET is_deleted = true WHERE id = @id";
            var queryArgumentsSecond = new
            {
                id = id
            };
            var update = await _connection.ExecuteAsync(sqlSecond, queryArgumentsSecond);
            return update > 0;
        }

        public async Task<Item> GetItemById(int id)
        {
            string sql = $"SELECT id, name, price FROM items WHERE id = @id AND is_deleted = false";
            var queryArguments = new
            {
                id = id
            };
            return await _connection.QuerySingleAsync<Item>(sql, queryArguments);
        }

        public async Task<bool> CheckIfItemExists(string name)
        {
            string sql = $"SELECT COUNT(*) FROM items WHERE name = @name AND is_deleted = false";
            return await _connection.QueryFirstAsync<int>(sql, new { name = name }) > 0;
        }

        public async Task<bool> CheckIfItemExistsById(int id)
        {
            string sql = $"SELECT COUNT(*) FROM items WHERE id = @id AND is_deleted = false";
            return await _connection.QueryFirstAsync<int>(sql, new { id = id }) > 0;
        }
    }
}
