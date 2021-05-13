using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMedium.Models.DataAccess;
using ProjectMedium.Models.DataAccess.Entitites;
using PagedList.Core;
using ProjectMedium.Models.DataAccess.Repositories;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.IO;
using ProjectMedium.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectMedium.Controllers
{
    public class UsersController : Controller
    {
        private readonly MediumDbContext _context;

        UserRepositories userRepositories;
        NoteRepositories noteRepositories;
        TopicRepositories topicRepositories;

        public UsersController(MediumDbContext context)
        {
            _context = context;
            userRepositories = new UserRepositories(context);
        }

        // GET: Users
        //[Route("/Kullanıcı/")]
        public IActionResult Index(string searchString, string sortOrder, string currentFilter, int? page)
        {
            var users = from u in _context.Users
                        select u;
            if (!String.IsNullOrEmpty(searchString))
                page = 1;
            else
                searchString = currentFilter;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(e => e.FirstName.Contains(searchString) ||
                                               e.LastName.Contains(searchString) ||
                                               e.UserName.Contains(searchString));
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            ViewBag.currentFilter = searchString;


            ViewBag.FirstNameSortOrder = "FirstNameAsc";
            ViewBag.LastNameSortOrder = "LastNameAsc";
            ViewBag.UserNameSortOrder = "UserNameAsc";

            if (!String.IsNullOrEmpty(sortOrder = ""))
            {

            }




            switch (sortOrder)
            {

                case "FirstNameAsc":
                    ViewBag.FirstNameSortOrder = "FirstNameDesc";
                    users = users.OrderBy(u => u.FirstName);
                    break;
                case "FirstNameDesc":
                    ViewBag.FirstNameSortOrder = "FirstNameAsc";
                    users = users.OrderByDescending(u => u.FirstName);
                    break;

                case "LastNameAsc":
                    ViewBag.LastNameSortOrder = "LastNameDesc";
                    users = users.OrderBy(u => u.LastName);
                    break;
                case "LastNameDesc":
                    ViewBag.LastNameSortOrder = "LastNameAsc";
                    users = users.OrderByDescending(u => u.LastName);
                    break;

                case "UserNameAsc":
                    ViewBag.UserNameSortOrder = "UserNameDesc";
                    users = users.OrderBy(u => u.UserName);
                    break;
                case "UserNameDesc":
                    ViewBag.UserNameSortOrder = "UserNameAsc";
                    users = users.OrderByDescending(u => u.UserName);
                    break;



                default:
                    users = users.OrderBy(t => t.UserID);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(users.ToPagedList(pageNumber, pageSize));
        }

        // GET: Users/Details/5
        //[Route("/Kullanıcı/Detay/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            id = userRepositories.GetUser(Request.Cookies["EMail"]).UserID;
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        // GET: Users/Create
        //[Route("/Kullanıcı/Ekle/")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("UserID,FirstName,LastName,UserName,Email,Bio,Photo,Connections,UserRole,CreatedDate,IsActive,ModifiedDate")]*/ User user)
        {


            if (ModelState.IsValid)
            {
                //_context.Add(user);
                userRepositories.AddNUserByYıldıırm(user);
                //return RedirectToAction(nameof(Index));
                if (user.UserName == "ExistEMail12")
                {
                    //kullanıcı maili var
                    return RedirectToAction("ExistMail");
                }
                Aktivasyonmailigönder(user.UserID);
                await _context.SaveChangesAsync();
                return RedirectToAction("Dogrulama");
            }
            return View(user);
        }

        private void Aktivasyonmailigönder(int userID)
        {
            User user = new User();
            user = userRepositories.GetUserByID(userID);
            string controller = user.UserID.ToString();
            string url = string.Format("{0}://{1}", HttpContext.Request.Scheme, HttpContext.Request.Host) + "/Users/Verify?Id=" + controller;
            //HttpContext.Request.Scheme==Local Host yazar: HttpContext.Request.Host: Portu yazar
            string message = string.Format("Üye oldun sayılır. Son adım linke tıkla...\n");
            message += url;
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("DenemeBaBoost@gmail.com");
            mail.To.Add(user.Email);
            mail.Subject = "Deneme";
            mail.Body = message;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("DenemeBaBoost@gmail.com", "DenemeBaBoost123");
            smtpClient.EnableSsl = true;

            smtpClient.Send(mail);


        }
        public ActionResult Verify(string id)
        {
            User user = userRepositories.GetUserByID(Convert.ToInt32(id));
            userRepositories.UpdateUser(user);
            return RedirectToAction("Success");

        }
        public ActionResult Success()
        {

            return View();

        }

        public ActionResult Dogrulama()
        {

            return View();

        }

        public ActionResult ExistMail()
        {

            return View();

        }
        public ActionResult ExistUserName()
        {

            return View();

        }

        [HttpGet]
        public ActionResult SaveImages()
        {
            var stringuser = Request.Cookies["EMail"];


            User user = user = _context.Users.FirstOrDefault(u => u.Email == stringuser);

            return View(user);
        }

        [HttpPost]
        public ActionResult SaveImages(ImageUpload profilephoto)
        {
            var stringuser = Request.Cookies["EMail"];


            User user =  _context.Users.FirstOrDefault(u => u.Email == stringuser);

            if (profilephoto.File.Length>0)
            {
                using (var memorystream = new MemoryStream())
                {
                    profilephoto.File.CopyTo(memorystream);
                    var file = memorystream.ToArray();
                    var fileV2 = Convert.ToBase64String(file);
                    user.Photo = fileV2;
                    userRepositories.UpdateUser(user);
                }
            }
            return View(user);
        }

  
        public IActionResult ShowImage(int id)
        {
            
            User user =_context.Users.FirstOrDefault(u => u.UserID == id);
            byte[] photo;

            if (user!=null)
            {

                photo = Convert.FromBase64String(user.Photo);
            }
            else
            {
                var stringuser = Request.Cookies["EMail"];
                User user1 = _context.Users.FirstOrDefault(u => u.Email == stringuser);
                photo = Convert.FromBase64String(user1.Photo);

            }

            if (photo != null)
            {
                return File(photo, "image/jpeg");
            }
            else
            {

            }
      
            return View();


            //byte[] photo = null;
            //if (Request.Cookies["EMail"]!=null)
            //{
            //    var stringuser = Request.Cookies["EMail"];
            //    User user = _context.Users.FirstOrDefault(u => u.Email == stringuser);
            //    photo = Convert.FromBase64String(user.Photo);

            //}
            //else
            //{
            //    //photo = Convert.FromBase64String(patho);
            //}
            //if (photo!=null)
            //{
            //    return File(photo,"image/jpeg");
            //}

            //return View();
        }


        // GET: Users/Edit/5
        //[Route("/Kullanıcı/Ekle/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,FirstName,LastName,UserName,Email,Bio,Photo,Connections,UserRole,CreatedDate,IsActive,ModifiedDate")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    userRepositories.UpdateUser(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        //[Route("/Kullanıcı/Sil/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }


    }
}
