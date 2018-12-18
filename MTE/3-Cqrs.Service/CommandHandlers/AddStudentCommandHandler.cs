using AutoMapper;
using EnsureThat;
using _1_Entity.Model;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandContracts;
using _5_Repositories.Contracts;

namespace _3_Cqrs.Service.CommandHandlers
{
    public class AddStudentCommandHandler : ICommandHandler<AddStudentCommand>
    {
        private readonly IBaseRepository<Student> _baseRepo;
        private readonly IMapper _mapper;

        public AddStudentCommandHandler(IMapper mapper, IBaseRepository<Student> baseRepo)
        {
            _mapper = mapper;
            _baseRepo = baseRepo;
        }


        public void Execute(AddStudentCommand command)
        {
            EnsureArg.IsNotNull(command);

            var student = new Student();

            _mapper.Map(command.Student, student);
            _baseRepo.Add(student);
            _baseRepo.Save();
        }
    }
}
