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
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private readonly JWTSettings _jwtSettings;
        public UserService(IUnitOfWork unitOfWork, IOptions<JWTSettings> jwtSettings)
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

                UserRecord user_firebase = await FirebaseAuth.DefaultInstance.GetUserAsync(decodedToken.Uid);
                User currentUser = await _unitOfWork.UserRepository
                                                          .FirstAsync(u => u.Email == user_firebase.Email,
                                                                      includeProperties: "UserInfo,MomInfo");

                if (currentUser != null && currentUser.DelFlag == true)
                {
                    return new Response<AuthenticationResponse>($"Xác thực đã bị lỗi. Tài khoản \'{user_firebase.Email}\' không khả dụng");
                }
                else if (currentUser == null)
                {
                    var user_registration = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = user_firebase.Email,
                        DelFlag = false,
                    };

                    string getEmail = user_firebase.Email;
                    string[] spitFirstNameEmail = getEmail.Split(".");
                    string[] getRole = spitFirstNameEmail[1].Split("@");
                    if (getRole[0].ToString() == "staffmumbi")
                    {
                        user_registration.RoleId = RoleConstant.STAFF_ROLE;
                    }
                    else
                    {
                        user_registration.RoleId = RoleConstant.USER_ROLE;
                        var momInfo = new MomInfo
                        {
                            Id = user_registration.Id
                        };
                        await _unitOfWork.MomInfoRepository.AddAsync(momInfo);

                    }
                    await _unitOfWork.UserRepository.AddAsync(user_registration);

                    var userInfo = new UserInfo
                    {
                        Id = user_registration.Id,
                        FullName = user_firebase.DisplayName,
                        ImageUrl = user_firebase.PhotoUrl,
                        Phonenumber = user_firebase.PhoneNumber
                        
                    };
                    await _unitOfWork.UserInfoRepository.AddAsync(userInfo);

                    currentUser = user_registration;
                    currentUser.UserInfo = userInfo;
                }

                // Check token is not existed then add to database
                var isUniqueToken = _unitOfWork.TokenRepository.IsUniqueFCMTOken(request.FCMToken);
                if (isUniqueToken)
                {
                    var token = new Token
                    {
                        UserId = currentUser.Id,
                        FcmToken = request.FCMToken,
                    };
                    await _unitOfWork.TokenRepository.AddAsync(token);
                }
                await _unitOfWork.SaveAsync();

                JwtSecurityToken jwtSecurityToken = await GenerateJWTToken(currentUser);
                AuthenticationResponse response = new AuthenticationResponse();
                response.Id = currentUser.Id;
                response.Email = currentUser.Email;
                response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                response.Role = currentUser.RoleId;
                response.Fullname = currentUser.UserInfo.FullName;
                response.Photo = currentUser.UserInfo.ImageUrl;

                return new Response<AuthenticationResponse>(response, $"Đã xác thực {user_firebase.Email}");
            }
            catch (FirebaseAuthException ex)
            {
                return new Response<AuthenticationResponse>(ex.Message);
            }
        }

        private async Task<JwtSecurityToken> GenerateJWTToken(User user)
        {
            var role = await _unitOfWork.RoleRepository.FirstAsync(r => r.Id == user.RoleId);
            var claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("email", user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, role.RoleName),
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
