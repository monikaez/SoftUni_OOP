using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models;

public class Cat : Feline
{//Cat - 0.30
    private const double CatWeightMultiplier= 0.30;
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
    }

    protected override double WeightMultiplier => CatWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type> { typeof(Meat),typeof(Vegetable)};
    //Cats eat vegetables and meat
    public override string ProduceSaund() => "Meow";//Cat – "Meow"

}
