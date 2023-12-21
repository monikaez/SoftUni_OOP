using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models;

public class Owl : Bird
{
    private const double OwlWeightMultiplier = 0.25;

    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    { 
    }


    protected override double WeightMultiplier
    => OwlWeightMultiplier;

    public override string ProduceSaund() => "Hoot Hoot";
   
    protected override IReadOnlyCollection<Type> PreferredFood
        => new HashSet<Type>() { typeof(Meat) };

           
}
