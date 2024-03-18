using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Responses;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Mapping.Students
{
    public partial class StudentProfile 
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand,Student>()
               .ForMember(destinaton => destinaton.DID, option => option
               .MapFrom(source => source.DepartmentId));
        }
    }
}
