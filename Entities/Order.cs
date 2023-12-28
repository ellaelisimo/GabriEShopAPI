namespace GabriEShopAPI.Entities
{
    public class Order
    {
        public string Id { get; set; }

        public DateTime Created_At { get; set; }

        public decimal Total { get; set; }
    }
}
