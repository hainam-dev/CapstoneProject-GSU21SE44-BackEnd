using AutoMapper;
using Mumbi.Application.Dtos.Childrens;
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
        }
    }
}
