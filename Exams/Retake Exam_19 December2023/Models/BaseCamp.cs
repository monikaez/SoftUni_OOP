using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models;

public class BaseCamp : IBaseCamp
{
    private List<string> residents;

    public BaseCamp()
    {
        residents = new List<string>();
    }
    public IReadOnlyCollection<string> Residents => residents.AsReadOnly();

    //A method to record the arrival of a climber at the base camp. It adds the climber's name to the Residents collection.
    public void ArriveAtCamp(string climberName)
    {
        residents.Add(climberName);
        residents = residents.OrderBy(x => x).ToList();
    }

    //It removes the climber's name from the Residents 
    public void LeaveCamp(string climberName)
    {
        residents.Remove(climberName);
    }
}
