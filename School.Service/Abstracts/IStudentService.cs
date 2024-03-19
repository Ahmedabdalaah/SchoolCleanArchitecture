using School.Data.Entities;

namespace School.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<Student> GetByIdAsync(int id);
        public Task<string> AddStudentAsunc(Student student);
        public Task<string> EditStudentAsunc(Student student);
        public Task<string> RemoveStudentAsync(Student student);
        public Task<Boolean> IsNameExist(string name);
        public Task<Boolean> IsNameExistExclude(string name, int id);




    }
}
