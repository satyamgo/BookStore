using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using BookStore.Core;
using BookStore.Web.Areas.User.Models;
using BookStore.Web.Helpers;

namespace BookStore.Web.Areas.User.Controllers
{
    [CustomAuthorize]
    [Area("User")]
    public class BaseController : Controller
    {
        public UserModel CurrentUser
        {
            get
            {
                if (User.Claims.Count() > 0)
                {
                    string userData = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
                    var user = JsonConvert.DeserializeObject<UserModel>(userData);
                    return user;
                }
                return null;
            }
        }
    }
}
