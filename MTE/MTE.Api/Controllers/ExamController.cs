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
    [Route("api/exams")]
    public class ExamController : BaseController
    {
        public ExamController(ICommandDispatcher iCommandDispatcher, IQueryDispatcher iQueryDispatcher) 
            : base(iCommandDispatcher, iQueryDispatcher)
        {
        }

        [HttpGet]
        public IActionResult GetAllExams()
        {
            var query = new GetAllExamsQuery();

            var queryResult = QueryDispatcher.Execute<GetAllExamsQuery, GetAllExamsQueryResult>(query);
            return Ok(queryResult.Exams);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult AddExam([FromBody] ExamDto exam)
        {
            EnsureArg.IsNotNull(exam);

            var command = new AddExamCommand(exam);
            CommandDispatcher.Execute(command);
            return Created("/api/exams", command);
        }

    }
}
