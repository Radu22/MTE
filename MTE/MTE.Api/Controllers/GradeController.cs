using System;
using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using _1_DomainModels;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandContracts;
using _3_Cqrs.Service.Queries;
using _3_Cqrs.Service.QueryContracts;
using _3_Cqrs.Service.QueryResults;

namespace MTE.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/students/{studentId}/grades")]
    public class GradeController : BaseController
    {
        public GradeController(ICommandDispatcher iCommandDispatcher, IQueryDispatcher iQueryDispatcher) 
            : base(iCommandDispatcher, iQueryDispatcher)
        {
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult AddGrade(Guid studentId, [FromBody] GradeDto grade)
        {
            EnsureArg.IsNotEmpty(studentId);

            var command = new AddGradeCommand(grade, studentId);
            CommandDispatcher.Execute(command);
            return Created("/api/students/{studentId}/grades", command);
        }

        [HttpGet]
        public IActionResult GetAllGradesByStudentId(Guid studentId)
        {
            EnsureArg.IsNotEmpty(studentId);

            var query = new GetAllGradesByStudentIdQuery(studentId);
            var queryResult =
                QueryDispatcher.Execute<GetAllGradesByStudentIdQuery, GetAllGradesByStudentIdQueryResult>(query);
            var values = new List<double>();
            foreach (var grade in queryResult.Grades)
            {
                 values.Add(grade.Value);
            }

            return Ok(values);
        }

    }
}
