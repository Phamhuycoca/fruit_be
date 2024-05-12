using Application.Helpers;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using onion_architecture.Application.Common;
using onion_architecture.Application.Dto.Fruit;
using onion_architecture.Application.Features.Auth;
using onion_architecture.Application.Features.Dto.UserDto;
using onion_architecture.Application.IService;
using onion_architecture.Application.Wrappers.Abstract;
using onion_architecture.Application.Wrappers.Concrete;
using onion_architecture.Domain.Entity;
using onion_architecture.Domain.Repositories;
using onion_architecture.Infrastructure.Exceptions;
using onion_architecture.Infrastructure.Migrations;
using onion_architecture.Infrastructure.Repositories;
using onion_architecture.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Service
{
    public class AuthService : IAuthService, IRequest<IResponse>
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRefresh_TokenRepository _refreshTokenRepository;
        public AuthService(IOptions<JWTSettings> jwtSettings, IUserRepository userRepository, IRefresh_TokenRepository refreshTokenRepository,IMapper mapper)
        {
            _jwtSettings = jwtSettings.Value;
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
        }
        public DataResponse<TokenDTO> Login(LoginDto dto)
        {
            try
            {
                var user = _userRepository.GetAll().Where(x => x.Email == dto.Email).SingleOrDefault();
                if (user == null)
                {
                    throw new ApiException(401, "Tài khoản không tồn tại");
                }
                var isPasswordValid = PasswordHelper.VerifyPassword(dto.PassWord, user.PassWord);
                if (!isPasswordValid)
                {
                    throw new ApiException(401, "Mật khẩu không chính xác");
                }
                else
                {
                    _userRepository.Update(user);
                    return new DataResponse<TokenDTO>(CreateToken(user), 200,"Success");
                }
                throw new ApiException(401, "Đăng nhập thất bại");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public TokenDTO CreateToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.RefreshTokenExpiration);
            var securityKey = Encoding.ASCII.GetBytes(_jwtSettings.SecurityKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey),
                SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience[0],
                expires: accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: GetClaims(user, _jwtSettings.Audience),
                 signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDTO
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = (int)((DateTimeOffset)accessTokenExpiration).ToUnixTimeSeconds(),
                RefreshTokenExpiration = (int)((DateTimeOffset)refreshTokenExpiration).ToUnixTimeSeconds(),
                Role=user.Role
                
            };
            var refresh_token = new Refresh_TokenDto
            {
                UserId = user.UserId,
                RefreshToken = tokenDto.RefreshToken,
                RefreshTokenExpiration = tokenDto.RefreshTokenExpiration,
                Refresh_TokenExpires = refreshTokenExpiration
            };

            if (_refreshTokenRepository.GetById(user.UserId) == null)
            {
                _refreshTokenRepository.Create(_mapper.Map<Refresh_Token>(refresh_token));
            }
            else
            {
                _refreshTokenRepository.Update(_mapper.Map<Refresh_Token>(refresh_token));
            }

            return tokenDto;
        }


        private IEnumerable<Claim> GetClaims(User user, List<string> audiences)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                 new Claim(ClaimTypes.Role,user.Role)
            };
            claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            return claims;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }

        public DataResponse<User> Register(RegisterDto dto)
        {
            var user = _userRepository.GetAll().Where(x => x.Email == dto.Email).SingleOrDefault();
            if (user != null)
            {
                throw new ApiException(401, "Tài khoản dã tồn tại");
            }
            var userdto = new User(){
                FullName=dto.FullName,
                PassWord= PasswordHelper.CreateHashedPassword(dto.PassWord),
                Email=dto.Email,
                Role = "Người dùng",
                Gender = "",
                Address = "",
                Avatar = "https://res.cloudinary.com/drhdgw1xx/image/upload/v1713533834/account_gzt5kr.png",
                PhoneNumber = "",
                UserId = 0,
                Is_Active=false
            };
            var newData = _userRepository.Create(userdto);
            if (newData != null)
            {
                return new DataResponse<User>(newData, HttpStatusCode.OK, "Đăng ký tài khoản thành công");
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, "Đăng ký thất bại");
        }

        public DataResponse<TokenDTO> Refresh_Token(RefreshTokenSettings token)
        {
            var existRefreshToken = _refreshTokenRepository.GetAll().Where(x => x.RefreshToken == token.Refresh_Token).FirstOrDefault();
            if (existRefreshToken == null)
            {
                throw new ApiException(404, "Refresh Token không hợp lệ");
            }
            var user = _userRepository.GetById(existRefreshToken.UserId);
            if (user == null)
            {
                throw new ApiException(404, "Thông tin người dùng không tồn tại");
            }
            if (existRefreshToken.Refresh_TokenExpires < DateTime.Now)
            {
                throw new ApiException(404, "Refresh Token hết hạn");
            }

            return new DataResponse<TokenDTO>(RefreshToken(user, _mapper.Map<Refresh_TokenDto>(existRefreshToken)), 200, "Refresh token success");
        }
        public TokenDTO RefreshToken(User user, Refresh_TokenDto refreshtoken)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.RefreshTokenExpiration);
            var securityKey = Encoding.ASCII.GetBytes(_jwtSettings.SecurityKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey),
                SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience[0],
                expires: accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: GetClaims(user, _jwtSettings.Audience),
                 signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDTO
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = (int)((DateTimeOffset)accessTokenExpiration).ToUnixTimeSeconds(),
                RefreshTokenExpiration = refreshtoken.RefreshTokenExpiration,
                Role = user.Role
            };
            var refresh_token = new Refresh_TokenDto
            {
                UserId = user.UserId,
                RefreshToken = tokenDto.RefreshToken,
                RefreshTokenExpiration = refreshtoken.RefreshTokenExpiration,
                Refresh_TokenExpires = refreshtoken.Refresh_TokenExpires
            };
            _refreshTokenRepository.Update(_mapper.Map<Refresh_Token>(refresh_token));
            return tokenDto;
        }
    }
}
