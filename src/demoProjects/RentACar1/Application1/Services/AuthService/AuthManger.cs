﻿using Application1.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Services.AuthService
{
    public class AuthManger : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthManger(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)//veri tabanına refresh token göndredi
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken); return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccesToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                    await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                                                                     include: u =>
                                                                         u.Include(u => u.OperationClaim)
                    );
            IList<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(u => new OperationClaim
                { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();

            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;

        }

        public async Task<RefreshToken> CreateRefreshToken(User user ,string ipAddress)
        {
            RefreshToken refreshToken =  _tokenHelper.CreateRefreshToken(user, ipAddress);  return await Task.FromResult(refreshToken);

        }
    }
}
