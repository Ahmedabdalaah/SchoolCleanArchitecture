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
        #endregion
    }
}
