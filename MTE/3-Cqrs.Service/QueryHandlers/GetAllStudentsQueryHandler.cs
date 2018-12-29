using System.Collections.Generic;
using AutoMapper;
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
        private readonly IMapper mapper;

        public GetAllStudentsQueryHandler(IBaseRepository<Student> studentsRepository, IMapper mapper)
        {
            this.studentsRepository = studentsRepository;
            this.mapper = mapper;
        }

        public GetAllStudentsQueryResult Execute(GetAllStudentsQuery query)
        {
            var entities = studentsRepository.GetAll();
            var studentDtos = new List<StudentDto>();
            mapper.Map(studentDtos, entities);
            return new GetAllStudentsQueryResult(studentDtos);
        }
    }
}
