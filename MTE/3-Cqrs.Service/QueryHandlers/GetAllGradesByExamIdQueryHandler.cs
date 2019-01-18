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
    public class GetAllGradesByExamIdQueryHandler : IQueryHandler<GetAllGradesByExamIdQuery, GetAllGradesByExamIdQueryResult>
    {
        private readonly IBaseRepository<Grade> gradeRepository;
        private readonly IBaseRepository<Exam> examRepository;
        private readonly IMapper mapper;

        public GetAllGradesByExamIdQueryHandler(IBaseRepository<Grade> gradeRepository, IBaseRepository<Exam> examRepository, IMapper mapper)
        {
            this.gradeRepository = gradeRepository;
            this.examRepository = examRepository;
            this.mapper = mapper;
        }

        public GetAllGradesByExamIdQueryResult Execute(GetAllGradesByExamIdQuery query)
        {
            EnsureArg.IsNotNull(query);
            var exam = examRepository.Get(query.ExamId);
            EnsureArg.IsNotNull(exam);
            var grades = gradeRepository.GetAll().Where(g => g.ExamId == query.ExamId).OrderBy(g =>g.StudentId).ToList();
            return new GetAllGradesByExamIdQueryResult(grades.Select(x => new GradeDto
            {
                StudentId = x.StudentId,
                ExamId = x.ExamId,
                FinalGrade = x.FinalGrade,
                ProfessorId = x.ProfessorId,
                Value = x.Value
            }));
        }
    }
}








   
