using Application1.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Auths.Rules
{
    public class AuthBussinesRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBussinesRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task EmailCanNotBeDublicatedWenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) 
            {
                throw new BusinessException("Mail already exists");

            }

        }
    }
}
