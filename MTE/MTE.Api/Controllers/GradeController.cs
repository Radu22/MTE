﻿using System;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using _1_DomainModels;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandContracts;
using _3_Cqrs.Service.QueryContracts;

namespace MTE.Api.Controllers
{
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

        //[HttpPatch("grade")]

    }
}
