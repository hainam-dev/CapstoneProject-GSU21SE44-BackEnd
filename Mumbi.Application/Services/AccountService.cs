using FirebaseAdmin.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mumbi.Application.Constants;
using Mumbi.Application.Dtos;
using Mumbi.Application.Dtos.Accounts;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using Mumbi.Domain.Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;
        private readonly JWTSettings _jwtSettings;
        public AccountService(IUnitOfWork unitOfWork, IOptions<JWTSettings> jwtSettings)
        {
            _unitOfWork = unitOfWork;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Response<AuthenticationResponse>> Authenticate(AuthenticationRequest request)
        {
            try
            {
                FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.IdToken);
                if (decodedToken == null)
                {
                    return new Response<AuthenticationResponse>(null, $"Authenticate fail");
                }

                UserRecord account_firebase = await FirebaseAuth.DefaultInstance.GetUserAsync(decodedToken.Uid);
                Account currentAccount = await _unitOfWork.AccountRepository
                                                          .FirstAsync(u => u.AccountId == account_firebase.Email,
                                                                      includeProperties: "Mom");

                if (currentAccount == null)
                {
                    var account_Info = new Account
                    {
                        AccountId = account_firebase.Email,
                        RoleId = RoleConstant.USER_ROLE
                    };
                    await _unitOfWork.AccountRepository.AddAsync(account_Info);

                    var mom_info = new Mom
                    {
                        AccountId = account_firebase.Email,
                        FullName = account_firebase.DisplayName,
                        Phonenumber = account_firebase.PhoneNumber,
                        Image = account_firebase.PhotoUrl
                    };
                    await _unitOfWork.MomRepository.AddAsync(mom_info);

                    if (await _unitOfWork.SaveAsync() > 0)
                    {
                        currentAccount = account_Info;
                        currentAccount.Mom = mom_info;
                    };
                }

                JwtSecurityToken jwtSecurityToken = await GenerateJWTToken(currentAccount);
                AuthenticationResponse response = new AuthenticationResponse();
                response.Email = currentAccount.AccountId;
                response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                response.Role = currentAccount.RoleId;
                response.Photo = currentAccount.Mom.Image;

                return new Response<AuthenticationResponse>(response, $"Authenticated {account_firebase.Email}");
            }
            catch (FirebaseAuthException ex)
            {
                return new Response<AuthenticationResponse>(ex.Message);
            }
        }

        private async Task<JwtSecurityToken> GenerateJWTToken(Account account)
        {
            var role = await _unitOfWork.RoleRepository.FirstAsync(r => r.Id == account.RoleId);
            var claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("email", account.AccountId),
                new Claim(JwtRegisteredClaimNames.Email, account.AccountId),
                new Claim(ClaimTypes.Role, role.Name),
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);


            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "https://securetoken.google.com/" + _jwtSettings.FirebaseProjectId,
                audience: _jwtSettings.FirebaseProjectId,
                claims: claim,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
