using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;
using School.Data.Appmetadata;
using School.Data.Entities;

namespace School.Api.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {
       
        [HttpGet(Router.StudentRouting.list)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [HttpGet(Router.StudentRouting.getById)]
        public async Task<IActionResult> GetStudentById([FromRoute]int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }
        [HttpPost(Router.StudentRouting.create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand addcommand)
        {
            var response = await Mediator.Send(addcommand);
            return NewResult(response);
        }
    }
}
