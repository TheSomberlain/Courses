using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _1stWebApp.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        [JsonIgnore]
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
