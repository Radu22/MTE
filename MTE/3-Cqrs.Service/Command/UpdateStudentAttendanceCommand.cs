using System;
using _3_Cqrs.Service.CommandContracts;

namespace _3_Cqrs.Service.Command
{
    public class UpdateStudentAttendanceCommand : ICommand
    {
        public UpdateStudentAttendanceCommand(Guid idStudent)
        {
            IdStudent = idStudent;
        }

        public Guid IdStudent { get; set; }
    }
}
