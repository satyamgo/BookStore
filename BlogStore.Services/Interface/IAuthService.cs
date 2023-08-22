using BookStore.Core.Entities.Models;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Interface
{
    public interface IAuthService:IService<User>
    {
        bool CreateUser(SignUpModel model);
        User ValidateUser(string Email, string Password);
        bool EmailPresent(string email);
        User ConvertToUser(SignUpModel model);
    }
}
