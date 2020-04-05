using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _1stWebApp.Entities
{
    public class TeacherDiscipline
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [ForeignKey("Discipline")]
        public string DisciplineName { get; set; }
        public Discipline Discipline { get; set; }
    }
}
