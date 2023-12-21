using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models;
//Each product should have a name and a cost.
//The name cannot be an empty string. Money cannot be a negative number. 
public class Product
{
    private string name;
    private decimal cost;

    public Product(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameEmpty);
            }

            name = value;
        }
    }

    public decimal Cost
    {
        get => cost;
        private set
        {
            if (value < 0)
            {
                //For judge exception message should start with money
                throw new ArgumentException(ExceptionMessages.MoneyNegative);
            }

            cost = value;
        }
    }
}
