using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters;

public abstract class Hero
{
    protected Hero(string username, int level)
    {
        Username = username;
        Level = level;
    }

    public string Username { get; set; }
    public int Level { get; set; }

    public override string ToString()
    {
        return $"Type: {GetType().Name} Username: {Username} Level: {Level}";
    }
}


//Create a class Hero. It should contain the following members:
// A constructor, which accepts:
//o username – string
//o level – int
// The following properties:
//o Username - string
//o Level – int
// ToString() method
//Hint: Override ToString() of the base class in the following way:
//    return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";}

