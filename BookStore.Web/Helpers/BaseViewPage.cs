using BookStore.Core.Entities.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BookStore.Web.Helpers
{
    public abstract class  BaseViewPage<TModel> : RazorPage<TModel>
    {
        public User CurrentUser
        {
            get
            {
                if (User.Claims.Count() > 0)
                {
                    string userData = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
                    var user = JsonConvert.DeserializeObject<User>(userData);
                    return user;
                }
                return null;
            }
        }
    }
}
