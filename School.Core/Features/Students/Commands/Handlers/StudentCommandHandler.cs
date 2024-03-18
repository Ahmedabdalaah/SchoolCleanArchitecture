using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                         IRequestHandler<AddStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _student;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public StudentCommandHandler(IStudentService student,IMapper mapper)
        {
            _student = student;
            _mapper = mapper;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and student
            var studentMapper = _mapper.Map<Student>(request);
            //add
            var result = await _student.AddStudentAsunc(studentMapper);
            // check conditon 
            if(result == "Success")
            {
                // return response
                return Created("Added Successfully");
            }
            else
            {
                return BadRequest<string>();
            }
        }
        #endregion

    }
}
