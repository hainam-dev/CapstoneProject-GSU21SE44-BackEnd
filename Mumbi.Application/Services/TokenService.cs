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
        public async Task<Response<FcmTokenResponse>> GetTokenById(int Id)
        {
            var response = new FcmTokenResponse();
            var token = await _unitOfWork.TokenRepository.FirstAsync(x => x.Id == Id);
            if (token == null)
            {
                return new Response<FcmTokenResponse>($"Không tìm thấy token id \'{Id}\'");
            }
            response = _mapper.Map<FcmTokenResponse>(token);
            return new Response<FcmTokenResponse>(response);
        }
        public async Task<Response<string>> DeleteToken(int Id)
        {
            var token = await _unitOfWork.TokenRepository.FirstAsync(x => x.Id == Id);
            if (token == null)
            {
                return new Response<string>($"Không tìm thấy token có id \'{Id}\'.");
            }
            _unitOfWork.TokenRepository.DeleteAsync(token);
            await _unitOfWork.SaveAsync();
            return new Response<string>($"Xóa token id \'{Id}\' thành công!");
        }

       
    }
}
