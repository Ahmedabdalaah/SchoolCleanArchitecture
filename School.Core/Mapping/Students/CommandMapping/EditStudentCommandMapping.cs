using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;

namespace School.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
             .ForMember(destinaton => destinaton.DID, option => option
             .MapFrom(source => source.DepartmentId))
             .ForMember(destinaton => destinaton.StudID, option => option
             .MapFrom(source => source.Id));
        }
    }
}
