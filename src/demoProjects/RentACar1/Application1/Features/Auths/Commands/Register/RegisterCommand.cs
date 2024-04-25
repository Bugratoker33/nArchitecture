using Application1.Features.Auths.Dtos;
using Application1.Features.Auths.Rules;
using Application1.Services.AuthService;
using Application1.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Auths.Commands.Register
{
    public class RegisterCommand:IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string IpAddress { get; set; }

        public class RegisterCommandHandeler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
          //  private readonly IMapper _mapper;
            private readonly AuthBussinesRules _authBussinesRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;

            public RegisterCommandHandeler(AuthBussinesRules authBussinesRules, IUserRepository userRepository, IAuthService authService)
            {
                _authBussinesRules = authBussinesRules;
                _userRepository = userRepository;
                _authService = authService;
            }

            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBussinesRules.EmailCanNotBeDublicatedWenRegistered(request.UserForRegisterDto.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                User newUser = new()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Status = true

                };
                
                User createdUser = await _userRepository.AddAsync(newUser);

                AccessToken createdAccessToken= await _authService.CreateAccesToken(createdUser);

                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredDto registeredDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken
                };
                return registeredDto;
            }
        }
    }
}
