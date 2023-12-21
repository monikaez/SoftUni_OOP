using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;

public abstract class Product
{
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
}
//The Product class must have the following members:
// A constructor with the following parameters:
//o Name – string
//o Price – decimal
//Beverage and Food classes are products.

//HotBeverage and ColdBeverage are beverages and they accept the following parameters upon initialization: 
//string name, decimal price, double milliliters.Reuse the constructor of the inherited class.
//Coffee and Tea are hot beverages.The Coffee class must have the following additional members:
// double CoffeeMilliliters = 50
// decimal CoffeePrice = 3.50
// Caffeine – double
//The Food class must have the following members:
// A constructor with the following parameters: string name, decimal price, double grams
//o Name – string
//o Price – decimal
//o Grams – double
//MainDish, Dessert, and Starter are food.They all accept the following parameters upon initialization: string
//name, decimal price, double grams.Reuse the base class constructor.
//Dessert must accept one more parameter in its constructor: double calories, and has a property:
// Calories
//Make Fish, Soup and Cake inherit the proper classes.
//The Cake class must have the following default values:
// Grams = 250
// Calories = 1000
// CakePrice = 5
//A Fish must have the following default values:
// Grams = 22
//Zip your solution without the bin and obj folders and upload it to Judge
