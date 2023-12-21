using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Interfaces;

public interface IAnimal
{
    string Name { get; }
    double Weight { get; }
    int FoodEaten { get; }

    string ProduceSaund();

    void Eat(IFood food);
}
//Animal – string Name, double Weight, int FoodEaten

    

