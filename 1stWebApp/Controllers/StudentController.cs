using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1stWebApp.Models;
using _1stWebApp.Entities;
using System.Reflection;

namespace _1stWebApp.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly MyDbContext db;
        public StudentController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet("view/{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var items = db.Students.ToArray();
                return Ok(items);
            }
            else
            {
                var st = db.Students.Where(x => x.Id == id);
                return Ok(st);
            }
        }

        [HttpDelete("remove/{id?}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var st = await db.Students.FindAsync(id);
                db.Remove(st);
                await db.SaveChangesAsync();
                return Ok();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] int? score, string name)
        {
            if (score == null || name == null) return StatusCode(409);
            var st = new Student { Score = (int)score, Name = name };
            db.Students.Add(st);
            await db.SaveChangesAsync();
            return StatusCode(201, st);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] StudentModel model)
        {
            if (model == null || model.Score == null || model.Name == null) return StatusCode(409);
            try
            {
                var st = new Student { Id = id, Name = model.Name, Score = (int)model.Score };
                db.Students.Update(st);
                await db.SaveChangesAsync();
                return Ok(st);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdatePartionally(int id, [FromForm] StudentModel model)
        {
            if (model == null) return StatusCode(409);
            try
            {
                var st = await db.Students.FindAsync(id);
                foreach (PropertyInfo modelProp in model.GetType().GetProperties())
                {
                    foreach (PropertyInfo entityProp in st.GetType().GetProperties())
                    {
                        if (entityProp.Name == modelProp.Name
                           && modelProp.GetValue(model, null) != null)
                        {
                            entityProp.SetValue(st, modelProp.GetValue(model, null));
                        }
                    }
                }
                db.Students.Update(st);
                await db.SaveChangesAsync();
                return Ok(st);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(409);
            }
        }
    }
}
