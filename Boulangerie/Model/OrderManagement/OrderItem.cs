using Boulangerie.Model.ProductManagement;
using Boulangerie.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulangerie.Model.OrderMangement
{
    public class OrderItem
    {

        public int Id { get; set; }
        private static int lastId = 0; 
        public Product Product { get; set; }
        public int Amount { get; set; }
        public Price Price { get; set; }

        public OrderItem(Product product, int amount, Price price)
        {
            Id = ++lastId;
            Product = product;
            Amount = amount;
            Price = price;
        }

        public override string ToString()
        {
            return $"Produit : {Product.Name} -- Quantité : {Amount} {Product.UnitType} -- Prix Unitaire : {Product.UnitPrice.ItemPrice} {Product.UnitPrice.Currency}";
        }
    }
}
