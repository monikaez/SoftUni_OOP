using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

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

    public abstract string ProduceSound();

    protected abstract IReadOnlyCollection<Type> PreferredFoodTypes { get; }
    //protected abstract IreadOnlyCollection<Type> PreferredFoodType{get;}
    public void Eat(IFood food)//void Eat(IFood food)
    {
        if (!PreferredFoodTypes.Any(pf => food.GetType().Name == pf.Name))
        {//if(!PreferredFoodTypes.Any(pf=>food.GetType().Name == pf.Name))
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            //throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        //Weight +=food.Quantity* WeightMultiplier;
        Weight += food.Quantity * WeightMultiplier;
        //FoodEaten += food.Qqantity;
        FoodEaten += food.Quantity;
    }

    public override string ToString()
        => $"{GetType().Name} [{Name}, ";
    //=> $"{GetType().Name}" [{Name}, ";
   
  
}
