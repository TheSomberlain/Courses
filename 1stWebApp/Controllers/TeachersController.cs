using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1stWebApp.Models;
using _1stWebApp.Entities;
using System.Reflection;
using _1stWebApp.utils.reflect;

namespace _1stWebApp.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {

        private readonly MyDbContext db;
        public TeacherController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet("view/{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var items = db.Teachers.ToArray();
                return Ok(items);
            }
            else
            {
                var st = await db.Teachers.FindAsync(id);
                return Ok(st);
            }
        }

        [HttpDelete("delete/{id?}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var st = await db.Teachers.FindAsync(id);
                db.Remove(st);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] string discipline, string name)
        {
            if (discipline == null || name == null) return StatusCode(409);
            var st = new Teacher { Discipline = discipline, Name = name };
            db.Teachers.Add(st);
            await db.SaveChangesAsync();
            return StatusCode(201, st);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] TeacherModel model)
        {
            if (model == null || model.Discipline == null || model.Name == null) return StatusCode(409);
            try
            {
                var st = new Teacher { Id = id, Name = model.Name, Discipline = model.Discipline };
                db.Teachers.Update(st);
                await db.SaveChangesAsync();
                return Ok(st);
            }
            catch (Exception e)
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
                var st = await db.Teachers.FindAsync(id);
                Reflection.UpdateEntity(st, model);
                db.Teachers.Update(st);
                await db.SaveChangesAsync();
                return Ok(st);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(409);
            }
        }
    }
}
