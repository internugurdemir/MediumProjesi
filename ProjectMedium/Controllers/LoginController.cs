using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMedium.Models.DataAccess;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectMedium.Controllers
{
    public class LoginController : Controller
    {
        private readonly MediumDbContext _context;

        UserRepositories uRep;

        public LoginController(MediumDbContext context)
        {
            _context = context;
            uRep = new UserRepositories(context);
        }


        //[AllowAnonymous]
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(User user)
        {
            var value = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.IsActive == true);
            string mail = value.Email;
            
            if (value != null)
            {/*Değer geliyorsa*/
                //var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Email, user.Email)
                //};
                //var useridentity = new ClaimsIdentity(claims, "Login");
                //ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                //await HttpContext.SignInAsync(principal);
                AddCookie(value.Email);
                return RedirectToAction("SaveMailName", "Home", new { mail });
            }
            ViewBag.NotRegister = "COULD NOT FOUND NOW¿¿¿";

            return View();
        }

        private void AddCookie(string Email)
        {
            if (Request.Cookies["EMail"] == null)
            {

                HttpContext.Response.Cookies.Append("EMail", Email);
            }
        }
        private void DeleteCookie()
        {
                Response.Cookies.Delete("EMail");
       
        }
    
        [HttpGet]
        public IActionResult Logout()
        {
            DeleteCookie();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult ToTheLogin()
        {

            return View();

        }





        public IActionResult Cikis()
        {
            DeleteCookie();
            return RedirectToAction("Logout", "Home");
        }

    }
}
