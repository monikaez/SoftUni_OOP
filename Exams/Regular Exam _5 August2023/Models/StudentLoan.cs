using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public class StudentLoan : Loan
{//The student loan has an interest rate of 1 and an amount of 10 000.
    private const int StudentLoanInterestRate = 1;
    private const double StudentLoanAmount = 10_000;
    public StudentLoan() : base(StudentLoanInterestRate, StudentLoanAmount)
    {
    }
}
