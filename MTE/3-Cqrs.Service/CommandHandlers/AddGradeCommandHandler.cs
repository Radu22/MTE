using System.Linq;
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
                StudentId = command.StudentId,
                ExamId = command.Grade.ExamId,
                ProfessorId = command.Grade.ProfessorId,
                FinalGrade = command.Grade.FinalGrade,
                Value = command.Grade.Value
            };

            var existingGrade = gradeRepository.GetAll()
                .FirstOrDefault(g => g.StudentId == grade.StudentId && g.ExamId == grade.ExamId);

            var professor = professorRepository.Get(command.Grade.ProfessorId);

            var exam = examRepository.GetAll()
                .FirstOrDefault(e => e.Id == grade.ExamId && e.ProfessorId == professor.Id);

            var student = studentRepository.GetAll()
                .FirstOrDefault(s => s.Id == grade.StudentId && s.ExamId == grade.ExamId);

            EnsureArg.IsNotNull(professor);
            EnsureArg.IsNotNull(student);
            EnsureArg.IsNotNull(exam);

            if (existingGrade != null)
            {
                throw new GeneralBusinessException("Cant add a grade to the same student at the same exam");
            }

            if (professor.Subject != exam.Subject)
            {
                throw new GeneralBusinessException("A teacher from another subject cant add a grade");
            }

            if (student.isPresent == false)
            {
                throw new GeneralBusinessException("A student that was not present cant receive a grade");
            }

            gradeRepository.Add(grade);
            gradeRepository.Save();
        }
    }
}
