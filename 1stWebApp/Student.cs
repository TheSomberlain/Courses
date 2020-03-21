using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1stWebApp
{
    public class Student
    {
        public byte Age { get; set; }
        public string Name { get; set; }

        public Student(byte age, string name)
        {
            Age = age;
            Name = name;
        }

    }
}
