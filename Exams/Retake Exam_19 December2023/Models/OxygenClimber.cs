using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models;

public class OxygenClimber : Climber
{//•	Will be allowed to climb peaks with extreme difficulty level.
    //•	Will have an initial Stamina of 10 units.
    //•	Will recover 1 unit of Stamina for every day of rest in the base camp.
    private const int OxygenClimberStamina = 10;

    public OxygenClimber(string name) : base(name, OxygenClimberStamina)
    {
    }

    public override void Rest(int daysCount)
    {
        Stamina += daysCount;
    }
}
