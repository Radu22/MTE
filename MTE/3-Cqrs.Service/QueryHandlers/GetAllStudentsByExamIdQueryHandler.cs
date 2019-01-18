using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EnsureThat;
using _1_DomainModels;
using _1_Entity.Model;
using _3_Cqrs.Service.Queries;
using _3_Cqrs.Service.QueryContracts;
using _3_Cqrs.Service.QueryResults;
using _5_Repositories.Contracts;
using System;

namespace _3_Cqrs.Service.QueryHandlers
{
    class GetAllStudentsByExamIdQueryHandler : IQueryHandler<GetAllStudentsByExamIdQuery, GetAllStudentsByExamIdQueryResult>
    {
        private readonly IBaseRepository<Student> studentRepository;
        private readonly IBaseRepository<Exam> examRepository;
        private readonly IMapper mapper;
        public GetAllStudentsByExamIdQueryHandler(IBaseRepository<Student> studentRepository, IBaseRepository<Exam> examRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.examRepository = examRepository;
            this.mapper = mapper;
        }

        public GetAllStudentsByExamIdQueryResult Execute(GetAllStudentsByExamIdQuery query)
        {
            EnsureArg.IsNotNull(query);
            var exam = examRepository.Get(query.ExamId);
            EnsureArg.IsNotNull(exam);
            var students = studentRepository.GetAll().Where(s => s.ExamId == query.ExamId).OrderBy(s => s.Id).ToList();
            return new GetAllStudentsByExamIdQueryResult(students.Select(x => new StudentDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ExamId = x.ExamId,
                Email = x.Email,
                IsPresent = x.isPresent
            }));
        }

    }
}
