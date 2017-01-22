using System;
using Kata.Checkout;
using Xunit;
using System.Collections.Generic;

namespace Kata.Checkout.Tests
{
    public class CashRegisterTests
    {
        private ICashRegister register;

        public CashRegisterTests()
        {
            IEnumerable<Product> products = new[]
            {
                new Product{SKU = 'A', Price = 50},
                new Product{SKU = 'B', Price = 30},
                new Product{SKU = 'C', Price = 20},
                new Product{SKU = 'D', Price = 15}
            };

            IEnumerable<Discount> discounts = new[]
            {
                new Discount{SKU = 'A', Quantity = 3, Value = 20},
                new Discount{SKU = 'B', Quantity = 2, Value = 15}
            };

            register = new CashRegister(products, discounts);
        }

        [Fact]
        public void No_items_returns_zero()
        {
            Assert.Equal(0, register.Scan("").Total());
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        public void Scan_single_item_expect_correct_price(string item, int expected)
        {
            Assert.Equal(expected, register.Scan(item).Total());
        }

        [Theory]
        [InlineData("AA", 100)]
        [InlineData("AB", 80)]
        [InlineData("ABC", 100)]
        [InlineData("ABCCDD", 150)]
        [InlineData("CDBA", 115)]
        public void Scan_no_discount_combinations_and_expect_total(string scan, int expected)
        {
            Assert.Equal(expected, register.Scan(scan).Total());
        }

        [Theory]
        [InlineData("AAA", 130)]
        [InlineData("AAAB", 160)]
        [InlineData("AAABB", 175)]
        [InlineData("AAAAAA", 260)]
        [InlineData("AAAAAABB", 305)]
        [InlineData("BB", 45)]
        [InlineData("ABB", 95)]
        [InlineData("BBBB", 90)]
        [InlineData("BBBBACD", 175)]
        public void Scan_discounted_combinations_and_expect_correct_total(string scan, int expected)
        {
            Assert.Equal(expected, register.Scan(scan).Total());
        }

        [Theory]
        [InlineData("EEGHKYLP", "")]
        [InlineData("ABCDE", "ABCD")]
        [InlineData("AAAA", "AAAA")]
        public void Scan_should_filter_invalid_sku(string scan, string expected)
        {
            Assert.Equal(
                expected,
                new String(register.Scan(scan).ScannedProducts)
            );
        }
    }
}
