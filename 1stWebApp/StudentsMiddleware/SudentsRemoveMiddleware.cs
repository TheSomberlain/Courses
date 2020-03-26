using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1stWebApp.Entities;

namespace _1stWebApp.StudentsMiddleware
{
    public class SudentsRemoveMiddleware
    {
        private readonly RequestDelegate _next;
        public SudentsRemoveMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, MyDbContext db)
        {
            string name = context.Request.Query["name"];
            var query = db.Students.Where(x => x.Name == name);
            foreach (Student st in query)
            {
                db.Students.Remove(st);
            }
            await db.SaveChangesAsync();
            await context.Response.WriteAsync("Successfully removed.");
        }
    }
}
