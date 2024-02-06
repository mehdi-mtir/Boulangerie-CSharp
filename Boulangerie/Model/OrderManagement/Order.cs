using Boulangerie.Model.OrderMangement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulangerie.Model.OrderManagement
{
    public class Order
    {
        public int Id { get; set; }
        private static int lastId = 0;
        public DateTime OrderDate { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }

        public Order() {
            Id = ++lastId;
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }

        public Order(DateTime orderDate, List<OrderItem> orderItems ) {
            Id = ++lastId; 
            OrderDate = orderDate;
            OrderItems = orderItems;
        }

        public void addItem(OrderItem item)
        {
            OrderItems.Add( item );
        }

        public override string ToString()
        {
            string display = $"\nOrdre : {this.Id} -- Commandé le : {this.OrderDate.ToString()} \n";
            foreach (var item in OrderItems)
            {
                display += "\t" + item.ToString() + "\n";
            }

            return display;
        }


    }
}
