using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core;

public class Controller : IController
{
    //•	loans - LoanRepository 
    //•	banks - BankRepository
    private IRepository<ILoan> loans;
    private IRepository<IBank> banks;

    public Controller()
    {
        this.loans = new LoanRepository();
        this.banks = new BankRepository();
    }

    //AddBank Command
    //Creates a bank from the appropriate type and adds it to the BankRepository.
    //    If the bankTypeName is an invalid type in the application, throw an ArgumentException with the following message:
    //•	"Invalid bank type."
    //If the Bank is added successfully, the method should return the following string:
    //•	"{bankTypeName} is successfully added."

    public string AddBank(string bankTypeName, string name)
    {
        if (bankTypeName != nameof(BranchBank) && bankTypeName != nameof(CentralBank))
        {
            throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
        }
        IBank bank = null;
        if (bankTypeName == nameof(BranchBank))
        {
            bank = new BranchBank(name);
        }
        else if (bankTypeName == nameof(CentralBank))
        {
            bank = new CentralBank(name);
        }
        banks.AddModel(bank);

        return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
    }

    //AddLoan Command
    public string AddLoan(string loanTypeName)
    {//•	loanTypeName - string
     //If the loanTypeName is an invalid type in the application, throw an ArgumentException with the following message:
     //•	"Invalid loan type."
        ILoan loan;
        if (loanTypeName == nameof(MortgageLoan))
        {
            loan = new MortgageLoan();
        }
        else if (loanTypeName == nameof(StudentLoan))
        {
            loan = new StudentLoan();
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
        }
        //add type loan
        this.loans.AddModel(loan);
        return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        
        
        //If the Loan is added successfully, the method should return the following string:
        //•	"{loanTypeName} is successfully added."
        
    }


    //ReturnLoan Command
    public string ReturnLoan(string bankName, string loanTypeName)
    {//•	bankName - string
     //•	loanTypeName - string
        ILoan loan = this.loans.FirstModel(loanTypeName);
        IBank bank = this.banks.FirstModel(bankName);
        //Adds the appropriate ILoan, returned by a client, to the Bank with the given name. You have to remove the Loan from the LoanRepository if the insert is successful.
        //*It is important to note that the bank referenced by the bankName parameter will always exist in the  BankRe*/pository. Therefore, you can assume that the specified bank is valid and present.
        //If there is no such loan, you have to throw an ArgumentException with the following message:
        //•	"Loan of type {loanTypeName} is missing."

        if (loan == null)
        {
            throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
        }
        bank.AddLoan(loan);

        loans.RemoveModel(loan);
        //If no exceptions are thrown, return the String:
        //•	"{loanTypeName} successfully added to {bankName}."
        return String.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
    }


    //AddClient Command
    public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
    {
        //•	If the given clientTypeName is not recognized as a valid type in the application, the method should throw an ArgumentException with the following message:
        //"Invalid client type."
        if (clientTypeName != nameof(Student) && clientTypeName != nameof(Adult))
        {
            throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
        }
        IBank bank = banks.FirstModel(bankName);
        //Make client
        IClient client = null;
        //•	Select from the BankRepository the bank with the given bankName.
        //        o If the given clientTypeName is NOT a valid client type for the selected bank, the following message is returned: 
        //"Unsuitable bank."
        //        o   Otherwise creates and adds client from the appropriate type to the Bank with the given name.The following message should be returned: 
        //"{clientTypeName} successfully added to {bankName}."
        if (clientTypeName == nameof(Student))
        {
            if (bank is BranchBank)
            {
                client = new Student(clientName, id, income);              
            }
            else
            {
                return "Unsuitable bank.";
            }
        }
        else if (clientTypeName == nameof(Adult))
        {
            if (bank is CentralBank)
            {
                client = new Adult(clientName, id, income);
            }
            else
            {
                return "Unsuitable bank.";
            }
        }
        bank.AddClient(client);
        return String.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
    }


    //FinalCalculation Command
    public string FinalCalculation(string bankName)
    {//Calculates all funds that have passed through the Bank with the given name. It is calculated from the sum of all income from clients and amount from loans in the Bank.
        //Return a string in the following format:
        //•	"The funds of bank {bankName} are {funds}."
        //o The funds should be formatted to the 2nd decimal place!
        IBank bank = banks.FirstModel(bankName);

        double totalIncomeOfClients = bank.Clients.Sum(client => client.Income);
        double totalLoansAmount = bank.Loans.Sum(loan => loan.Amount);

        double funds = totalIncomeOfClients + totalLoansAmount;

        return $"The funds of bank {bankName} are {funds:f2}.";
    }


    //Statistics Command
    public string Statistics()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var bank in this.banks.Models)
        {
            sb.AppendLine(bank.GetStatistics());
        }

        return sb.ToString().TrimEnd();
        //"Name: {bankName}, Type: {bankType}
        //Clients: { clientName1}, { clientName2}
        //    ... / Clients: none
        //Loans: { loansCount}, Sum of Rates: { sumOfInterestRates}
    }
}
