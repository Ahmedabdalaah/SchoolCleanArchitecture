using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using School.Service.Abstracts;

namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                         IRequestHandler<AddStudentCommand, Response<string>>,
                         IRequestHandler<EditStudentCommand, Response<string>>,
                         IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _student;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public StudentCommandHandler(IStudentService student, IMapper mapper)
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
            if (result == "Success")
            {
                // return response
                return Created("Added Successfully");
            }
            else
            {
                return BadRequest<string>();
            }
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // Check if id exist or not
            var student = await _student.GetByIdAsync(request.Id);
            if (student == null)
            {
                //return notfound 
                return NotFound<string>("Student is Not Found");
            }
            // mapping between respons and student
            var studentMapper = _mapper.Map<Student>(request);
            // call service that make edit
            var studentResult = await _student.EditStudentAsunc(studentMapper);
            // check conditon 
            if (studentResult == "Success")
            {
                // return response
                return Success("Update Successfully");
            }
            else
            {
                return BadRequest<string>();
            }
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            // Check if id exist or not
            var student = await _student.GetStudentByIdAsync(request.Id);
            if (student == null)
            {
                //return notfound 
                return NotFound<string>("Student is Not Found");
            }
            // call service that make edit
            var studentResult = await _student.RemoveStudentAsync(student);
            // check conditon 
            if (studentResult == "Success")
            {
                // return response
                return Deleted<string>();
            }
            else
            {
                return BadRequest<string>();
            }
        }
        #endregion

    }
}
