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
        Task<int> SaveAsync();
    }
}
