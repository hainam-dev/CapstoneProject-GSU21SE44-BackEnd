using AutoMapper;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Dtos.Dads;
using Mumbi.Application.Dtos.Diaries;
using Mumbi.Application.Dtos.GuidebookMom;
using Mumbi.Application.Dtos.Guidebooks;
using Mumbi.Application.Dtos.GuidebookTypes;
using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Dtos.News;
using Mumbi.Application.Dtos.NewsMom;
using Mumbi.Application.Dtos.NewsType;
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
            // Dad
            CreateMap<Dad, DadResponse>();
            // Diary
            CreateMap<Diary, DiaryResponse>();
            // NewsType
            CreateMap<NewsType, NewsTypeResponse>();
            // News
            CreateMap<News, NewsResponse>();
            CreateMap<News, NewsByTypeIdResponse>();
            // NewsMom
            CreateMap<NewsMom, NewsMomResponse>();
            // GuidebookType
            CreateMap<GuidebookType, GuidebookTypeResponse>();
            // Guidebook
            CreateMap<Guidebook, GuidebookResponse>();
            CreateMap<Guidebook, GuidebookByTypeIdResponse>();
            // GuidebookMom
            CreateMap<GuidebookMom, GuidebookMomResponse>();
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
