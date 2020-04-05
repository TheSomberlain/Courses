using Microsoft.EntityFrameworkCore;
namespace _1stWebApp
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Student>()
                .HasOne(s => s.Teacher)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.TeacherId);

            modelBuilder.Entity<Entities.TeacherDiscipline>()
                .HasKey(td => new {td.TeacherId, td.DisciplineName});
            modelBuilder.Entity<Entities.TeacherDiscipline>()
                .HasOne<Entities.Teacher>(td => td.Teacher)
                .WithMany(t => t.TeacherDisciplines)
                .HasForeignKey(td => td.TeacherId); 
            
            modelBuilder.Entity<Entities.TeacherDiscipline>()
                .HasOne<Entities.Discipline>(td => td.Discipline)
                .WithMany(t => t.TeacherDisciplines)
                .HasForeignKey(td => td.DisciplineName);
        }

        public DbSet<Entities.Student> Students { get; set; }
        public DbSet<Entities.Teacher> Teachers { get; set; }
        public  DbSet<Entities.Discipline> Disciplines { get; set; }
    }
}
