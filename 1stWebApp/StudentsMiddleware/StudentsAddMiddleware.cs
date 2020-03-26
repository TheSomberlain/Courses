using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _1stWebApp.Entities;

namespace _1stWebApp.StudentsMiddleware
{
    public class StudentsAddMiddleware
    {
        private readonly RequestDelegate _next;
        public StudentsAddMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, MyDbContext db)
        {
            string queryName = context.Request.Query["age"];
            int age = Int32.Parse(queryName);
            string name = context.Request.Query["name"];
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$") || !Char.IsUpper(name.First())) throw new Exception("Invalid Name");
            //Student student = new Student((byte)age, name);
            //st.add(student);
            var st = new Student { Name = name, Score = age };
            db.Students.Add(st);
            await db.SaveChangesAsync();
            await context.Response.WriteAsync("Successfully added.");
        }
    }
}
