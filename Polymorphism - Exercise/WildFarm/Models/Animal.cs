using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models;

public abstract class Animal : IAnimal
{
    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name { get; private set; }

    public double Weight { get; private set; }

    public int FoodEaten { get; private set; }

    protected abstract double WeightMultiplier { get; }

    protected abstract IReadOnlyCollection<Type> PreferredFood { get; }

    public abstract string ProduceSaund();

    public void Eat(IFood food)
    {
        if (!PreferredFood.Any(pf=>pf.Name == food.GetType().Name))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        Weight += food.Quantity * WeightMultiplier;

        FoodEaten += food.Quantity;
    }

    public override string ToString() => $"{this.GetType().Name} [{Name}, ";

   
}
