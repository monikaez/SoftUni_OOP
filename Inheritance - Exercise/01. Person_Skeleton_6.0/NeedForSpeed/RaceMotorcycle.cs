using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed;

public class RaceMotorcycle : Motorcycle
{
    // RaceMotorcycle – DefaultFuelConsumption = 8
    private const double DefaultFuelConsumption = 8;

    public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
    {
    }
    public override double FuelConsumption => DefaultFuelConsumption;

}
