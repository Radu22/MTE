using System;
using _3_Cqrs.Service.QueryContracts;

namespace _3_Cqrs.Service.Queries
{
    public class GetAllGradesByExamIdQuery : IQuery
    {
        public GetAllGradesByExamIdQuery(Guid examId)
        {
            ExamId = examId;
        }
        public Guid ExamId { get; set; }
        
    }
}
