using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    public abstract class Coin
    {
        protected double value;
        public double Value { set; get; }
        protected string name;
    }
}
