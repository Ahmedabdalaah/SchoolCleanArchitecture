using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrustructure.Abstract;
using School.Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrustructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly AppDBContext _context;
        #endregion
        #region Constructor
        public StudentRepository(AppDBContext context)
        {
            _context = context;
        }
        #endregion

        #region Handle Functions
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.students.ToListAsync();
        }
        #endregion

    }
}
