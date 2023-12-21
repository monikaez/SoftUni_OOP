using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models;

public class Hen : Bird
{
    private double HenWeightMultiplier = 0.35;
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override double WeightMultiplier => HenWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type> { typeof(Meat),typeof(Vegetable),typeof(Fruit),typeof(Seeds) };

    
    public override string ProduceSaund() => "Cluck";
}

