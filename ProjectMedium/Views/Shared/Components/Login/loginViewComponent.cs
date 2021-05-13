using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkibimizDB.Views.Shared.Components.Login
{
    public class loginViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string mailName;

            //mailName = HttpContext.Session.GetString("MailName");

            //Cookie olarak oku
            if (HttpContext.Request.Cookies.ContainsKey("MailName"))
            {
                mailName = HttpContext.Request.Cookies["MailName"];
            }
            else
            {
                mailName = "";
            }


            return View(model: mailName);
        }
    }
}
