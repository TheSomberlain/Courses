using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using _1stWebApp.StudentsMiddleware;

namespace _1stWebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMyLogger, MyLogger>();
            services.AddSingleton<ICollectionService<Student>, StudentsService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMyLogger myLogger, ICollectionService<Student> st)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Use(async (context, next) => {

                try
                {
                    await next.Invoke();
                }
                catch(Exception ex)
                {
                    await context.Response.WriteAsync("Error");
                    myLogger.WriteConsole(ex.Message);
                    myLogger.WriteFile(ex.Message);
                }
                
            });
            app.Map("/students", students => {
                students.MapWhen(context => {
                    return context.Request.Query.ContainsKey("name")
                        && context.Request.Query.ContainsKey("age") 
                        && context.Request.Path.Value.ToString() == "/add";
                }, a => a.UseMiddleware<StudentsAddMiddleware>());

                students.Map("/view", a => {
                    a.UseMiddleware<StudentsViewMiddleware>();
                });

                students.MapWhen(context => {
                return context.Request.Path.Value.ToString() == "/remove"
                    && context.Request.Query.ContainsKey("name");
                }, a => a.UseMiddleware<SudentsRemoveMiddleware>());
            });
            app.Run(async (context) =>
            {
                st.add(new Student(12, "Kolya"));
                st.add(new Student(13, "Vasya"));
                st.add(new Student(14, "Lyosha"));
                st.add(new Student(15, "Miha"));
                await context.Response.WriteAsync(myLogger.WriteConsole("smmth"));
            });

        }
    }
}
