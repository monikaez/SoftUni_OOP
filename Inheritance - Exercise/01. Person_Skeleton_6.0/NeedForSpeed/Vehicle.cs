using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed;

public abstract class Vehicle
{
    // DefaultFuelConsumption – double 
    //The default fuel consumption for Vehicle is 1.25. Some of the classes have different default fuel consumption


    private const double DefaultFuelConsumption = 1.25;

    // A constructor that accepts the following parameters: int horsePower, double fuel

    protected Vehicle(int horsePower, double fuel)
    {
        HorsePower = horsePower;
        Fuel = fuel;
    }
    // Fuel – double
    // HorsePower – int

    public int HorsePower { get; set; }
    public double Fuel  { get; set; }

    // FuelConsumption – virtual double
    public virtual double FuelConsumption => DefaultFuelConsumption;

    // virtual void Drive(double kilometers)
    public virtual void Drive(double kilometers) => Fuel -= kilometers * FuelConsumption;


}

//Create a base class Vehicle. It should contain the following members:


//o The Drive method should have a functionality to reduce the Fuel based on the traveled
//kilometers.
//The default fuel consumption for Vehicle is 1.25. Some of the classes have different default fuel consumption
//values:
//Zip your solution without the bin and obj folders and upload it in Judge
