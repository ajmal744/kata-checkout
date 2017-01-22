using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Checkout
{
    public class CashRegister
    {
        private readonly IEnumerable<IProduct> catalog;
        private Dictionary<char, int[]> discounts;

        public CashRegister(IEnumerable<IProduct> products)
        {
            catalog = products;
            discounts = new Dictionary<char, int[]>() {
                { 'A', new int[] { 3, 20 } },
                { 'B', new int[] { 2, 15 } }
            };
        }

        public int Scan(String scan)
        {
            int total = 0;
            int totalDiscount = 0;

            if (String.IsNullOrEmpty(scan))
            {
                return total;
            }

            char[] cart = scan.ToCharArray();

            total = cart.Sum(item => PriceFor(item));
            totalDiscount = discounts.Sum(discount => CalculateDiscount(discount.Key, discount.Value, cart));

            return total - totalDiscount;
        }

        private int PriceFor(char sku)
        {
            return catalog.Single(p => p.SKU == sku).Price;
        }

        private int CalculateDiscount(char sku, int[] discount, char[] cart)
        {
            int itemCount = cart.Count(item => item == sku);
            return (itemCount / discount[0]) * discount[1];
        }
    }
}
