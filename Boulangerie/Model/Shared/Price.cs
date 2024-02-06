using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulangerie.Model.Shared
{
    public class Price
    {
        public int Id { get; set; }
        private static int lastId = 0;
        public double ItemPrice { get; set; }
        public Currency Currency { get; set; }

        public Price(double itemPrice, Currency currency)
        {
            /*Id = lastId++;


            Id = lastId; //Id = 0
            lastId++ //lastId = 1
           */
            Id = ++lastId;
            /*
             * lastId++ lastId = 1
             * Id = lastid Id = 1
             */


            ItemPrice = itemPrice;
            Currency = currency;
        }
    }
}
