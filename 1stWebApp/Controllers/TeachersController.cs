using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1stWebApp.Models;
using _1stWebApp.Entities;
using System.Reflection;
using _1stWebApp.utils.reflect;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                var teacher = await db.Teachers.AsNoTracking()
                        .Include(t => t.Students)
                        .Include(t => t.TeacherDisciplines)
                        .Select(x=>new {x.Id,x.Name,students = x.Students.OrderBy(z=>z.Id).ToArray(),
                                                    discipline = x.TeacherDisciplines.Select(z=>z.Discipline)})
                        .Where(t => t.Id == id || id ==null).ToArrayAsync();
                if (teacher == null) return NotFound();
                return Ok(teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(409);
            }
        }

        [HttpDelete("delete/{id?}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var st = await db.Teachers.FindAsync(id);
                db.Remove(st);
                var student = await db.Students.Where(s => s.TeacherId == id).ToArrayAsync();
                foreach (var item in student)
                {
                    item.TeacherId = null;
                }
                var disciplineTeacher = await
                    db.TeacherDisciplines.Where(z => z.TeacherId == id).Select(x => x.DisciplineName).ToArrayAsync();
                foreach (var item in disciplineTeacher)
                {
                    db.TeacherDisciplines.Remove(await db.TeacherDisciplines.FindAsync(id, item));
                }    
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
        public async Task<IActionResult> Create([FromForm] string name)
        {
            if (name == null) return StatusCode(409);
            var st = new Teacher { Name = name };
            db.Teachers.Add(st);
            await db.SaveChangesAsync();
            return StatusCode(201, st);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] TeacherModel model)
        {
            if (model?.Name == null) return StatusCode(409);
            try
            {
                var st = new Teacher { Id = id, Name = model.Name };
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
        public async Task<IActionResult> UpdatePartionally(int id, [FromForm] TeacherModel model)
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
