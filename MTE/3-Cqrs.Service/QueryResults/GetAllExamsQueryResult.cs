using System.Collections.Generic;
using _1_DomainModels;
using _3_Cqrs.Service.QueryContracts;

namespace _3_Cqrs.Service.QueryResults
{
    public class GetAllExamsQueryResult : IQueryResult
    {
        public GetAllExamsQueryResult(IEnumerable<ExamDto> exams)
        {
            Exams = exams;
        }

        public IEnumerable<ExamDto> Exams { get; set; }
    }
}
