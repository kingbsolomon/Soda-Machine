using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    public class Card
    {
        protected double availableFunds;
        public double AvailableFunds { set=>availableFunds=value; get=>availableFunds; }

        public Card()
        {
            AvailableFunds = 20.00;
        }
    }
}
