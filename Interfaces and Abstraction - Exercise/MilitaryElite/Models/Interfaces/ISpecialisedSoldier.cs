using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MilitaryElite.Models.Interfaces;

public interface ISpecialisedSoldier : IPrivate
{
    Corps Corps { get; }
}
//SpecialisedSoldier - general class for all specialized Soldiers - holds the corps of the
//Soldier.The corps can only be one of the following: Airforces or Marines.