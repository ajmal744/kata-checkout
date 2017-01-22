using System;

namespace Kata.Checkout
{
    public interface ICashRegister
    {
        ICashRegister Scan(String scan);
        int Total();
        char[] ScannedProducts { get; }
    }
}
