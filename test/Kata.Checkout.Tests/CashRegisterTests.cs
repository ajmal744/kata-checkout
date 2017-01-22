using System;
using Kata.Checkout;
using Xunit;

namespace Kata.Checkout.Tests
{
    public class CashRegisterTests
    {
        private CashRegister register;

        public CashRegisterTests()
        {
            register = new CashRegister();
        }

        [Fact]
        public void No_items_returns_zero()
        {
            Assert.Equal(0, register.Scan(""));
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        public void Scan_single_item_expect_correct_price(string item, int expected)
        {
            Assert.Equal(expected, register.Scan(item));
        }

        [Theory]
        [InlineData("AA", 100)]
        [InlineData("AB", 80)]
        [InlineData("ABC", 100)]
        [InlineData("ABCCDD", 150)]
        [InlineData("CDBA", 115)]
        public void Scan_no_discount_combinations_and_expect_total(string scan, int expected)
        {
            Assert.Equal(expected, register.Scan(scan));
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
            Assert.Equal(expected, register.Scan(scan));
        }
    }
}
