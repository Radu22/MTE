using _1_DomainModels;
using _3_Cqrs.Service.CommandContracts;

namespace _3_Cqrs.Service.Command
{
    public class AddExamCommand : ICommand
    {
        public AddExamCommand(ExamDto exam)
        {
            Exam = exam;
        }

        public ExamDto Exam { get; set; }
    }
}
