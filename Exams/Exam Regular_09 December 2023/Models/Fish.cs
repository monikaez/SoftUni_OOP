using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models;

public  abstract class Fish : IFish
{
    private string ?name;
    private double points;
    private int timeToCatch;

    public Fish(string? name, double points, int timeToCatch)
    {
        Name = name;
        Points = points;
        this.timeToCatch = timeToCatch;
    }

    //•	Name - string
    //o   If the name is null or whitespace, throw a new ArgumentException with the following message: 
    //"Fish name should be determined."
    public string Name 
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.FishNameNull);
            }
            name = value;
        }
    }
    //o Represents the points a fish will bring to the diver.
    //o Must be a value between 1 and 10, both inclusive.If not, throw a new ArgumentException with the message: "Points must be a numeric value, between 1 and 10."
    //o This number will have at most one decimal place.This means the value can range from a whole number like 1 or 10, to a number with one digit after the decimal point, such as 1.1, 2.5, 3.7, or 9.1.

    public double Points 
    {
        get => points;
        private set
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentException(ExceptionMessages.PointsNotInRange);
            }
            points = value;
        }
    }
    //    •	TimeToCatch – int
    //o   A numerical value representing how many seconds a diver requires to catch the fish.

    public int TimeToCatch => this.timeToCatch;

    public override string ToString()
    {
        return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
    }
}

