using AutoMapper;
using NorthwindTechUniversity.Web.Models;
using NorthwindTechUniversity.Web.Models.ViewModels;

namespace NorthwindTechUniversity.Web.Mappings
{
    public static class AutoMapperConfig
    {
        // Legacy: Static AutoMapper initialization (deprecated in AutoMapper 9+)
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Student, StudentViewModel>()
                    .ForMember(dest => dest.ProgramName, 
                              opt => opt.MapFrom(src => src.Program != null ? src.Program.Name : string.Empty));

                cfg.CreateMap<StudentViewModel, Student>();

                cfg.CreateMap<Enrollment, EnrollmentViewModel>()
                    .ForMember(dest => dest.StudentName,
                              opt => opt.MapFrom(src => src.Student != null ? src.Student.FullName : string.Empty))
                    .ForMember(dest => dest.CourseTitle,
                              opt => opt.MapFrom(src => src.Course != null ? src.Course.Title : string.Empty));

                cfg.CreateMap<EnrollmentViewModel, Enrollment>();
            });

            // TODO: Move to instance-based configuration
            // This static API is deprecated but still works in AutoMapper 6.x
        }
    }
}
