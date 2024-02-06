using Boulangerie.Model.OrderManagement;
using Boulangerie.Model.OrderMangement;
using Boulangerie.Model.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulangerie.Services
{
    
    public class OrderManager
    {
        private List<Order> orders;

        public OrderManager() { 
            orders = new List<Order>();
        }

        public void CreateNewOrder()
        {
            Console.Clear();
            Console.WriteLine("******************************");
            Console.WriteLine("**Ajout une nouvelle commande**");
            Console.WriteLine("******************************");

            Order order = new Order();

            do
            {
                order.addItem(addOrderItem());
                Console.WriteLine("Voulez-vous terminer votre commande? oui, non");
            } while (Console.ReadLine().ToLower() != "oui");


        }

        private OrderItem addOrderItem()
        {
            Console.WriteLine("Ajout d'un produit à la commande");
            int productId = Utilities.productManger.getProductId();

            Product product = Utilities.productManger.getProductById(productId);

            Console.WriteLine("Veuillez indiquer la quantité de " + product.Name + " à commander");
            int amount = Int32.Parse(Console.ReadLine());

            OrderItem newOrderItem = new OrderItem(product, amount, product.UnitPrice);
            Console.WriteLine($"L'ajout de {amount} {product.UnitType} de {product.Name} est effactué avec succès!");
            return newOrderItem;

        }



    }
}
