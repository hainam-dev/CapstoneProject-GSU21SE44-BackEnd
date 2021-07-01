using Mumbi.Application.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserInfoRepository UserInfoRepository { get; }
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
        ITokenRepository TokenRepository { get; }

        Task<int> SaveAsync();
    }
}
