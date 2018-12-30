using AutoMapper;
using _1_DomainModels;
using _1_Entity.Model;

namespace _2_Common.AutoMapper
{
    public class ProfessorMapper : Profile
    {
        public ProfessorMapper()
        {
            CreateMap<ProfessorDto, Professor>()
                .ForMember(p => p.Exam, opt => opt.MapFrom(src => src.Exam))
                .ForMember(p => p.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(p => p.Firstname, opt => opt.MapFrom(src => src.Firstname)).ReverseMap();
        }
    }
}
