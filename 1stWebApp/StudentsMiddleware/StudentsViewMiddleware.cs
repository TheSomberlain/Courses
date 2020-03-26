using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1stWebApp.StudentsMiddleware
{
    public class StudentsViewMiddleware
    {
        private readonly RequestDelegate _next;
        public StudentsViewMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ICollectionService<Student> st)
        {
            string path = context.Request.Path.Value.ToString();
            string name = path.Replace("/", "");
            IEnumerable<Student> list = st.GetStudents(name);
            string responseString = JsonConvert.SerializeObject(list, Formatting.Indented);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(responseString);
        }
    }
}
