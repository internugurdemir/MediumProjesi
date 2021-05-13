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

namespace ProjectMedium.Controllers
{
    public class TopicsController : Controller
    {
        private readonly MediumDbContext _context;
        TopicRepositories tRep;
        public TopicsController(MediumDbContext context)
        {
            _context = context;
            tRep = new TopicRepositories(context);

        }

        // GET: Topics
        [Route("/Topics")]
        public IActionResult Index(string searchString, string sortOrder, string currentFilter, int? page)
        {

            var topics = from t in _context.Topics
                         select t;

            if (!String.IsNullOrEmpty(searchString))
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.currentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                topics = topics.Where(e => e.TopicName.Contains(searchString));
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.TopicNameSortOrder = "TopicNameAsc";


            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "";
            }

            switch (sortOrder)
            {

                case "TopicNameAsc":
                    ViewBag.TopicNameSortOrder = "TopicNameDesc";
                    topics = topics.OrderBy(t => t.TopicName);
                    break;
                case "TopicNameDesc":
                    ViewBag.TopicNameSortOrder = "TopicNameAsc";
                    topics = topics.OrderByDescending(t => t.TopicName);
                    break;

                default:
                    topics = topics.OrderBy(t => t.TopicID);
                    break;
            }
            /*
             * Sayfa ekleme kısmını 20+ konu olunca yap pege ile ilgili
             */
            int pageSize = 5;
            int pageNumber = (page ?? 1);


            return View(topics.ToPagedList(pageNumber, pageSize));
        }

        // GET: Topics/Details/5
        //[Route("/Konular/Detay/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.TopicID == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // GET: Topics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("TopicID,TopicName")]*/ Topic topic)
        {


            if (ModelState.IsValid)
            {
                tRep.AddTopic(topic);
                //_context.Add(topic);
                
                if (topic.TopicName == "Errorbydem12")
                {
                    ViewBag.Errorbydem12 = "Already exist topic";
                    return View(topic);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                return View(topic);
        }

        // GET: Topics/Edit/5
        //[Route("/Konular/Edit/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TopicID,TopicName")] Topic topic)
        {
            if (id != topic.TopicID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.TopicID))
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
            return View(topic);
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.TopicID == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.TopicID == id);
        }
        public IActionResult TopicsGet(int id)
        {
            //var a = tRep.GetTopicByID(id);
            //Topic topic=new Topic()
            //{
            //    TopicName=a.TopicName;

            //}


            return View();
        }




    }
}
