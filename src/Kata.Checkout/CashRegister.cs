using System;
using System.Collections.Generic;

namespace Kata.Checkout
{
    public class CashRegister
    {
        private Dictionary<string, int> catalog;

        public CashRegister()
        {
            catalog = new Dictionary<string, int>() {
                { "A", 50 },
                { "B", 30 },
                { "C", 20 },
                { "D", 15 }
            };
        }

        public int Scan(String scan)
        {
            var price = -1;

            if (String.IsNullOrEmpty(scan))
            {
                return 0;
            }

            catalog.TryGetValue(scan, out price);

            return price;
        }
    }
}
