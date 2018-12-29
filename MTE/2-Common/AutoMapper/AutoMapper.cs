using AutoMapper;

namespace _2_Common.AutoMapper
{
    public static class AutoMapper
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new StudentMapper());
                cfg.AddProfile(new ExamMapper());
                cfg.AddProfile(new GradeMapper());
            });

            return config;
        }
    }
}
