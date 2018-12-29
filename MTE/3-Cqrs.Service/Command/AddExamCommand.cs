using System;
using _1_DomainModels;
using _3_Cqrs.Service.CommandContracts;

namespace _3_Cqrs.Service.Command
{
    public class AddExamCommand : ICommand
    {
        public AddExamCommand(Guid professorId, ExamDto exam)
        {
            Exam = exam;
            ProfessorId = professorId;
        }

        public ExamDto Exam { get; set; }

        public Guid ProfessorId { get; set; }
    }
}
