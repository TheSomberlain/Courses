﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1stWebApp.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public Teacher Teacher { get; set; }
    }
}
