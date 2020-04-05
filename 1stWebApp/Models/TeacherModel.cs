using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1stWebApp.Entities;

namespace _1stWebApp.Models
{
    public class TeacherModel
    {
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; } 
        public IEnumerable<Discipline> Disciplines { get; set; }
    }
}
