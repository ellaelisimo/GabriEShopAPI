namespace GabriEShopAPI.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool Is_Deleted { get; set; }
    }
}
