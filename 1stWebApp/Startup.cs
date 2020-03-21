using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _1stWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMyLogger, MyLogger>();
            services.AddSingleton<ICollectionService<Student>, StudentsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMyLogger myLogger, ICollectionService<Student> st)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Use(async (context, next) => {
                await next.Invoke();
            });
            app.Map("/students/add", students => {
                students.MapWhen(context =>
                {
                    return context.Request.Query.ContainsKey("name") && context.Request.Query.ContainsKey("age");
                }, 
                handle => {
                    handle.Run(async context =>
                    {
                        string queryName = context.Request.Query["age"];
                        int age = Int32.Parse(queryName);
                        string name = context.Request.Query["name"];
                        Student student = new Student((byte)age,name);
                        st.add(student);
                    });        
                }); ;
            });
            
      /*      app.Map("/students/view/{name}", students => {
                students.MapWhen(context =>
                {
                    return context.Request.Query.;
                },
                handle => {
                    handle.Run(async context =>
                    {
                        string queryName = context.Request.Query["age"];
                        int age = Int32.Parse(queryName);
                        string name = context.Request.Query["name"];
                        Student student = new Student((byte)age, name);
                        st.add(student);
                    });
                }); ;
            });*/
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(myLogger.WriteConsole("smmth"));
            });

        }
    }
}
