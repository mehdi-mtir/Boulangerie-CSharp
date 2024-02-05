using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulangerie.Model
{
    public class Price
    {
        public int Id { get; set; }
        public double ItemPrice { get; set; }
        public Currency Currency { get; set; }

        public Price(double itemPrice, Currency currency) {
            ItemPrice = itemPrice;
            Currency = currency;
        }
    }
}
