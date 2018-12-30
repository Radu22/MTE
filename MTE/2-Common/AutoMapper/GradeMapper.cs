using AutoMapper;
using _1_DomainModels;
using _1_Entity.Model;

namespace _2_Common.AutoMapper
{
    public class GradeMapper : Profile
    {
        public GradeMapper()
        {
            CreateMap<GradeDto, Grade>()
                .ForMember(g => g.Exam, opt => opt.MapFrom(src => src.Exam))
                .ForMember(g => g.ExamId, opt => opt.MapFrom(src => src.ExamId))
                .ForMember(g => g.Student, opt => opt.MapFrom(src => src.Student))
                .ForMember(g => g.FinalGrade, opt => opt.MapFrom(src => src.FinalGrade))
                .ForMember(g => g.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(g => g.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(g => g.ProfessorId, opt => opt.MapFrom(src => src.ProfessorId)).ReverseMap();
        }
    }
}
