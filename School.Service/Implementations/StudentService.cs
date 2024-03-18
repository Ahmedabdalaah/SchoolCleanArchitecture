using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrustructure.Abstract;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Implementations
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _repo;
        #endregion
        #region Constructor
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        
        #endregion
        #region Handle Functions
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _repo.GetStudentsAsync();
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            var student =  _repo.GetTableNoTracking()
                                    .Include(x => x.Department)
                                    .Where(x => x.StudID.Equals(id))
                                    .FirstOrDefault();
            return student;
        }

        public async Task<string> AddStudentAsunc(Student student)
        {
            await _repo.AddAsync(student);
            return "Success";
        }
        #endregion
    }
}
