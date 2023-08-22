using BookStore.Core.Entities.Models;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.Interface
{
    public interface IUserRepository:IRepository<User>
    {
        bool CreateUser(SignUpModel model);
        User ValidateUser(string Email, string Password);
        public bool EmailPresent(string email);
        User ConvertToUser(SignUpModel model);
    }
}
