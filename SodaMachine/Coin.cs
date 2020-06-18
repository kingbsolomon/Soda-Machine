using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    public abstract class Coin
    {
        protected double value;
        public double Value { get => value; }
        public string name;
    }
}
