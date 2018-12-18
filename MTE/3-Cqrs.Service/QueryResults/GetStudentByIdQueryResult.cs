using _1_DomainModels;
using _3_Cqrs.Service.QueryContracts;

namespace _3_Cqrs.Service.QueryResults
{
    public class GetStudentByIdQueryResult : IQueryResult
    {
        public GetStudentByIdQueryResult(StudentDto student)
        {
            Student = student;
        }

        public StudentDto Student { get; set; }
    }
}
