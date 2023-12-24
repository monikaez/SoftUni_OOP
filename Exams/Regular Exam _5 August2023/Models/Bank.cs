using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BankLoan.Models;

public abstract class Bank : IBank
{
    private string name;
    private int capacity;
    private List<ILoan> loans;
    private List<IClient> clients;

    //string name, int capacity
    protected Bank(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        this.loans = new List<ILoan>();
        this.clients = new List<IClient>();
    }

    //•	Name - string 
    //    o If the name is null or whitespace, throw an ArgumentException with the message: 
    //"Bank name cannot be null or empty."
    //o All names are unique.

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
            }
            name = value;
        }
    }
    //•	Capacity - int
    //o The number of clients а Bank can have.

    public int Capacity
    {
        get => capacity;
        private set => capacity = value;
    }

    //•	Loans - IReadOnlyCollection<ILoan>
    public IReadOnlyCollection<ILoan> Loans => this.loans;
    //•	Clients - IReadOnlyCollection<IClient>
    public IReadOnlyCollection<IClient> Clients => this.clients;


    //    void AddClient(IClient client)
    //Adds a Client in the Bank if there is a capacity for it.
    //If there is not enough capacity to add the Client to the Bank, throw an ArgumentException with the following message:
    //•	"Not enough capacity for this client."

    public void AddClient(IClient client)
    {
        if (this.Clients.Count < this.Capacity)
        {
            this.clients.Add(client);
        }
    }

    public void AddLoan(ILoan loan) => this.loans.Add(loan);

    //Returns a string with information about the Bank in the format below. 
    //"Name: {bankName}, Type: {bankTypeName}
    //Clients: {clientName1
    //}, {clientName2} ... / Clients: none
    //Loans: { loansCount}, Sum of Rates: { sumOfInterestRates}
    //"

    public string GetStatistics()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
        sb.Append($"Clients: ");

        if (this.clients.Count == 0)
        {
            sb.AppendLine("none");
        }
        else
        {
            var names = clients.Select(c => c.Name).ToArray();
            foreach (var client in this.clients)
                sb.AppendLine(string.Join(", ", names));
        }

        sb.AppendLine($"Loans: {this.loans.Count}, Sum of Rates: {this.SumRates()}");

        return sb.ToString().TrimEnd();
    }

    //void RemoveClient(IClient client)
    /*Removes a Client from the Bank.It is important to note that you will always receive clients that have already been created within the application.*/

    public void RemoveClient(IClient Client) => this.clients.Remove(Client);

    //double SumRates()
    //Returns the sum of the interest rates of each loan in the Bank.

    public double SumRates()
    {
        if (this.Loans.Count == 0)
        {
            return 0;
        }
        return double.Parse(this.Loans.Select(l => l.InterestRate).Sum().ToString());
    }
}
