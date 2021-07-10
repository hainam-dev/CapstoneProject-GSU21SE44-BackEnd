using AutoMapper;
using Mumbi.Application.Dtos.Tokens;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TokenService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<string>> DeleteToken(string userId, string fcmToken)
        {
            var token = await _unitOfWork.TokenRepository.GetAsync(x => x.UserId == userId);
            if (token.Count == 0)
            {
                return new Response<string>($"User \'{userId}\' không tồn tại.");
            }
            foreach(var tokens in token)
            {
                if(fcmToken == tokens.FcmToken)
                {
                    _unitOfWork.TokenRepository.DeleteAsync(tokens);
                    await _unitOfWork.SaveAsync();
                    return new Response<string>($"Xóa token \'{fcmToken}\' thành công!");
                }
            }
            return new Response<string>($"Token \'{fcmToken}\' không tồn tại.");
        }
    }
}
