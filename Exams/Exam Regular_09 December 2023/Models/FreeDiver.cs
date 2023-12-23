using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models;

public class FreeDiver : Diver
{
    //OxygenLevel value of 120 seconds.
    private const int FreeDiverOxygenLevel = 120;
    private const double FreeDiverOxyDecreaseIndex = 0.6;
    public FreeDiver(string name) : base(name, FreeDiverOxygenLevel)
    {
    }

    public override void Miss(int timeToCatch)
    {
        int usedOxy = (int)Math.Round(FreeDiverOxygenLevel * FreeDiverOxyDecreaseIndex);
        base.OxygenLevel -= usedOxy;
    }

    public override void RenewOxy()
    {
        base.OxygenLevel = FreeDiverOxygenLevel;
    }
}
