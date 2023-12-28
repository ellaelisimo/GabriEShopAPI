﻿namespace GabriEShopAPI.DTOs
{
    public class ShoppingCartResponse
    {
        public int Order_Id { get; set; }

        public string Item_Id { get; set; }

        public string Item_Name { get; set; }

        public string Item_Price { get; set; }

        public decimal Total_Price { get; set; }

        public decimal Discount { get; set; }
    }
}
