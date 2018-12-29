using System.Linq;
using _1_DomainModels;
using _1_Entity.Model;
using _3_Cqrs.Service.Queries;
using _3_Cqrs.Service.QueryContracts;
using _3_Cqrs.Service.QueryResults;
using _5_Repositories.Contracts;

namespace _3_Cqrs.Service.QueryHandlers
{
    public class GetAllExamsQueryHandler : IQueryHandler<GetAllExamsQuery, GetAllExamsQueryResult>
    {
        private readonly IBaseRepository<Exam> examsRepository;

        public GetAllExamsQueryHandler(IBaseRepository<Exam> examsRepository)
        {
            this.examsRepository = examsRepository;
        }

        public GetAllExamsQueryResult Execute(GetAllExamsQuery query)
        {
            var entities = examsRepository.GetAll().ToList();

            return new GetAllExamsQueryResult(entities.Select(x => new ExamDto
            {
                Id = x.Id,
                StartDate = x.StartDate,
                Subject = x.Subject,
                Time = x.Time
            }));
        }
    }
}
