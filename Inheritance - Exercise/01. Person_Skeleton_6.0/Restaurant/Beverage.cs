using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;

public abstract class Beverage : Product
{
    protected Beverage(string name, decimal price,double milliliters) : base(name, price)
    {
        Milliliters = milliliters;
    }

    public double Milliliters { get; private set; }
}
//The Beverage class must have the following members:
// A constructor with the following parameters: string name, decimal price, double milliliters
//o Reuse the constructor of the inherited class
// Name – string
// Price – decimal
// Milliliters – double
