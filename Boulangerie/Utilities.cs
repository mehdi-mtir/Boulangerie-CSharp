using Boulangerie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulangerie
{
    public class Utilities
    {
        //private static List<Product> stock = new List<Product>();
        private static List<Product> stock = new();

        public static void InitializeStock() {
            Product p1 = new Product(1, "Sucre", new Price(1.4, Currency.Euro), UnitType.PerKg, 50, 20, "Sucre en poudre" );
            Product p2 = new Product(2, "Farine", new Price(2.45, Currency.Euro), UnitType.PerKg, 100, 25, "Farine T55");
            Product p3 = new Product(1, "Oeufs", new Price(2.5, Currency.Euro), UnitType.PerBox, 40, 15, "OEUF biologique France barq. de 6");
            stock.Add(p1);
            stock.Add(p2);
            stock.Add(p3);
        }

        public static void ShowStock() {
            //afficher 
            Console.WriteLine("******************************");
            Console.WriteLine("*****Etat actuel du stock*****");
            Console.WriteLine("******************************");

            foreach (Product item in stock)
            {
                Console.WriteLine($"Produit : {item.Name} --- Quantité : {item.AmountInStock} {item.UnitType}");
            }
        }
    }
}
