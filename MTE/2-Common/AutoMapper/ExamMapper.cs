using AutoMapper;
using _1_DomainModels;
using _1_Entity.Model;

namespace _2_Common.AutoMapper
{
    public class ExamMapper : Profile
    {
        public ExamMapper()
        {
            CreateMap<ExamDto, Exam>()
                .ForMember(e => e.Students, opt => opt.MapFrom(src => src.Students))
                .ForMember(e => e.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(e => e.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(e => e.Time, opt => opt.MapFrom(src => src.Time))
                .ForMember(e => e.Professor, opt => opt.MapFrom(src => src.Professor))
                .ForMember(e => e.ProfessorId, opt => opt.MapFrom(src => src.ProfessorId));
        }
    }
}
