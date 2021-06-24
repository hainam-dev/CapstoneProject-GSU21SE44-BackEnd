using Mumbi.Application.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IRoleRepository RoleRepository { get; }
        IMomRepository MomRepository { get; }
        IDadRepository DadRepository { get; }
        IChildrenRepository ChildrenRepository { get; }
        IPregnancyInformationRepository PregnancyInformationRepository { get; }
        IDiaryRepository DiaryRepository { get; }
        INewsRepository NewsRepository { get; }
        INewsTypeRepository NewsTypeRepository { get; }
        INewsMomRepository NewsMomRepository { get; }
        IGuidebookRepository GuidebookRepository { get; }
        IGuidebookTypeRepository GuidebookTypeRepository { get; }
        IGuidebookMomRepository GuidebookMomRepository { get; }
        IStaffRepository StaffRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        ITokenRepository TokenRepository { get; }

        Task<int> SaveAsync();
    }
}
