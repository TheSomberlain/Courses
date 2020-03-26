using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1stWebApp.StudentsMiddleware
{
    public class SudentsRemoveMiddleware
    {
        private readonly RequestDelegate _next;
        public SudentsRemoveMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ICollectionService<Student> st)
        {
            string name = context.Request.Query["name"];
            st.removeAll(name);
            await context.Response.WriteAsync("Successfully removed.");
        }
    }
}
