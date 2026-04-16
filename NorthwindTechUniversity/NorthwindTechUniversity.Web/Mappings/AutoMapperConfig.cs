using AutoMapper;
using NorthwindTechUniversity.Web.Models;
using NorthwindTechUniversity.Web.Models.ViewModels;

namespace NorthwindTechUniversity.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(dest => dest.ProgramName, 
                          opt => opt.MapFrom(src => src.Program != null ? src.Program.Name : string.Empty));

            CreateMap<StudentViewModel, Student>();

            CreateMap<Enrollment, EnrollmentViewModel>()
                .ForMember(dest => dest.StudentName,
                          opt => opt.MapFrom(src => src.Student != null ? src.Student.FullName : string.Empty))
                .ForMember(dest => dest.CourseTitle,
                          opt => opt.MapFrom(src => src.Course != null ? src.Course.Title : string.Empty));

            CreateMap<EnrollmentViewModel, Enrollment>();
        }
    }
}
