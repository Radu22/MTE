using System.Linq;
using _1_DomainModels;
using _1_Entity.Model;
using _3_Cqrs.Service.Queries;
using _3_Cqrs.Service.QueryContracts;
using _3_Cqrs.Service.QueryResults;
using _5_Repositories.Contracts;

namespace _3_Cqrs.Service.QueryHandlers
{
    public class GetAllStudentsQueryHandler : IQueryHandler<GetAllStudentsQuery, GetAllStudentsQueryResult>
    {
        private readonly IBaseRepository<Student> studentsRepository;

        public GetAllStudentsQueryHandler(IBaseRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public GetAllStudentsQueryResult Execute(GetAllStudentsQuery query)
        {
            var entities = studentsRepository.GetAll();

            return new GetAllStudentsQueryResult(entities.Select(x => new StudentDto
            {
                Id = x.Id,
                Email =  x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            }));
        }
    }
}
