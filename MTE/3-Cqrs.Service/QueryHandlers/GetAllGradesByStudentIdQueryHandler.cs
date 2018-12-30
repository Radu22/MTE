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

namespace _3_Cqrs.Service.QueryHandlers
{
    public class GetAllGradesByStudentIdQueryHandler : IQueryHandler<GetAllGradesByStudentIdQuery, GetAllGradesByStudentIdQueryResult>
    {
        private readonly IBaseRepository<Grade> gradeRepository;
        private readonly IBaseRepository<Student> studentRepository;
        private readonly IMapper mapper;

        public GetAllGradesByStudentIdQueryHandler(IBaseRepository<Grade> gradeRepository, IBaseRepository<Student> studentRepository, IMapper mapper)
        {
            this.gradeRepository = gradeRepository;
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public GetAllGradesByStudentIdQueryResult Execute(GetAllGradesByStudentIdQuery query)
        {
            EnsureArg.IsNotNull(query);
            var student = studentRepository.Get(query.StudentId);

            EnsureArg.IsNotNull(student);
            var gradeDtos = new List<GradeDto>();
            var grades = gradeRepository.GetAll().Where(g => g.StudentId == query.StudentId).ToList();
            //mapper.Map(grades, gradeDtos);

            return new GetAllGradesByStudentIdQueryResult(grades.Select(x => new GradeDto
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
