using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace NauticalCatchChallenge.Models;

public abstract class Diver : IDiver
{
    private string name;
    private int oxygenLevel;
    private List<string> @catch;
    private double competitionPoints;
    private bool hasHealthIssues;

    protected Diver(string name, int oxygenLevel)
    {
        Name = name;
        OxygenLevel = oxygenLevel;
        @catch = new List<string>();
        competitionPoints = 0;
        hasHealthIssues = false;
    }

    //    •	Name - string
    //o   If the Name is null or whitespace, throw a new ArgumentException with the message: 
    //"Diver's name cannot be null or empty."

    public string Name 
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.DiversNameNull);
            }
            name = value;
        }


    }
//    •	OxygenLevel – int
//o   A numerical value representing the diver's oxygen level remaining, in seconds. If it drops below zero during any operation, it should be reset to zero.

    public int OxygenLevel 
    {
        get => oxygenLevel;
        protected set
        {
            if (value < 0)
            {
                oxygenLevel = 0;
            }
            else
            {
                oxygenLevel = value;
            }
        }
    }

//    •	Catch – IReadOnlyCollection<string>
//o   It will store a sequence of names of fish, caught by a specific diver.

    public IReadOnlyCollection<string> Catch => @catch;
    //•	CompetitionPoints – double
    //o   Set the initial value of the property to zero.Returns a floating-point number rounded to the first decimal place.Represents the total points accumulated by a diver, based on the type of fish caught during the competition. 

    public double CompetitionPoints => this.competitionPoints;
//    •	HasHealthIssues – bool
//o   The property indicates if the diver has potential health concerns.Its initial value is False, representing that the diver starts in a healthy state.

    public bool HasHealthIssues => this.hasHealthIssues;

    public void Hit(IFish fish)
    {
        OxygenLevel -= fish.TimeToCatch;
        @catch.Add(fish.Name);
        competitionPoints += fish.Points;
    }

    public abstract void Miss(int timeToCatch);

    public abstract void RenewOxy();

    public void UpdateHealthStatus()
    {
        if (!HasHealthIssues)
        {
            hasHealthIssues = true;
        }
        else
        {
            hasHealthIssues = false;
        }
    }

    //    Override ToString() method:
    //Overrides the existing method ToString() and modifies it, so the returned string must be on a single line, in the following format:
    //"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {count}, Points earned: {CompetitionPoints} ]"

    public override string ToString()
    {
        return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
    }


}
