using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Core.Interfaces;
using Telephony.IO.Interfaces;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony.Core;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }


    public void Run()
    {
        string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        ICallable callable;

        foreach (var phoneNumber in phoneNumbers)
        {
            if (phoneNumber.Length == 10)
            {
                callable = new Smartphone();
            }
            else
            {
                callable = new StationaryPhone();
            }
            try
            {
                writer.WriteLine(callable.Call(phoneNumber));
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
        }

        IBrowsable browsable = new Smartphone();
        foreach (var url in urls)
        {
            try
            {
                writer.WriteLine(browsable.Browse(url));
                // writer.WriteLine(browsable.Browse(url));
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message);
                //writer.WriteLine(ex.Message);
            }

        }
    }
}
