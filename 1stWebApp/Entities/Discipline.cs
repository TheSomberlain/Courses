using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _1stWebApp.Entities
{
    public class Discipline
    { 
        [Key]
        public string Name { get; set; }

        public IEnumerable<TeacherDiscipline> TeacherDisciplines { get; set; }
    }
}
