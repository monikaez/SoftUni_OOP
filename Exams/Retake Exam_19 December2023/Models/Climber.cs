using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HighwayToPeak.Models;

public abstract class Climber : IClimber
{
    private string name;
    private int stamina;
    private List<string> conqueredPeaks;
    //string name, int stamina
    protected Climber(string name, int stamina)
    {
        this.name = name;
        this.stamina = stamina;
        this.conqueredPeaks = new List<string>();
    }

    //•	Name - string 
    //    o If the Name is null or whitespace, throw a new ArgumentException with the message: 
    //"Climber's name cannot be null or whitespace."

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
            }
            name = value;
        }
    }
    //•	Stamina – int
    // o The climber's stamina, in the mountains. Must be a value from 0 up to 10, both inclusive.
    //o If it exceeds 10 during any operation, it should be reset to 10.
    //o If it drops below zero during any operation, it should be reset to zero.

    public int Stamina
    {
        get => stamina;
        protected set
        {
            if (value < 0)
            {
                stamina = 0;
            }
            else if (value > 10)
            {
                stamina = 10;
            }
            else
            {
                stamina = value;
            }
        }
    }
    //•	ConqueredPeaks – IReadOnlyCollection<string>
    //o It will store a sequence of names of peaks, conquered by a climber.

    public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks.AsReadOnly();


    //•	If the peak’s DifficultyLevel is "Extreme" - 6 units ;
    //•	If the peak’s DifficultyLevel is "Hard" - 4 units ;

    public void Climb(IPeak peak)
    {
        if (!conqueredPeaks.Contains(peak.Name))
        {
            this.conqueredPeaks.Add(peak.Name);
        }

        int tempStamina = 0;
        if (peak.DifficultyLevel == "Extreme")
        {
            tempStamina += 6;
        }
        else if (peak.DifficultyLevel == "Hard")
        {
            tempStamina += 4;
        }
        else if(peak.DifficultyLevel == "Moderate")
        {
            tempStamina += 2;
        }//•	If the peak’s DifficultyLevel is "Moderate" - 2 units ;

        this.Stamina -= tempStamina;
    }
    //abstract method
    public abstract void Rest(int daysCount);
    //Overrides the existing method ToString() and modifies it, so the returned string is in the following format:
    //"{climberTypeName} - Name: {Name}, Stamina: {Stamina}
    //Peaks conquered: no peaks conquered/{peaksCount}"

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
        sb.Append("Peaks conquered: ");

        if (this.conqueredPeaks.Count > 0)
        {
            sb.AppendLine($"{ConqueredPeaks.Count}");
        }
        else
        {
            sb.Append("no peaks conquered");
        }

        return sb.ToString().Trim();
    }

}
