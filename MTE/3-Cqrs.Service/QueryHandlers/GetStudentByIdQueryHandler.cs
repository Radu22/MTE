using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EnsureThat;
using _1_DomainModels;
using _1_Entity.Model;
using _3_Cqrs.Service.Queries;
using _3_Cqrs.Service.QueryContracts;
using _3_Cqrs.Service.QueryResults;
using _5_Repositories.Contracts;

namespace _3_Cqrs.Service.QueryHandlers
{
    public class GetStudentByIdQueryHandler : IQueryHandler<GetStudentByIdQuery, GetStudentByIdQueryResult>
    {
        private readonly IBaseRepository<Student> repo;
        private readonly IMapper mapper;

        public GetStudentByIdQueryHandler(IBaseRepository<Student> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public GetStudentByIdQueryResult Execute(GetStudentByIdQuery query)
        {
            EnsureArg.IsNotNull(query);

            var entity = repo.Get(query.Id);
            var result = mapper.Map<Student, StudentDto>(entity);
            return new GetStudentByIdQueryResult(result);
        }
    }
}
