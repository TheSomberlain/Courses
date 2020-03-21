using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1stWebApp
{
    public interface IMyLogger
    {
        string WriteConsole(string s);
        string WriteFile(string s);
    }
}
