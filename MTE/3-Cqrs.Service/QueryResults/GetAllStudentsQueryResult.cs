using System.Collections.Generic;
using _1_DomainModels;
using _3_Cqrs.Service.QueryContracts;

namespace _3_Cqrs.Service.QueryResults
{
    public class GetAllStudentsQueryResult : IQueryResult
    {
        public GetAllStudentsQueryResult(IEnumerable<StudentDto> students)
        {
            Students = students;
        }

        public IEnumerable<StudentDto> Students { get; set; }
    }
}
