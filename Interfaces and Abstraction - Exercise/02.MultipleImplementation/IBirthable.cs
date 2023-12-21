using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo;
public interface IBirthable
{
    string Birthdate { get; }
}
//interface IBirthable with a string property Birthdate and implement them in the Citizen class