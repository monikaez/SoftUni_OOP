using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Interfaces;

public interface ILieutenantGeneral : IPrivate
{
    IReadOnlyCollection<IPrivate> Privates { get; }
}
//LieutenantGeneral - holds a set of Privates under his command.