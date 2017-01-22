using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Checkout
{
    public class CashRegister
    {
        private readonly IEnumerable<IProduct> catalog;
        private readonly IEnumerable<IDiscount> discounts;

        public CashRegister(IEnumerable<IProduct> products, IEnumerable<IDiscount> discounts)
        {
            this.catalog = products;
            this.discounts = discounts;
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
            totalDiscount = discounts.Sum(discount => CalculateDiscount(discount, cart));

            return total - totalDiscount;
        }

        private int PriceFor(char sku)
        {
            return catalog.Single(p => p.SKU == sku).Price;
        }

        private int CalculateDiscount(IDiscount discount, char[] cart)
        {
            int itemCount = cart.Count(item => item == discount.SKU);
            return (itemCount / discount.Quantity) * discount.Value;
        }
    }
}
