using System;
using Microsoft.AspNetCore.Mvc;
using _1_DomainModels;
using _3_Cqrs.Service.CommandContracts;
using _3_Cqrs.Service.QueryContracts;
using EnsureThat;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.Queries;
using _3_Cqrs.Service.QueryResults;

namespace MTE.Api.Controllers
{
    [Route("api/students")]
    public class StudentController : BaseController
    {
        public StudentController(ICommandDispatcher iCommandDispatcher, IQueryDispatcher iQueryDispatcher)
            : base(iCommandDispatcher, iQueryDispatcher)
        {
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentDto student)
        {
            EnsureArg.IsNotNull(student);

            var command = new AddStudentCommand(student);
            CommandDispatcher.Execute(command);
            return NoContent();
        }

        [HttpGet("{id_student}")]
        public IActionResult GetStudent(Guid id_student)
        {
            EnsureArg.IsNotEmpty(id_student);
            var query = new GetStudentByIdQuery(id_student);

            var queryResult = QueryDispatcher.Execute<GetStudentByIdQuery, GetStudentByIdQueryResult>(query);
            return Ok(queryResult.Student);
        }

    }
}
