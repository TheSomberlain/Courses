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
using Newtonsoft.Json;

namespace _1stWebApp.Controllers
{
    [ApiController]
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
            try
            {
                if (id.HasValue)
                {
                    var items = await db.Students.AsNoTracking()
                        .Include(s => s.Teacher)
                        .Where(s => s.Id == id).FirstAsync();
                    return Ok(items);
                }
                else
                {
                    var st = await db.Students
                        .AsNoTracking()
                        .Include(s => s.Teacher)
                        .OrderBy(s => s.Id).ToArrayAsync();
                    if (st == null) return NotFound();
                    return Ok(st);
                }
            }catch(Exception e)
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
        public async Task<IActionResult> Create([FromForm] int? score, string name, int? teacherId)
        {
            try
            {
                if (score == null || name == null) return StatusCode(409);
                var st = new Student { Score = (int)score, Name = name, Teacher = await db.Teachers.FindAsync(teacherId), TeacherId = teacherId };
                db.Students.Add(st);
                await db.SaveChangesAsync();
                return StatusCode(201, st);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(409);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] StudentModel model)
        {
            if (model == null || model.Score == null || model.Name == null) return StatusCode(409);
            try
            {
                var teacher = await db.Teachers.FindAsync(model.TeacherId);
                var st = new Student { Id = id, Name = model.Name, Score = (int)model.Score, Teacher = teacher, TeacherId = model.TeacherId  };
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
            if (model == null) return StatusCode(408);
            try
            {              
                var st = await db.Students.FindAsync(id);
                Reflection.UpdateEntity(st,model);
                if (model.TeacherId.HasValue)
                {
                    Teacher teacher = await db.Teachers.FindAsync(model.TeacherId.Value);
                    if (teacher != null) st.Teacher = teacher;
                    st.TeacherId = model.TeacherId;
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
