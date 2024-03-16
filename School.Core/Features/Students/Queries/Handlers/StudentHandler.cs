using MediatR;
using School.Core.Features.Students.Queries.Models;
using School.Data.Entities;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : IRequestHandler<GetStudentListQuery, List<Student>>
    {
        #region Function
        private readonly IStudentService _studentService;
        #endregion
        #region Constructor
        public StudentHandler(IStudentService studentService)
        {
            _studentService = studentService;   
        }
        #endregion
        #region Handle Functions
        #endregion
        public async Task<List<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudentsAsync();
        }
    }
}
