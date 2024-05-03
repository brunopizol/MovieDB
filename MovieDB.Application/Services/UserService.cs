using MovieDB.Application.Helpers;
using MovieDB.Domain.Entities;
using MovieDB.Domain.Repositories;


namespace MovieDB.Application.Services
{
    public class UserService
    {
        private readonly AuthenticationHelper _authenticationHelper;
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository,
            AuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
            _userRepository = userRepository;
        }

        public void RegisterUser(User user)
        {
            string hashedPassword = _authenticationHelper.HashPassword(user.PasswordHash);
            user.PasswordHash = hashedPassword;
            _userRepository.Insert(user);
        }

       
    }
}
