using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using _1_DomainModels;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandContracts;
using _3_Cqrs.Service.Queries;
using _3_Cqrs.Service.QueryContracts;
using _3_Cqrs.Service.QueryResults;
using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using OfficeOpenXml;
using System.Linq;

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

        [HttpGet("{exam_Id}/grades")]
        public IActionResult GetAllGradesByExamId(Guid exam_Id)
        {
            EnsureArg.IsNotEmpty(exam_Id);

            var query = new GetAllGradesByExamIdQuery(exam_Id);
            var queryResult =
                QueryDispatcher.Execute<GetAllGradesByExamIdQuery, GetAllGradesByExamIdQueryResult>(query);

            return Ok(queryResult.Grades);
        }

        [HttpGet("{exam_Id}/students")]
        public IActionResult GetAllStudentsByExamId(Guid exam_Id)
        {
            EnsureArg.IsNotEmpty(exam_Id);

            var query = new GetAllStudentsByExamIdQuery(exam_Id);
            var queryResult =
                QueryDispatcher.Execute<GetAllStudentsByExamIdQuery, GetAllStudentsByExamIdQueryResult>(query);

            return Ok(queryResult.Students);
        }

        [HttpGet("{exam_Id}/results")]
        public IActionResult GetResultsByExamId(Guid exam_Id)
        {
            EnsureArg.IsNotEmpty(exam_Id);

            var queryStudents = new GetAllStudentsByExamIdQuery(exam_Id);
            var students =
                QueryDispatcher.Execute<GetAllStudentsByExamIdQuery, GetAllStudentsByExamIdQueryResult>(queryStudents).Students;

            var queryGrades = new GetAllGradesByExamIdQuery(exam_Id);
            var grades =
                QueryDispatcher.Execute<GetAllGradesByExamIdQuery, GetAllGradesByExamIdQueryResult>(queryGrades).Grades;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells[1, 1].Value = "First name";
                worksheet.Cells[1, 2].Value = "Last name";
                worksheet.Cells[1, 3].Value = "Grade";
                worksheet.Cells[1, 4].Value = "Final grade";
                for (int i = 0; i < grades.Count(); i++)
                {
                    worksheet.Cells[i + 2, 1].Value = students.ElementAt(i).FirstName;
                    worksheet.Cells[i + 2, 2].Value = students.ElementAt(i).LastName;
                    worksheet.Cells[i + 2, 3].Value = grades.ElementAt(i).Value;
                    worksheet.Cells[i + 2, 4].Value = grades.ElementAt(i).FinalGrade;
                }

                byte[] fileContents= package.GetAsByteArray();
           
                if (fileContents == null || fileContents.Length == 0)
                {
                    return NotFound();
                }

                return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "test.xlsx"
                );
            }
        }

    }
}
