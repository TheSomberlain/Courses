using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _1stWebApp.Entities;

namespace _1stWebApp.StudentsMiddleware
{
    public class StudentsViewMiddleware
    {
        private readonly RequestDelegate _next;
        public StudentsViewMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, MyDbContext db)
        {
            string path = context.Request.Path.Value.ToString();
            string name = path.Replace("/", ""); 
            IEnumerable<Student> list = db.Students.Where( x => x.Name == name);
            string responseString = JsonConvert.SerializeObject(list, Formatting.Indented);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(responseString);
        }
    }
}
