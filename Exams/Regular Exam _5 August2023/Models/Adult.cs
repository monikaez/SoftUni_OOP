using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public class Adult : Client
{
    //Has an initial interest of 4 percent
    private const int AdultInterest = 4;
    public Adult(string name, string id, double income) : base(name, id, AdultInterest, income)
    {
    }
    //void IncreaseInterest()
    //•	The method increases the client’s interest by 2 percent.
    public override void IncreaseInterest()
    {
        base.Interest += 2;
    }

}
