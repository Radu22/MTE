using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using _1_DomainModels;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandContracts;
using _3_Cqrs.Service.QueryContracts;

namespace MTE.Api.Controllers
{
    [Route("api/professors")]
    public class ProfessorController : BaseController
    {
        public ProfessorController(ICommandDispatcher iCommandDispatcher, IQueryDispatcher iQueryDispatcher) 
            : base(iCommandDispatcher, iQueryDispatcher)
        {
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult AddProfessor([FromBody] ProfessorDto professor)
        {
            EnsureArg.IsNotNull(professor);

            var command = new AddProfessorCommand(professor);
            CommandDispatcher.Execute(command);
            return Created("/api/professors/", command);
        }
    }
}
