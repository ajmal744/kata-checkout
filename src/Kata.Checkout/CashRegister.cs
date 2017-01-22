using System;

namespace Kata.Checkout
{
    public class CashRegister
    {
        public int Scan(String scan)
        {
            if (String.IsNullOrEmpty(scan))
            {
                return 0;
            }

            return -1;
        }
    }
}
