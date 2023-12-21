using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.IO.Interfaces;


public interface IWriter
{
    void WriteLine(object obj);
}
