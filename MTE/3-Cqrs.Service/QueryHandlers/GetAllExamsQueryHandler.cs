using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper mapper;

        public GetAllExamsQueryHandler(IBaseRepository<Exam> examsRepository, IMapper mapper)
        {
            this.examsRepository = examsRepository;
            this.mapper = mapper;
        }

        public GetAllExamsQueryResult Execute(GetAllExamsQuery query)
        {
            var entities = examsRepository.GetAll().ToList();
            var examDtos = new List<ExamDto>();

            mapper.Map(entities, examDtos);
            return new GetAllExamsQueryResult(examDtos);
        }
    }
}
