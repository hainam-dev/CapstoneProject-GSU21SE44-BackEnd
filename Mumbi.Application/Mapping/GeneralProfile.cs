using AutoMapper;
using Mumbi.Application.Dtos.Action;
using Mumbi.Application.Dtos.ActionChild;
using Mumbi.Application.Dtos.Activity;
using Mumbi.Application.Dtos.ChildHistory;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Dtos.Dads;
using Mumbi.Application.Dtos.Diaries;
using Mumbi.Application.Dtos.Guidebooks;
using Mumbi.Application.Dtos.GuidebookTypes;
using Mumbi.Application.Dtos.InjectionSchedule;
using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Dtos.News;
using Mumbi.Application.Dtos.NewsType;
using Mumbi.Application.Dtos.PregnancyHistory;
using Mumbi.Application.Dtos.Staffs;
using Mumbi.Application.Dtos.StandardIndex;
using Mumbi.Application.Dtos.Tokens;
using Mumbi.Application.Dtos.ToothInfo;
using Mumbi.Application.Dtos.Tooths;
using Mumbi.Application.Dtos.Vaccine;
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
            // ChildHistory
            CreateMap<ChildHistory, ChildHistoryResponse>();
            // PregnancyHistory
            CreateMap<PregnancyHistory, PregnancyHistoryResponse>();
            // DadIndo
            CreateMap<DadInfo, DadInfoResponse>();
            //StandardIndex
            CreateMap<StandardIndex, StandardIndexResponse>();
            //Vaccine
            CreateMap<Vaccine, VaccineResponse>();
            //Action
            CreateMap<Action, ActionResponse>();
            //ActionChild
            CreateMap<ActionChild, ActionChildResponse>();
            //Activity
            CreateMap<Activity, ActivityResponse>().ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.Type)
                );
            CreateMap<Activity, ActivityByTypeIdResponse>().ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.Type)
                );
            // Diary
            CreateMap<Diary, DiaryResponse>();
            // DiaryPublic
            CreateMap<Diary, DiaryPublicResponse>().ForMember(
                dest => dest.NameCreatedBy,
                opt => opt.MapFrom(src => src.Child.Mom.IdNavigation.UserInfo.FullName)
            ).ForMember(
                dest => dest.ImageURLCreateBy,
                opt => opt.MapFrom(src => src.Child.Mom.IdNavigation.UserInfo.ImageUrl)
            );
            // NewsType
            CreateMap<NewsType, NewsTypeResponse>();
            // News
            CreateMap<News, NewsResponse>().ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.Type)
            );
            CreateMap<News, NewsByTypeIdResponse>().ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.Type)
            );
            // GuidebookType
            CreateMap<GuidebookType, GuidebookTypeResponse>();
            // Guidebook
            CreateMap<Guidebook, GuidebookResponse>().ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.Type)
            );
            CreateMap<Guidebook, GuidebookByTypeIdResponse>().ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.Type)
            );
            //Token
            CreateMap<Token, FcmTokenResponse>();
            //Tooth
            CreateMap<ToothChild, ToothResponse>().ForMember(
                dest => dest.ToothName,
                opt => opt.MapFrom(src => src.Tooth.Name)
            ).ForMember(
                dest => dest.Position,
                opt => opt.MapFrom(src => src.Tooth.Position)
            );
            //ToothInfo
            CreateMap<ToothInfo, ToothInfoResponse>();
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

            // InjectionSchedule
            CreateMap<InjectionSchedule, InjectionScheduleResponse>();
        }
    }
}