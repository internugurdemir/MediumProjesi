using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkibimizDB.Views.Shared.Components.Login
{
    public class loginTimeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string logintime = "";


            if (HttpContext.Request.Cookies.ContainsKey("FirstLoginTime"))
            {
                logintime = HttpContext.Request.Cookies["FirstLoginTime"];
                HttpContext.Response.Cookies.Append("LoginTime", DateTime.Now.ToUniversalTime().ToString());
            }
            else
            {

            }




            return View(model: logintime);
        }
    }
}
