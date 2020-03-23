using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _1stWebApp
{
    public class MyLogger : IMyLogger
    {
        public string WriteConsole(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
            Console.WriteLine(s);
            return s;
        }

        public string WriteFile(string s)
        {
            TextWriter tsw = new StreamWriter(@"C:\Users\Reaper\Documents\Courses\1stWebApp\Errors.txt", true);
            tsw.WriteLine(s);
            tsw.Close();
            return s;
        }
    }
}
