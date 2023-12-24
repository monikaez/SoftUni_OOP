using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public abstract class Client : IClient
{
    private string name;
    private string id;
    private int interest;
    private double income;

    //string name, string id, int interest, double income
    protected Client(string name, string id, int interest, double income)
    {
        this.name = name;
        this.id = id;
        this.interest = interest;
        this.income = income;
    }

    //•	Name – string
    //    o If the Name is null or whitespace, throw a new ArgumentException with the message: 
    //"Client name cannot be null or empty."

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ClientNameNullOrWhitespace);
            }
            name = value;
        }
    }
    //•	Id - string
    //    o If the ID is null or whitespace, throw a new ArgumentException with the message: 
    //"Client’s ID cannot be null or empty."

    public string Id
    {
        get => id;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ClientIdNullOrWhitespace);
            }
            id = value;
        }
    }
    //•	Interest – int
    //o The client’s interest.Be careful with the access modifier.

    public int Interest
    {
        get => interest;
        protected set
        {
            this.interest = value;
        }
    }
    //•	Income - double
    //    o The client’s income
    //o If the income is below or equal to 0, throw an ArgumentException with the message:
    //"Income cannot be below or equal to 0."

    public double Income
    {
        get => income;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(string.Format(ExceptionMessages.ClientIncomeBelowZero)));
            }
            income = value;

        }
    }

    public virtual void IncreaseInterest() { }
}
