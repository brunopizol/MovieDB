using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB.Application.Dtos;
using MovieDB.Application.Helpers;
using MovieDB.Application.Requests;
using MovieDB.Application.Responses;
using MovieDB.Domain.Entities;
using MovieDB.Domain.Repositories;

namespace MovieDB.Application.Services
{
    public class AuthenticationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly AuthenticationHelper _authenticationHelper;

        public AuthenticationService(IRepository<User> userRepository,
            AuthenticationHelper authenticationHelper)
        {
            _userRepository = userRepository;
            _authenticationHelper = authenticationHelper;
        }

        public async Task<AuthenticateResponse> Handle(UserDto request, CancellationToken cancellationToken)
        {

            var hashpassword = _authenticationHelper.HashPassword(request.Password);
            var user = await _userRepository.GetById(request.Email, hashpassword);
            if (user == null)
            {
                return new AuthenticateResponse  { Status = "Error", Message = "Invalid email or password." };
            }


            var token = _authenticationHelper.GenerateJwtToken(user.Email);

            return new AuthenticateResponse { Status = "Success", Token = token };
        }
    }
}
