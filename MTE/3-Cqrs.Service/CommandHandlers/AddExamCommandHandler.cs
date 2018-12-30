using AutoMapper;
using EnsureThat;
using _1_Entity.Model;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandContracts;
using _3_Cqrs.Service.Exceptions;
using _5_Repositories.Contracts;

namespace _3_Cqrs.Service.CommandHandlers
{
    public class AddExamCommandHandler : ICommandHandler<AddExamCommand>
    {
        private readonly IBaseRepository<Exam> examRepository;
        private readonly IBaseRepository<Professor> professorRepository;
        private readonly IMapper mapper;

        public AddExamCommandHandler(IMapper mapper, IBaseRepository<Exam> examRepository, IBaseRepository<Professor> professorRepository)
        {
            this.mapper = mapper;
            this.examRepository = examRepository;
            this.professorRepository = professorRepository;
        }

        public void Execute(AddExamCommand command)
        {
            EnsureArg.IsNotNull(command);
            var exam = new Exam();
            var professor = professorRepository.Get(command.Exam.ProfessorId);
            EnsureArg.IsNotNull(professor);

            if (professor.Subject != command.Exam.Subject)
            {
                throw new GeneralBusinessException("Cant create an exam if the professor teaches a different subject");
            }

            mapper.Map(command.Exam, exam);
            examRepository.Add(exam);
            examRepository.Save();
        }
    }
}
