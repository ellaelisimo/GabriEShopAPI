using Dapper;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using System.Data;
namespace GabriEShopAPI.Repositories
{
    public class ShopRepositoryDapper : IShopRepository
    {
        private readonly IDbConnection _connection;
        public ShopRepositoryDapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<Shop> GetAll()
        {
            return (List<Shop>)_connection.Query<Shop>("SELECT id, name, address FROM shops");
        }

        public Task<int> Add(Shop shop)
        {
            string sql = $"INSERT INTO shops (name, address) VALUES (@name, @adress) returning id";
            var queryArguments = new
            {
                name = shop.name,
                adress = shop.adress
            };
            return _connection.ExecuteScalarAsync<int>(sql, queryArguments);
        }

        public async Task<bool> Update(int id, string name, string address)
        {
            string sql = $"UPDATE shops SET name = @name, address = @address WHERE id = @id";
            var queryArguments = new
            {
                name = name,
                id = id,
                address = address
            };
            return (await _connection.ExecuteAsync(sql, queryArguments)) > 0;
        }

        public async Task<bool> Delete(int id)
        {
            string sql = $"DELETE FROM shops WHERE id = @id";
            var queryArguments = new
            {
                id = id
            };
            var update = await _connection.ExecuteAsync(sql, queryArguments);
            return update > 0;
        }

        public async Task<Shop> GetById(int id)
        {
            string sql = $"SELECT id, name, address FROM shops WHERE id = @id";
            var queryArguments = new
            {
                id = id
            };
            return await _connection.QuerySingleAsync<Shop>(sql, queryArguments);
        }

        public async Task<bool> CheckIfShopExists(string name)
        {
            string sql = $"SELECT COUNT(*) FROM shops WHERE name = @name";
            return await _connection.QueryFirstAsync<int>(sql, new { name = name }) > 0;
        }

        public async Task<bool> CheckIfShopExistsById(int id)
        {
            string sql = $"SELECT COUNT(*) FROM shops WHERE id = @id";
            return await _connection.QueryFirstAsync<int>(sql, new { id = id }) > 0;
        }
    }
}
