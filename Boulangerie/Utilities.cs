using Boulangerie.Model;
using Boulangerie.Repository;
using Boulangerie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulangerie
{
    public class Utilities
    {
        private static string choice = string.Empty;
        public static ProductManager productManger;
        public static OrderManager orderManager;
        public static ProductRepository productRepository;

        public static void InitializeStock()
        {
            productManger = new ProductManager();
            orderManager = new OrderManager();
            productRepository = new ProductRepository();
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
                Console.WriteLine("6. Passer une commande.");
                Console.WriteLine("7. Afficher l'historique des commandes");
                Console.WriteLine("8. Sauvarder les données");
                Console.WriteLine("9. Charger les données");


                choice = Console.ReadLine();

            } while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6" && choice != "7" && choice != "8" && choice != "9");

            switch (choice)
            {
                case "1": productManger.ShowStock(); BackToMenu(); break;
                case "2": productManger.AddNewProduct(); BackToMenu(); break;
                case "3": productManger.ChangeStockAmount("increase"); BackToMenu(); break;
                case "4": productManger.ChangeStockAmount("decrease"); BackToMenu(); break;
                case "5": productManger.ShowLowStockProducts(); BackToMenu(); break;
                case "6": orderManager.CreateNewOrder(); BackToMenu(); break;
                case "7": orderManager.ShowOrders(); BackToMenu(); break;
                case "8": productRepository.SaveProducts(); BackToMenu(); break;
                case "9": productRepository.LoadProducts(); BackToMenu(); break;
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
