using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulangerie.Model
{
    public class Product
    {
        /*private int id;

        public int Id {
            get{
                return id;
            }
            set
            {
                id = value;
            }
        } */

        private string name;
        private string? description;
        private int maxThreshold;
        private int minThreshold = 10;
        
        public int Id { get; set; }
        public string Name {
            get { return name; }
            set { name = value.Length > 50 ? value[..50] : value; } 
        }
        public string? Description {
            get { return description; }
            set {
                if(value == null)
                    description = string.Empty;
                else
                    description = value.Length > 250 ? value[..250] : value;
            } 
        }
        public UnitType UnitType { get; set; }
        public int AmountInStock { get; private set; }

        public Price UnitPrice { get; set; }

        
        //Surcharge de constructeurs
        public Product()
        {
            maxThreshold = 10;
            AmountInStock = 0;
            Name = string.Empty;
        }
        
        public Product(int id) : this() {
            this.Id = id;
        }

        public Product(int id, string name, Price price, UnitType unitType, int maxThreshold, int amountInStock, string? description)
        {
            Id  = id;
            Name = name;
            UnitPrice = price;
            UnitType = unitType;
            this.maxThreshold = maxThreshold;
            AmountInStock = amountInStock;
            Description = description;
        }

        public override string ToString()
        {
            return ($"Produit : {this.Name} --- Quantité : {this.AmountInStock} {this.UnitType}  --- Prix : {this.UnitPrice.ItemPrice} {this.UnitPrice.Currency}");
        }





    }
}
