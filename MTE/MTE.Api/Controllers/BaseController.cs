using Microsoft.AspNetCore.Mvc;
using _3_Cqrs.Service.CommandContracts;
using _3_Cqrs.Service.QueryContracts;

namespace MTE.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(ICommandDispatcher iCommandDispatcher, IQueryDispatcher iQueryDispatcher)
        {
            CommandDispatcher = iCommandDispatcher;
            QueryDispatcher = iQueryDispatcher;
        }

        protected ICommandDispatcher CommandDispatcher { get; }

        protected IQueryDispatcher QueryDispatcher { get; }
    }
}
