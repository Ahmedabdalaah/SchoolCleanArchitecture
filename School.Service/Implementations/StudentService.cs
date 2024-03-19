using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrustructure.Abstract;
using School.Service.Abstracts;

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
            var student = _repo.GetTableNoTracking()
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

        public async Task<bool> IsNameExist(string name)
        {
            var student = _repo.GetTableAsTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExclude(string name, int id)
        {
            var student = await _repo.GetTableAsTracking().Where(x => x.Name.Equals(name) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<string> EditStudentAsunc(Student student)
        {
            await _repo.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> RemoveStudentAsync(Student student)
        {
            var transaction = _repo.BeginTransaction();
            try
            {
                await _repo.DeleteAsync(student);
                transaction.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return "Fail";
            }

        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            return student;
        }
        #endregion
    }
}
