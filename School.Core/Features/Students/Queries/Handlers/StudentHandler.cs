using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Responses;
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
    public class StudentHandler : ResponseHandler,
        IRequestHandler<GetStudentListQuery,Response<List<GetStudentListRespnse>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public StudentHandler(IStudentService studentService , IMapper mapper)
        {
            _studentService = studentService;  
            _mapper = mapper;
        }
        #endregion
        #region Handle Functions
        #endregion
        public async Task<Response<List<GetStudentListRespnse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList= await _studentService.GetStudentsAsync();
            var studentMapper = _mapper.Map<List<GetStudentListRespnse>>(studentList);
            return Success(studentMapper);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByIdAsync(request.Id);
            if(student == null)
            { 
                return NotFound<GetSingleStudentResponse>("Object is not Found");
            }
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result);
        }
    }
}
