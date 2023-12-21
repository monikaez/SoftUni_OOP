using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models;

public class Tiger : Feline
{//Tiger-1
    private const double TigerWeightMultiplier = 1;
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
    }

    protected override double WeightMultiplier => TigerWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type> { typeof(Meat)};
    //Cats eat vegetables and meat
    public override string ProduceSaund() => "ROAR!!!";//Tiger – "ROAR!!!"

}

