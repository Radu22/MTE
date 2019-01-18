using System;
using _3_Cqrs.Service.QueryContracts;

namespace _3_Cqrs.Service.Queries
{
    public class GetAllStudentsByExamIdQuery : IQuery
    {
        public GetAllStudentsByExamIdQuery(Guid examId)
        {
            ExamId = examId;
        }
        public Guid ExamId { get; set; }

    }
}
