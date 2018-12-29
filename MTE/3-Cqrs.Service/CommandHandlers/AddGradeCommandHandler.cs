using System.Linq;
using AutoMapper;
using EnsureThat;
using _1_Entity.Model;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandContracts;
using _3_Cqrs.Service.Exceptions;
using _5_Repositories.Contracts;

namespace _3_Cqrs.Service.CommandHandlers
{
    public class AddGradeCommandHandler : ICommandHandler<AddGradeCommand>
    {
        private readonly IBaseRepository<Grade> gradeRepository;
        private readonly IBaseRepository<Student> studentRepository;
        private readonly IMapper mapper;

        public AddGradeCommandHandler(IMapper mapper, IBaseRepository<Grade> gradeRepository, IBaseRepository<Student> studentRepository)
        {
            this.mapper = mapper;
            this.gradeRepository = gradeRepository;
            this.studentRepository = studentRepository;
        }

        public void Execute(AddGradeCommand command)
        {
            EnsureArg.IsNotNull(command);


            var grade = new Grade
            {
                StudentId = command.Grade.StudentId,
                ExamId = command.Grade.ExamId,
                FinalGrade = command.Grade.FinalGrade,
                Value = command.Grade.Value
            };
            var existingGrade = gradeRepository.GetAll()
                .FirstOrDefault(g => g.StudentId == grade.StudentId && g.ExamId == grade.ExamId);

            if (existingGrade != null)
            {
                throw new GeneralBusinessException("Cannot add grade to the same student at the same exam");
            }

            gradeRepository.Add(grade);
            gradeRepository.Save();
        }
    }
}
