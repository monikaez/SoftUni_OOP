using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models;

public class CargoVan : Vehicle
{//CargoVan has a constant value for MaxMileage = 180
    private const double maxMileage = 180;
    public CargoVan(string brand, string model, string licensePlateNumber) : base(brand, model, maxMileage, licensePlateNumber)
    {
    }
}
