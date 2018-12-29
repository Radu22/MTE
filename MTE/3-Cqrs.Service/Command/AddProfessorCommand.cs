using _1_DomainModels;
using _3_Cqrs.Service.CommandContracts;

namespace _3_Cqrs.Service.Command
{
    public class AddProfessorCommand : ICommand
    {
        public AddProfessorCommand(ProfessorDto professor)
        {
            Professor = professor;
        }

        public ProfessorDto Professor { get; set; }
}
}
