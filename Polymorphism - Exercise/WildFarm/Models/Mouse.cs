using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models;

public class Mouse : Mammal
{//Mouse - 0.10
    private const double MouseWeightMultiplier = 0.1;

    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    {
    }

    protected override double WeightMultiplier
        => MouseWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFood =>new HashSet<Type> { typeof(Vegetable), typeof(Fruit) };

    public override string ProduceSaund() => "Squeak";
    //Mouse – "Squeak"

    public override string ToString()
        => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
}
