
using System;


namespace PersonInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string id = Console.ReadLine();
        string birthdate = Console.ReadLine();
        IPerson person = new Citizen(name, age,id,birthdate);
        Console.WriteLine(person.Name);
        Console.WriteLine(person.Age);

        IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        IBirthable birth = new Citizen(name, age, id, birthdate);
        
        Console.WriteLine(identifiable.Id);
        Console.WriteLine(birth.Birthdate);

    }
}