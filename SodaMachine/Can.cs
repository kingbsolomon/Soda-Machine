using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    abstract class Can
    {
        // member variables

        protected double cost;
        public double Cost { set=>cost=value; get=>cost; }
        public string name;

    }
}
