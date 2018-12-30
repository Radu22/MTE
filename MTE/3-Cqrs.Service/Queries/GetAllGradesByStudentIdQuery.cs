using System;
using _3_Cqrs.Service.QueryContracts;

namespace _3_Cqrs.Service.Queries
{
    public class GetAllGradesByStudentIdQuery : IQuery
    {
        public GetAllGradesByStudentIdQuery(Guid studentId)
        {
            StudentId = studentId;
        }

        public Guid StudentId { get; set; }
    }
}
