using AutoMapper;
using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Entity to DTO mappings
            CreateMap<Admin, AdminDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
