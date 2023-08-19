using BookStore.Core.Entities.Models;
using BookStore.Models;
using BookStore.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : Controller
    {
        IAuthService _authService;
        public AccountsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                bool emailispresent = _authService.EmailPresent(model.Email);
                if (emailispresent)
                {
                    return StatusCode(StatusCodes.Status302Found, "Email already present");
                }
                else if (model.Password != model.ConfirmPassword)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Passwords do not match");
                }
                else
                {
                    bool created = _authService.CreateUser(model);
                    if (!created)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "Please try again after some time");
                    }
                    return StatusCode(StatusCodes.Status200OK, "Sign Up Successful");
                }
            }
            else
                return StatusCode(StatusCodes.Status400BadRequest, "Please input in right state");


        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                User user = _authService.ValidateUser(model.Email, model.Password);
                if (user != null)
                {
                    //GenerateTicket(user);
                    return StatusCode(StatusCodes.Status200OK, "Login Successful");
                    //  }
                }
                return StatusCode(StatusCodes.Status404NotFound, "Invalid Username or Password");

            }
            return StatusCode(StatusCodes.Status404NotFound, "Type in correct input");
        }
        [HttpGet("{email}/{password}")]
        public IActionResult Getuser(string email,string password)
        {
            var data = _authService.ValidateUser(email, password);
            //return Ok(data);
            if (data==null)
            {
                return BadRequest("No data exists");
            }
            return StatusCode(StatusCodes.Status202Accepted, data);
        }





    }
}
