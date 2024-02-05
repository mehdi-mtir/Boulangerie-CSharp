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
        private static string choice = string.Empty;

        public static void InitializeStock() {
            Product p1 = new Product(1, "Sucre", new Price(1.4, Currency.Euro), UnitType.PerKg, 50, 20, "Sucre en poudre" );
            Product p2 = new Product(2, "Farine", new Price(2.45, Currency.Euro), UnitType.PerKg, 100, 25, "Farine T55");
            Product p3 = new Product(3, "Oeufs", new Price(2.5, Currency.Euro), UnitType.PerBox, 40, 15, "OEUF biologique France barq. de 6");
            stock.Add(p1);
            stock.Add(p2);
            stock.Add(p3);
        }

        public static void ShowMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("******************************");
                Console.WriteLine("********Menu Principal********");
                Console.WriteLine("******************************");

                Console.WriteLine("Veuillez saisir le numéro de l'action à réaliser :");
                Console.WriteLine("1. Afficher tous les produits en stock");
                Console.WriteLine("2. Ajouter un nouveau produit");
                Console.WriteLine("3. Alimenter le stock");
                Console.WriteLine("4. Diminuer le stock");
                Console.WriteLine("5. Afficher les produits en risque de rupture de stock");

                choice = Console.ReadLine();

            } while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5");

            switch (choice)
            {
                case "1": ShowStock(); break;
                case "2": AddNewProduct(); break;
                case "3": ChangeStockAmount("increase"); break;
                case "4": ChangeStockAmount("decrease"); break;
                case "5": ShowLowStockProducts(); break;
            }
        }

        public static void ShowLowStockProducts()
        {
            Console.Clear();
            Console.WriteLine("******************************");
            Console.WriteLine("*Produits en quantité limitée*");
            Console.WriteLine("******************************");
            foreach (var item in stock)
            {
                if(item.AmountInStock < Product.minThreshold)
                {
                    Console.WriteLine(item);
                }
                
            }
            BackToMenu();
        }

        public static void ChangeStockAmount(string changeType)
        {
            Console.Clear();
            //Demander à l'utilisateur de spécifier l'id du produit dont la quantité en stock doit être augmentée
            var productId = getProductId();

            //Avec l'Id du produit récupérée je cherche l'objet concerné 
            var product = getProductById(productId);

            //Demander à l'utilisateur de spécifier la quantité à ajouter
            Console.WriteLine("Veuillez saisir la quantité du produit " + product.Name);
            var amout = Int32.Parse(Console.ReadLine());

            //Augmenter la quantité du produit sélectionné
            var success = false;
            if(changeType == "increase")
                success = product.IncreaseAmountInStock(amout);
            else
                success = product.DecreaseAmountInStock(amout);

            if(success)
                Console.WriteLine("La quantité a été mise à jour avec succès");
            else
                Console.WriteLine("Erreur! Le stock n'a pas été mis à jour");

            BackToMenu();
        }

        public static int getProductId()
        {
            Console.WriteLine("Veuillez sélectionner le numéro du produit concerné ");
            ShowProducts();
            return Int32.Parse(Console.ReadLine());
        }

        public static Product getProductById(int id)
        {
            foreach (var item in stock)
            {
                if (item.Id == id) return item;
            }
            return new Product();
        }

        public static void AddNewProduct()
        {
            Console.Clear();
            //Récupérer le nom
            var name = GetProperty("Nom du produit");
            //Récupérer le prix
            var currency = Currency.Euro;
            if (Enum.TryParse(GetProperty("Devise : Euro, Dollar ou Pound"), out Currency currencyInput))
                currency = currencyInput;
            var value = Double.Parse(GetProperty("Prix unitaire"));
            Price price = new Price(value, currency);

            //Récupérer l'unité
            var unitType = UnitType.PerItem;
            if (Enum.TryParse(GetProperty("Unité de mesure : PerItem, PerKg ou PerBox"), out UnitType unitTypeInput))
                unitType = unitTypeInput;

            //Récupérer le maxThreshold
            var maxThreshold = Int32.Parse(GetProperty("Seuil de stock maximal"));

            //Récupérer amountInStock
            var amountInStock = Int32.Parse(GetProperty("Quantité à stocker"));

            //Récupérer Description
            var description = GetProperty("description");

            //Console.WriteLine("Add New Product");

            //Créer une nouvelle instance de l'objet Product
            Product product = new Product(GetLastId()+1, name, price, unitType, maxThreshold, amountInStock, description);

            //Ajouter le nouvel objet à la liste stock
            stock.Add(product);
            BackToMenu();
        }

        public static int GetLastId()
        {
            return stock.Last<Product>().Id ;
        }

        public static string GetProperty(string propertyName)
        {
            Console.WriteLine("Veuillez saisir la valeur de la propriété : " + propertyName);
            return Console.ReadLine();
        }

        public static void ShowStock() {
            //afficher 
            Console.Clear();
            Console.WriteLine("******************************");
            Console.WriteLine("*****Etat actuel du stock*****");
            Console.WriteLine("******************************");

            ShowProducts();

            BackToMenu();
        }

        public static void ShowProducts()
        {
            foreach (Product item in stock)
            {
                Console.WriteLine(item);
            }
        }

        public static void BackToMenu()
        {
            Console.WriteLine("Tapez 0 pour revenir au menu principal");
            if (Console.ReadLine() == "0")
                ShowMenu();
        }
    }
}
