using AutoMapper;
using EnsureThat;
using _1_Entity.Model;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandContracts;
using _5_Repositories.Contracts;

namespace _3_Cqrs.Service.CommandHandlers
{
    public class AddProfessorCommandHandler : ICommandHandler<AddProfessorCommand>
    {
        private readonly IBaseRepository<Professor> professorRepository;
        private readonly IMapper mapper;

        public AddProfessorCommandHandler(IBaseRepository<Professor> professorRepository, IMapper mapper)
        {
            this.professorRepository = professorRepository;
            this.mapper = mapper;
        }

        public void Execute(AddProfessorCommand command)
        {
            EnsureArg.IsNotNull(command);

            var professor = new Professor();
            mapper.Map(command.Professor, professor);
            professorRepository.Add(professor);
            professorRepository.Save();
        }
    }
}
