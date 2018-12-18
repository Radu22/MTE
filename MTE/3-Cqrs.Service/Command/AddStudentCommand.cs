using _1_DomainModels;
using _3_Cqrs.Service.CommandContracts;

namespace _3_Cqrs.Service.Command
{
    public class AddStudentCommand : ICommand
    {
        public AddStudentCommand(StudentDto student)
        {
            Student = student;
        }

        public StudentDto Student { get; set; }
    }
}
