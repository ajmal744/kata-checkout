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

            switch(scan) {
                case "A":
                    return 50;
                case "B":
                    return 30;
                case "C":
                    return 20;
                case "D":
                    return 15;
            }

            return -1;
        }
    }
}
