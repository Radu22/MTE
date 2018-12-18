using System;
using _3_Cqrs.Service.QueryContracts;

namespace _3_Cqrs.Service.Queries
{
    public class GetStudentByIdQuery : IQuery
    {
        public GetStudentByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
