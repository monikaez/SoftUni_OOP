using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animalsм
{
   public class Hen:Bird
    {
        private const double HenWeightMultiplier = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier => HenWeightMultiplier;

        protected override IReadOnlyCollection<Type> PreferredFoodTypes 
             => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };
        //new HashSet<Type>(){typeof(Vegetable),typeof(Fruit),typeof(Meat),typeof(Seeds)};
        public override string ProduceSound()=> "Cluck";
        
       
    }
}
