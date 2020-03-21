using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1stWebApp
{
    public class MyLogger : IMyLogger
    {
        public string WriteConsole(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
            return s;
        }

        public string WriteFile(string s)
        {
            throw new NotImplementedException();
        }
    }
}
