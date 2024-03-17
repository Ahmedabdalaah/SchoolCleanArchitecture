using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrustructure.Abstract;
using School.Infrustructure.Data;
using School.Infrustructure.InfrustructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrustructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _students;
        #endregion
        #region Constructor
        public StudentRepository(AppDBContext context) : base(context) 
        {
            _students = context.Set<Student>();
        }
        #endregion

        #region Handle Functions
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _students.Include(x=> x.Department).ToListAsync();
        }
        #endregion

    }
}
