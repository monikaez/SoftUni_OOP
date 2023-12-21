using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Interfaces;

public interface ICommando : ISpecialisedSoldier
{
    IReadOnlyCollection<IMission> Missions { get; }
}
//Commando - holds a set of Missions. A mission holds a code name and a state (inProgress or Finished).
//A Mission can be finished through the method CompleteMission().

