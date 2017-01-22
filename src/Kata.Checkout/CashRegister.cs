using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Checkout
{
    public class CashRegister
    {
        private Dictionary<char, int> catalog;

        public CashRegister()
        {
            catalog = new Dictionary<char, int>() {
                { 'A', 50 },
                { 'B', 30 },
                { 'C', 20 },
                { 'D', 15 }
            };
        }

        public int Scan(String scan)
        {
            var total = 0;

            if (String.IsNullOrEmpty(scan))
            {
                return total;
            }

            var items = scan.ToCharArray();
            total = items.Sum(item => PriceFor(item));

            return total;
        }

        private int PriceFor(char sku)
        {
            int price = 0;
            catalog.TryGetValue(sku, out price);
            return price;
        }
    }
}
