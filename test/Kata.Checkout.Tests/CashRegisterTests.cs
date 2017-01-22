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
    }
}
