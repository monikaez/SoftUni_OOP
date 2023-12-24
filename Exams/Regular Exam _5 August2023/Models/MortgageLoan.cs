using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public class MortgageLoan : Loan
{//The mortgage loan has an interest rate of 3 and an amount of 50 000.
    private const int MortgageLoanInterestRate = 3;
    private const double MortgageLoanAmount = 50_000;
    public MortgageLoan() : base(MortgageLoanInterestRate, MortgageLoanAmount)
    {
    }
}
