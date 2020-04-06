using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace _1stWebApp.Entities
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
    }
}
