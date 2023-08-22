using BookStore.Core.Entities.Models;
using BookStore.Models;
using BookStore.Repositories.Implementation;
using BookStore.Repositories.Interface;
using BookStore.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Implementation
{
    public class AuthService : Service<User>, IAuthService
    {
        IUserRepository _userRepo
        {
            get
            {
                return _repo as UserRepository;
            }
        }
        public AuthService(IUserRepository userRepo) : base(userRepo)
        {
            //_userRepo= userRepo;
        }
        public User ConvertToUser(SignUpModel model)
        {
            return _userRepo.ConvertToUser(model);
        }

        public bool CreateUser(SignUpModel model)
        {
          return _userRepo.CreateUser(model);
        }

        public bool EmailPresent(string email)
        {
           return _userRepo.EmailPresent(email);
        }

        public User ValidateUser(string Email, string Password)
        {
            return _userRepo.ValidateUser(Email, Password);
        }
    }
}
