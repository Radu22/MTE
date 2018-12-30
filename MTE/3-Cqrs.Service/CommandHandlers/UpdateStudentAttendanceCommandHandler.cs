using EnsureThat;
using _1_Entity.Model;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandContracts;
using _5_Repositories.Contracts;

namespace _3_Cqrs.Service.CommandHandlers
{
    public class UpdateStudentAttendanceCommandHandler : ICommandHandler<UpdateStudentAttendanceCommand>
    {
        private readonly IBaseRepository<Student> studentRepository;

        public UpdateStudentAttendanceCommandHandler(IBaseRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void Execute(UpdateStudentAttendanceCommand command)
        {
            EnsureArg.IsNotNull(command);

            var student = studentRepository.Get(command.IdStudent);
            student.isPresent = true;
            studentRepository.Save();
        }
    }
}
