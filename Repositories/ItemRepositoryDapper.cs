using Dapper;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using System.Data;
using Npgsql;

namespace GabriEShopAPI.Repositories
{
    public class ItemRepositoryDapper
    {
        private readonly IDbConnection _connection;
        public ItemRepositoryDapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<Item> GetItems()
        {
            return (List<Item>)_connection.Query<Item>("SELECT id, name, price, quantity FROM items");
        }

        public Task<int> AddNewItem(string name, decimal price, int quantity)
        {
            string sql = $"INSERT INTO items (name, price, qunatity) VALUES (@name, @price, @quantity) returning id";
            var queryArguments = new
            {
                name = name,
                price = price,
                quantity = quantity
            };
            return _connection.ExecuteScalarAsync<int>(sql, queryArguments);
        }

        public async Task<bool> UpdateItem(int id, string name, decimal price, int quantity)
        {
            string sql = $"UPDATE items SET name = @name, price = @price, quantity = @quantity WHERE id = @id";
            var queryArguments = new
            {
                name = name,
                id = id,
                price = price,
                quantity = quantity
            };
            return (await _connection.ExecuteAsync(sql, queryArguments)) > 0;
        }

        public async Task<bool> DeleteItem(int id)
        {
            string sql = $"UPDATE items SET quantity = quantity - 1 WHERE id = @id AND quantity > 0";
            var queryArguments = new
            {
                id = id
            };
            var update = await _connection.ExecuteAsync(sql, queryArguments);
            return update > 0;
        }

        public async Task<Item> GetItemById(int id)
        {
            string sql = $"SELECT id, name, price, quantity FROM items WHERE id = @id";
            var queryArguments = new
            {
                id = id
            };
            return await _connection.QuerySingleAsync<Item>(sql, queryArguments);
        }

        public async Task<bool> CheckIfItemExists(string name)
        {
            string sql = $"SELECT COUNT(*) FROM items WHERE name = @name";
            return await _connection.QueryFirstAsync<int>(sql, new { name = name }) > 0;
        }

        public async Task<bool> CheckIfItemExistsById(int id)
        {
            string sql = $"SELECT COUNT(*) FROM items WHERE id = @id";
            return await _connection.QueryFirstAsync<int>(sql, new { id = id }) > 0;
        }
    }
}
