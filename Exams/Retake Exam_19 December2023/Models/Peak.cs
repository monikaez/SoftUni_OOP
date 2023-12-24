using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models;

public class Peak : IPeak
{
    private string name;
    private int elevation;
    private string difficultyLevel;

    //string name, int elevation, string difficultyLevel
    public Peak(string name, int elevation, string difficultyLevel)
    {
        this.name = name;
        this.elevation = elevation;
        this.difficultyLevel = difficultyLevel;
    }

    // Name - string  o If the name is null or whitespace, throw a new ArgumentException with the following message: 
    //"Peak name cannot be null or whitespace."

    public string Name 
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
            }
            name = value;
        }
        
    }
    //•	Elevation - int
    //o Represents the elevation of the specific peak in meters.
    //o Must be a positive value.If not, throw a new ArgumentException with the message: "Peak elevation must be a positive value."

    public int Elevation 
    {
        get => elevation;
        private set
        {
            if (value <0)
            {
                throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
            }
            elevation = value;
        }
    }
    //•	DifficultyLevel – string
    //o Represents the level of difficulty to climb the specific peak.The property is allowed to accept the following options only: "Extreme", "Hard" or "Moderate". This validation will occur in the AddPeak method in the Controller class.


    public virtual string DifficultyLevel 
    { get => difficultyLevel;
        private set
        {
            difficultyLevel = value;
        }
    }

    //Override ToString() method:
//    Overrides the existing method ToString() and modify it, so the returned string must be on a single line, in the following format:
//"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}"

    public override string ToString()
    {
        return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
    }
}
