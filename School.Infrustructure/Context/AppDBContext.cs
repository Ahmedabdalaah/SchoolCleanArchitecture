using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrustructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subjects> subjects { get; set; }
        public DbSet<DepartmetSubject> departmetSubjects { get; set;}
        public DbSet<StudentSubject> studentSubjects { get; set; }

    }
}
