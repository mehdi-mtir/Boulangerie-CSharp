using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boulangerie.Model.ProductManagement;
using Newtonsoft.Json;

namespace Boulangerie.Repository
{
    public class ProductRepository
    {
        string filePath = @"C:\Users\Mehdi\source\repos\Boulangerie\Boulangerie\data\products.json";
        public ProductRepository() { }

        public void SaveProducts()
        {
            
            string jsonProducts = JsonConvert.SerializeObject(Utilities.productManger.GetStock());
            //Console.WriteLine(jsonProducts);
            FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(file);
            streamWriter.Write(jsonProducts);
            streamWriter.Close();
            streamWriter.Dispose();

            file.Close();
            file.Dispose();
            Console.WriteLine("La sauvegarde des produits a été réalisée avec succès!");
        }

        public void LoadProducts()
        {
            string jsonProducts = File.ReadAllText(filePath);
            Console.WriteLine(jsonProducts);
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
            Utilities.productManger.SetStock(products);
            Console.WriteLine("La récupération des produits a été réalisée avec succès!");
        }
    }
}
