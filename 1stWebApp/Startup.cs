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
            /*app.Use(async (context,next) => {
                if (context.Request.Path.Value.EndsWith("error")) throw new Exception("Exception middleware triggered");
            });*/
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
                        if (!Regex.IsMatch(name, @"^[a-zA-Z]+$") || !Char.IsUpper(name.First())) throw new Exception("Invalid Name");
                        Student student = new Student((byte)age,name);
                        st.add(student);
                        await context.Response.WriteAsync("Successfully added.");
                    });        
                }); ;
            });

            app.Map("/students/view", students => {

                students.Run(async context => {
                    string path = context.Request.Path.Value.ToString();
                    string name = path.Replace("/", "");
                    string reponseString = "";
                    if (name == "")
                    {
                        reponseString = st.viewAll();
                        await context.Response.WriteAsync(reponseString);
                        return;
                    }
                    IEnumerable<Student> list = st.GetStudents(name);
                    foreach(Student item in list)
                    {
                        reponseString += st.view(item);
                    }
                    await context.Response.WriteAsync(reponseString);
                });
            });
            app.Map("/students/remove", students => {
                students.MapWhen(context =>
                {
                    return context.Request.Query.ContainsKey("name");
                },
                handle => {
                    handle.Run(async context =>
                    {
                        string name = context.Request.Query["name"];
                        st.removeAll(name);
                        await context.Response.WriteAsync("Successfully removed.");
                    });
                }); ;
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
