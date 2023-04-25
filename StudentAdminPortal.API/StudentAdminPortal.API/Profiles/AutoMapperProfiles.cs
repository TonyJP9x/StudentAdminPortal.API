using AutoMapper;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Entities.Student, Student>();
            CreateMap<Entities.Gender, Gender>();
            CreateMap<Entities.Address, Address>();
            CreateMap<UpdateStudentRequest, Entities.Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();
            CreateMap<CreateStudentRequest, Entities.Student>()
                .AfterMap<CreateStudentRequestAfterMap>();

        }
    }
}
