using AutoMapper;
using CompanyApi.Dtos;
using CompanyApi.Models;

namespace CompanyApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Employee
            CreateMap<Employee, EmploeeysDetalisDto>();

            CreateMap<EmployeeBaseDto, Employee>()
                .ForMember(src => src.Image, opt => opt.Ignore());

            // Department
            CreateMap<Department, DepartmentsDetailsDto>();

            // Project
            CreateMap<Project, ProjectsDetalisDto>();
        }
    }
}
