using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<string>> DeleteToken(string userId, string fcmToken)
        {
            var tokens = await _unitOfWork.TokenRepository.GetAsync(x => x.UserId == userId);
            if (tokens.Count == 0)
            {
                return new Response<string>(null, $"User \'{userId}\' không tồn tại.");
            }

            var deletedToken = tokens.Where(x => x.FcmToken == fcmToken).FirstOrDefault();
            _unitOfWork.TokenRepository.Delete(deletedToken);

            return new Response<string>(fcmToken, $"Xóa token \'{fcmToken}\' thành công!");
        }
    }
}