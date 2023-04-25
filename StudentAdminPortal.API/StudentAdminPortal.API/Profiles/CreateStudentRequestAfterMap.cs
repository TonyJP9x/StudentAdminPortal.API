using AutoMapper;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Profiles
{
    public class CreateStudentRequestAfterMap: IMappingAction<CreateStudentRequest, Entities.Student>
    {
        public void Process(CreateStudentRequest source, Entities.Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new Entities.Address()
            {
                Id = Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
