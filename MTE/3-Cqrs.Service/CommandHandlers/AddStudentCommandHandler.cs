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
        private readonly IBaseRepository<Exam> examRepository;
        private readonly IMapper _mapper;

        public AddStudentCommandHandler(IMapper mapper, IBaseRepository<Student> baseRepo, IBaseRepository<Exam> examRepository)
        {
            _mapper = mapper;
            _baseRepo = baseRepo;
            this.examRepository = examRepository;
        }


        public void Execute(AddStudentCommand command)
        {
            EnsureArg.IsNotNull(command);

            var student = new Student();
            var exam = examRepository.Get(command.Student.ExamId);
            EnsureArg.IsNotNull(exam);

            _mapper.Map(command.Student, student);
            _baseRepo.Add(student);
            _baseRepo.Save();
        }
    }
}
