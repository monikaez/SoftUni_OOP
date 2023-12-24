using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public class BranchBank : Bank
{
    //Has 25 capacity.
    private const int BranchBankCapacity = 25;
    public BranchBank(string name) : base(name, BranchBankCapacity)
    {
    }
}
