using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class UsersMapping : Profile
    {
        public UsersMapping()
        {
            //Mapping For RegistrationDto -> Users
            CreateMap<RegistrationDto, Users>()
                .ForMember(destination => destination.Email, source =>
                    source.Condition(x => !string.IsNullOrEmpty(x.Email)))
                
                .ForMember(destination => destination.NormalizedEmail, source =>
                    source.Condition(x => !string.IsNullOrEmpty(x.Email.ToUpper())))
                
                .ForMember(destination => destination.EmailConfirmed, source =>
                    source.MapFrom(x => true))
                
                .ForMember(destination => destination.UserName, source =>
                    source.Condition(x => !string.IsNullOrEmpty(x.Username)))
                
                .ForMember(destination => destination.NormalizedUserName, source =>
                    source.Condition(x => !string.IsNullOrEmpty(x.Username.ToUpper())));
            
            //Mapping For Users -> UsersDto
            CreateMap<Users, UsersDto>()
                .ForMember(destination => destination.UserName, source =>
                    source.MapFrom(x => x.UserName))

                .ForMember(destination => destination.Email, source =>
                    source.MapFrom(x => x.Email))

                .ForMember(destination => destination.PhoneNumber, source =>
                    source.MapFrom(x => x.PhoneNumber));
        }
    }
}