using Mumbi.Application.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserInfoRepository UserInfoRepository { get; }
        IRoleRepository RoleRepository { get; }
        IMomInfoRepository MomInfoRepository { get; }
        IDadInfoRepository DadInfoRepository { get; }
        IChildInfoRepository ChildInfoRepository { get; }
        IChildHistoryRepository ChildHistoryRepository { get; }
        IPregnancyHistoryRepository PregnancyHistoryRepository { get; }
        IDiaryRepository DiaryRepository { get; }
        INewsRepository NewsRepository { get; }
        INewsTypeRepository NewsTypeRepository { get; }
        INewsMomRepository NewsMomRepository { get; }
        IGuidebookRepository GuidebookRepository { get; }
        IGuidebookTypeRepository GuidebookTypeRepository { get; }
        IGuidebookMomRepository GuidebookMomRepository { get; }
        IToothRepository ToothRepository { get; }
        IToothInfoRepository ToothInfoRepository { get; }
        ITokenRepository TokenRepository { get; }
        IInjectedPersonRepository InjectedPersonRepository { get; }
        IInjectionScheduleRepository InjectionScheduleRepository { get; }
        IActionChildRepository ActionChildRepository { get; }
        IActionRepository ActionRepository { get; }
        IActivityRepository ActivityRepository { get; }
        IStandardIndexRepository StandardIndexRepository { get; }
        IVaccineRepository VaccineRepository { get; }


        Task<int> SaveAsync();
    }
}
