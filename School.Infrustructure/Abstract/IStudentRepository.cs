using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrustructure.Abstract
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetStudentsAsync();
    }
}
