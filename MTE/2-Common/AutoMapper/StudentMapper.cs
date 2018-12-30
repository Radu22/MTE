using AutoMapper;
using _1_DomainModels;
using _1_Entity.Model;

namespace _2_Common.AutoMapper
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<StudentDto, Student>()
                .ForMember(s => s.Exam, opt => opt.MapFrom(src => src.Exam))
                .ForMember(s => s.ExamId, opt => opt.MapFrom(src => src.ExamId))
                .ForMember(s => s.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(s => s.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(s => s.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(s => s.isPresent, opt => opt.MapFrom(src => src.IsPresent))
                .ForMember(s => s.Grades, opt => opt.MapFrom(src => src.Grades));
        }
    }
}
