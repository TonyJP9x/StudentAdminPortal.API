﻿using AutoMapper;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Profiles
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, Entities.Student>
    {
        public void Process(UpdateStudentRequest source, Entities.Student destination, ResolutionContext context)
        {
            destination.Address = new Entities.Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
