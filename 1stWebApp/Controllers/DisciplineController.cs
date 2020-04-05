using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using _1stWebApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1stWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplineController : ControllerBase
    {
        private readonly MyDbContext db;
        public DisciplineController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet("view/{name?}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var item = await db.Disciplines.AsNoTracking()
                    .Include(s => s.TeacherDisciplines)
                    .Select(di => new {discipline = di.Name, teacher = di.TeacherDisciplines.Select(td =>td.Teacher)})
                    .Where(d => d.discipline == name || name == null)
                    .ToArrayAsync();
                return Ok(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(409);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm]string name)
        {
            try
            {
                var checker = await db.Disciplines.FindAsync(name);
                if (checker != null) return StatusCode(405);
                var item = new Discipline {Name = name};
                await db.Disciplines.AddAsync(item);
                await db.SaveChangesAsync();
                return Ok(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message +"\n" + e.StackTrace);
                return StatusCode(409);
            }
        }
        [HttpDelete("delete/{name?}")]
        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                var checker = await db.Disciplines.FindAsync(name);
                if (checker == null) return StatusCode(405);
                db.Disciplines.Remove(checker);
                await db.SaveChangesAsync();
                return Ok(checker);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                return StatusCode(409);
            }
        }
       
    }
}
