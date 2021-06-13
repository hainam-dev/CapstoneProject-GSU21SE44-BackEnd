using AutoMapper;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Dtos.Moms;
using Mumbi.Domain.Entities;
namespace Mumbi.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            // Child
            CreateMap<Child, ChildrenResponse>();

            // Pregnancy Info
            CreateMap<PregnancyInformation, ChildrenResponse>();

            // Mom
            CreateMap<Mom, MomResponse>();
            // Account
            CreateMap<Account, MomResponse>().ForMember(
                dest => dest.AccountId,
                opt => opt.MapFrom(src => src.Mom.AccountId)
            ).ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.Mom.FullName)
            ).ForMember(
                dest => dest.Image,
                opt => opt.MapFrom(src => src.Mom.Image)
            ).ForMember(
                dest => dest.Birthday,
                opt => opt.MapFrom(src => src.Mom.Birthday)
            ).ForMember(
                dest => dest.Phonenumber,
                opt => opt.MapFrom(src => src.Mom.Phonenumber)
            ).ForMember(
                dest => dest.BloodGroup,
                opt => opt.MapFrom(src => src.Mom.BloodGroup)
            ).ForMember(
                dest => dest.RhBloodGroup,
                opt => opt.MapFrom(src => src.Mom.RhBloodGroup)
            ).ForMember(
                dest => dest.Weight,
                opt => opt.MapFrom(src => src.Mom.Weight)
            ).ForMember(
                dest => dest.Height,
                opt => opt.MapFrom(src => src.Mom.Height)
            );

        }
    }
}
