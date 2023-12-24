using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models;

public class NaturalClimber : Climber
{
    //•	Will NOT be allowed to climb peaks with extreme difficulty level.
    //•	Will have an initial Stamina of 6 units.
    

    private const int NaturalClimberStamina = 6;
    public NaturalClimber(string name) : base(name, NaturalClimberStamina)
    {
       
    }

    //•	Will recover 2 units of Stamina for every day of rest in the base camp.
    public override void Rest(int daysCount)
    {
        Stamina += daysCount*2;
    }
}
