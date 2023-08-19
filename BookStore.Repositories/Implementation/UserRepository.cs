using BookStore.Core.Entities;
using BookStore.Core.Entities.Models;
using BookStore.Models;
using BookStore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(nonstopioContext db) : base(db)
        {

        }
        public User ConvertToUser(SignUpModel model)
        {
            User user = new User()
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
            };
            return user;
        }

        public bool CreateUser(SignUpModel model)
        {
            try
            {
                User user = ConvertToUser(model);
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool EmailPresent(string email)
        {
            var isPresent = _db.Users.Where(u => u.Email == email).FirstOrDefault();
            if (isPresent != null)
                return true;
            return false;
        }

        public User ValidateUser(string Email, string Password)
        {
            User user = _db.Users.Where(u => u.Email == Email).FirstOrDefault();
            if (user != null)
            {
                bool isverified = BCrypt.Net.BCrypt.Verify(Password, user.Password);//"$2a$11$F9jdWYIs3PehPnPCjeXK6uhlSpZGT9BEQtt3yNW4EZlf9LupPaJEe"
                if (isverified)//$2a$11$F9jdWYIs3PehPnPCjeXK6uhlSpZGT9BEQtt3yNW4EZlf9LupPaJEe
                {
                    //if (isverified)
                    //{
                    //    UserModel model = new UserModel
                    //    {
                    //        Id = user.Id,
                    //        Name = user.Name,
                    //        Email = user.Email,
                    //        PhoneNumber = user.PhoneNumber,
                    //        Roles = user.Roles.Select(r => r.Name).ToArray(),
                    //    };
                        return user;
                }
            }
            return null;
        }
    }
}
