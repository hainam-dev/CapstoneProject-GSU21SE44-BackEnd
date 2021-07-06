using AutoMapper;
using Google.Apis.Auth.OAuth2.Responses;
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
using Mumbi.Application.Dtos.Staffs;
using Mumbi.Application.Dtos.Tokens;
using Mumbi.Domain.Entities;
namespace Mumbi.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
           
            // Child
            CreateMap<ChildInfo, ChildInfoResponse>();
            CreateMap<PregnancyHistory, ChildInfoResponse>();

            // DadIndo
            CreateMap<DadInfo, DadInfoResponse>();
            // Diary
            CreateMap<Diary, DiaryResponse>();
            // DiaryPublic
            CreateMap<Diary, DiaryPublicResponse>();
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
            //Token
            CreateMap<Token, FcmTokenResponse>();
            // User
            CreateMap<User, MomInfoResponse>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.UserInfo.Id)
            ).ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.UserInfo.FullName)
            ).ForMember(
                dest => dest.ImageURL,
                opt => opt.MapFrom(src => src.UserInfo.ImageUrl)
            ).ForMember(
                dest => dest.Birthday,
                opt => opt.MapFrom(src => src.UserInfo.Birthday)
            ).ForMember(
                dest => dest.Phonenumber,
                opt => opt.MapFrom(src => src.UserInfo.Phonenumber)
            ).ForMember(
                dest => dest.BloodGroup,
                opt => opt.MapFrom(src => src.MomInfo.BloodGroup)
            ).ForMember(
                dest => dest.RhBloodGroup,
                opt => opt.MapFrom(src => src.MomInfo.RhBloodGroup)
            ).ForMember(
                dest => dest.Weight,
                opt => opt.MapFrom(src => src.MomInfo.Weight)
            ).ForMember(
                dest => dest.Height,
                opt => opt.MapFrom(src => src.MomInfo.Height)
            ).ForMember(
                dest => dest.Dad_Id,
                opt => opt.MapFrom(src => src.MomInfo.DadId)
            );
            // Staff
            CreateMap<User, StaffInfoResponse>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.UserInfo.Id)
            ).ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.UserInfo.FullName)
            ).ForMember(
                dest => dest.ImageURL,
                opt => opt.MapFrom(src => src.UserInfo.ImageUrl)
            ).ForMember(
                dest => dest.Birthday,
                opt => opt.MapFrom(src => src.UserInfo.Birthday)
            ).ForMember(
                dest => dest.Phonenumber,
                opt => opt.MapFrom(src => src.UserInfo.Phonenumber)
            );
        }
    }
}
