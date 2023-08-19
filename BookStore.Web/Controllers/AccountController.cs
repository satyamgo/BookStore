using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using BookStore.Core.Entities.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using BookStore.Web.Areas.User.Models;

namespace BookStore.Web.Controllers
{
    public class AccountController : Controller
    {
        HttpClient _client;
        IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(configuration["ApiAddress"]);//ApiAddress
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpModel model) {
          if(ModelState.IsValid)
            {
                string strdata = JsonSerializer.Serialize(model);
                StringContent content = new StringContent(strdata, Encoding.UTF8, "application/json");
                var response = _client.PostAsync(_client.BaseAddress + "/accounts/signup", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.message1 = "Sign Up Successful";
                    return View() ;
                }
                else
                {
                    ViewBag.Message ="please check password and unique email id"; 
                    return View() ;  
                }
            }
            ViewBag.Message = "Something went wrong";
            return View();
          
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)//here i am passing correct email and password 
        {
            if(ModelState.IsValid)
            {
                string strdata = JsonSerializer.Serialize(model);
                StringContent content = new StringContent(strdata, Encoding.UTF8, "application/json");
                var response = _client.PostAsync(_client.BaseAddress + "/accounts/login", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    UserModel user = Getuser(model.Email,model.Password);
                    GenerateTicket(user);
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
            }
            ViewBag.Message = "Invalid Username or Password";
            return View(model);
        }
        private async void GenerateTicket(UserModel user)
        {
            string strData = System.Text.Json.JsonSerializer.Serialize(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.email),
                new Claim(ClaimTypes.UserData,strData)
             };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
            });
        }
        private UserModel Getuser(string email,string password)
        {
            UserModel user=new UserModel();
            var response = _client.GetAsync(_client.BaseAddress + "/accounts/Getuser/"+email+"/"+password).Result;//here also actual email and actual password
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                user = JsonSerializer.Deserialize<UserModel>(data);
                if(user == null)
                {
                    return null;

                }
            }

            return user;
        }



        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return RedirectToAction("Login", "Account");
        }


    }
}
