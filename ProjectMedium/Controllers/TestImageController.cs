using Microsoft.AspNetCore.Mvc;
using ProjectMedium.Models.DataAccess;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Controllers
{
    public class TestImageController : Controller
    {
        MediumDbContext context;
        UserRepositories userRepositories;
        NoteRepositories noteRepositories;
        TopicRepositories topicRepositories;

        public TestImageController(MediumDbContext context)
        {
            this.context = context;
            userRepositories = new UserRepositories(context);
            topicRepositories = new TopicRepositories(context);
            noteRepositories = new NoteRepositories(context);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TopicEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TopicEkle(Topic topic)
        {
            return View();
        }
    }
}
