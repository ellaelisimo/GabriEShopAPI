using Dapper;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using System.Data;

namespace GabriEShopAPI.Repositories
    //ar user egzistuoja, ar item egzistuoja +(jeigu viskas tvrkoje) puchase history, kas perka, kiek ir ko!! and user id turi buti shopping cart arba purchase
{
    public class ShoppingCartRepositoryDapper : IShoppingCartRepository
    {
        private readonly IDbConnection _connection;
        public ShoppingCartRepositoryDapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Item> FindItemById(int id)
        {
            string sql = $"SELECT id, name, price, quantity FROM items WHERE id = @id";
            var queryArguments = new
            {
                id = id
            };
            return await _connection.QuerySingleAsync<Item>(sql, queryArguments);
        }

        public async Task TranferItemsPlace(int itemId, string itemName, decimal itemPrice)
        {
                string insertSql = $"INSERT INTO shopping_cart (item_id, item_name, item_price) VALUES @itemId, @itemName, @itemPrice returning order_id";

                await _connection.ExecuteAsync(insertSql, new
                {
                    itemId = item.id,
                    itemName = item.name,
                    itemPrice = item.price
                });
            }
        }
    }
}
