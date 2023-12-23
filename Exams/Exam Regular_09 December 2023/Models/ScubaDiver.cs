using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models;

public class ScubaDiver : Diver
{
    //It has OxygenLevel value of 540 seconds
    private const int ScubaDiverOxygenLevel = 540;
    private const double ScubaDiverOxyDecreaseIndex = 0.3;
    public ScubaDiver(string name) : base(name, ScubaDiverOxygenLevel)
    {
    }

    public override void Miss(int timeToCatch)
    {
        int usedOxy = (int)Math.Round(ScubaDiverOxygenLevel * ScubaDiverOxyDecreaseIndex);
        base.OxygenLevel -= usedOxy;
    }

    public override void RenewOxy()
    {
        base.OxygenLevel = ScubaDiverOxygenLevel;
    }
}
