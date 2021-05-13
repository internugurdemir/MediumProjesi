using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMedium.Models.DataAccess;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProjectMedium.Models.DataAccess.Repositories;

namespace ProjectMedium.Controllers
{


    public class HomeController : Controller
    {
        #region Text için id=002;

        /*İstekleri yaptığımızda karşılayacak
         * Controller sınıflarının  sonun Controller olmalı geleneksel
         * Adı Home özünde class Controller clasından kalıtım controller clasıda        
         *                          Controller : ControllerBase, IActionFilter, IFilterMetadata, IAsyncActionFilter, IDisposable... içi biraz karışık
         *                          Filtetrlardan türer, base classı var
         *                          veri taşımak için
         *                          ilgili request için
         *                          Url değerleri
         *                          Response...
         * Controllerlar bir sınıfı request alabilir ve response döndürebilir                         
         * 
         * Controller sınfları içinde istekleri karşılayan metotlar Action metot olarak adlandırlır
         *              Controller sınfları içinde yazılan metotlar Action metot olarak adlandırlır 
         *      
         */
        #endregion
        MediumDbContext context;
        UserRepositories userRepositories;
        NoteRepositories noteRepositories;
        TopicRepositories topicRepositories;

        public HomeController(MediumDbContext context)
        {
            this.context = context;
            userRepositories = new UserRepositories(context);
            topicRepositories = new TopicRepositories(context);
            noteRepositories = new NoteRepositories(context);
        }


        public IActionResult Topics()
        {

            //List<Topic> topics=topicRepositories.GetTopics();


            //for (int i = 1; i <= 10; i++)
            //{
            //    topics.Add(i.ToString());
            //}
            //ViewBag.unit = new SelectList(numbers);

            //return View();


            return View();
        }


        public IActionResult OurStory()
        {
            return View();
        }

        public IActionResult Index()
        {
            //string str;
            //if (Request.Cookies["EMail"] == null || Request.Cookies["EMail"] == "")
            //{
            //    str= @"C:\Users\ardah\source\Workspaces\Uğur Demir Medium Blog Work\MVCProject\ProjectMedium\wwwroot\Image\anonimr.jpg";
            //}
            //else
            //{
            //    str = null;
            //}
            //    byte[] photo = Convert.FromBase64String(str);
            //int a2 = 44;

            return View();
        }
        //  public IActionResult VeriAl(IFormCollection datas)
        //{

        //    var value1=datas["txtValue1"].ToString();
        //    var value2=datas["txtValue2"].ToString();
        //    var value3=datas["txtValue3"].ToString();
        //    var value4=datas["txtValue4"].ToString();
        //    var value5=datas["txtValue5"].ToString();
        //    return View();
        //}
        //public IActionResult VeriAl(string txtValue1, string txtValue2, string txtValue3, string txtValue4, string txtValue5)
        //{

        //    return View();
        //}
        //public class Model
        //{
        //    public string txtValue1 { get; set; }
        //    public string txtValue2 { get; set; }
        //    public string txtValue3 { get; set; }
        //    public string txtValue4 { get; set; }
        //    public string txtValue5 { get; set; }
        //}
        //public IActionResult VeriAl(Model model)
        //{

        //    return View();
        //}
        public IActionResult SaveMailName(string mail)
        {
            //session yaz
            //HttpContext.Session.SetString("Kullanıcı", userName);
            //Cookie yaz


            if (!HttpContext.Request.Cookies.ContainsKey("MailName")
                || HttpContext.Request.Cookies["MailName"] == "")
            {
                HttpContext.Response.Cookies.Append("MailName", mail);

            }


            if (!HttpContext.Request.Cookies.ContainsKey("FirstLoginTime")
                || HttpContext.Request.Cookies["FirstLoginTime"] == "")
            {

                HttpContext.Response.Cookies.Append("FirstLoginTime", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            }

            return RedirectToAction("Index");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("MailName", "");

            //Cookie sıfırla
            HttpContext.Response.Cookies.Delete("MailName");
            HttpContext.Response.Cookies.Delete("FirstLoginTime");

            return RedirectToAction("Index");

        }
    }
}
