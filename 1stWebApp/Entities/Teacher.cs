using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1stWebApp.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<TeacherDiscipline> TeacherDisciplines { get; set; }
    }
}
