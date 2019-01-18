using System.Collections.Generic;
using _1_DomainModels;
using _3_Cqrs.Service.QueryContracts;

namespace _3_Cqrs.Service.QueryResults
{
    public class GetAllGradesByExamIdQueryResult : IQueryResult
    {
        public GetAllGradesByExamIdQueryResult(IEnumerable<GradeDto> grades)
        {
            Grades = grades;
        }
        public IEnumerable<GradeDto> Grades { get; set; }
    }
    
}





        
