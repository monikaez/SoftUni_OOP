using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Interfaces;

public interface IRepair
{
    string PartName { get; }
    int HoursWorked { get; }
}
//Engineer - holds a set of Repairs. A Repair holds a part name and hours worked(int)