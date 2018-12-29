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
        private readonly IBaseRepository<Professor> professorRepository;
        private readonly IBaseRepository<Exam> examRepository;
        private readonly IBaseRepository<Student> studentRepository;

        public AddGradeCommandHandler(IBaseRepository<Grade> gradeRepository, IBaseRepository<Professor> professorRepository, IBaseRepository<Exam> examRepository, IBaseRepository<Student> studentRepository)
        {
            this.gradeRepository = gradeRepository;
            this.professorRepository = professorRepository;
            this.examRepository = examRepository;
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

            var professor = professorRepository.Get(command.ProfessorId);
            var exam = examRepository.Get(grade.ExamId);
            var student = studentRepository.Get(command.StudentId);

            if (existingGrade != null || professor.Subject != exam.Subject || student.isPresent == false)
            {
                throw new GeneralBusinessException("Cannot add grade to the same student at the same exam");
            }

            gradeRepository.Add(grade);
            gradeRepository.Save();
        }
    }
}
