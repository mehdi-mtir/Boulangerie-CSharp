using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boulangerie.Model.Shared;

namespace Boulangerie.Model.Product
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
        public static int minThreshold = 10;

        public int Id { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value.Length > 50 ? value[..50] : value; }
        }
        public string? Description
        {
            get { return description; }
            set
            {
                if (value == null)
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

        public Product(int id) : this()
        {
            Id = id;
        }

        public Product(int id, string name, Price price, UnitType unitType, int maxThreshold, int amountInStock, string? description)
        {
            Id = id;
            Name = name;
            UnitPrice = price;
            UnitType = unitType;
            this.maxThreshold = maxThreshold;
            AmountInStock = amountInStock;
            Description = description;
        }


        //surcharge de methodes
        public void IncreaseAmountInStock()
        {
            AmountInStock++;
        }

        public bool IncreaseAmountInStock(int amount)
        {
            if (AmountInStock + amount > maxThreshold)
                return false;
            else
            {
                AmountInStock += amount;
                return true;
            }

        }

        public void DecreaseAmountInStock()
        {
            AmountInStock--;
        }

        public bool DecreaseAmountInStock(int amount)
        {
            if (AmountInStock - amount < 0)
                return false;
            else
            {
                AmountInStock -= amount;
                return true;
            }
        }



        public override string ToString()
        {
            return $"{Id}. Produit : {Name} --- Quantité : {AmountInStock} {UnitType}  --- Prix : {UnitPrice.ItemPrice} {UnitPrice.Currency}";
        }





    }
}
