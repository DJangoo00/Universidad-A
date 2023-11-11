using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //principal entities
        CreateMap<Departament, DepartamentDto>().ReverseMap();
        CreateMap<Gender, GenderDto>().ReverseMap();
        CreateMap<Grade, GradeDto>().ReverseMap();
        CreateMap<Person, PersonDto>().ReverseMap();
        CreateMap<PersonType, PersonTypeDto>().ReverseMap();
        CreateMap<SchoolarCurse, SchoolarCurseDto>().ReverseMap();
        CreateMap<Subject, SubjectDto>().ReverseMap();
        CreateMap<SubjectRegister, SubjectRegisterDto>().ReverseMap();
        CreateMap<SubjectType, SubjectTypeDto>().ReverseMap();
        CreateMap<Teacher, TeacherDto>().ReverseMap();

        //jwt
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        
    }
}
