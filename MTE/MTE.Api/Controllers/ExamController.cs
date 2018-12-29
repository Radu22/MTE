using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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

    }
}
