using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Interfaces;

public interface ISpy : ISoldier
{
    int CodeNumber { get; }
}
//Spy - holds the code number of the Spy (int)