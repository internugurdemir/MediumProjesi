using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMedium.Models.DataAccess;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models.DataAccess.Repositories;
using PagedList.Core;
using ProjectMedium.ViewModels;
using Microsoft.AspNetCore.Http;

namespace ProjectMedium.Controllers
{
  
    public class NotesController : Controller
    {
        private readonly MediumDbContext _context;
        NoteRepositories noteRepositories;
        UserRepositories userRepositories;
        TopicRepositories topicRepositories;
        public NotesController(MediumDbContext context)
        {
            _context = context;
            noteRepositories = new NoteRepositories(context);
            userRepositories = new UserRepositories(context);
            topicRepositories = new TopicRepositories(context);

        }


        // GET: Notes

        //[Route("/Notes")]
        public IActionResult Index()
        {
            //var NoteDBContext = _context.Notes.Include(n => n.User);
            //return View(await NoteDBContext.ToListAsync());
         
            return View(noteRepositories.NoteListByint(noteRepositories.GetUser(Request.Cookies["EMail"]).UserID));

        }

        public IActionResult IndexV2(string searchString, string sortOrder, string currentFilter, int? page)
        {
            var notes = from n in _context.Notes
                        select n;
            if (!String.IsNullOrEmpty(searchString))
                page = 1;
            else
                searchString = currentFilter;

            if (!String.IsNullOrEmpty(searchString))
            {
                notes = notes.Where(n => n.Content.Contains(searchString) ||
                                               n.Title.Contains(searchString) ||
                                               n.User.FullName.Contains(searchString));
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.currentFilter = searchString;

            ViewBag.TitleNameSortOrder = "TitleNameAsc";
            ViewBag.CreatedDateSortOrder = "CreatedDateAsc";

            switch (sortOrder)
            {

                case "TitleNameAsc":
                    ViewBag.TitleNameSortOrder = "TitleNameDesc";
                    notes = notes.OrderBy(a => a.Title);
                    break;
                case "TitleNameDesc":
                    ViewBag.TitleNameSortOrder = "TitleNameAsc";
                    notes = notes.OrderByDescending(a => a.Title);
                    break;

                case "CreatedDateAsc":
                    ViewBag.CreatedDateSortOrder = "CreatedDateeDesc";
                    notes = notes.OrderBy(u => u.CreatedDate);
                    break;
                case "CreatedDateDesc":
                    ViewBag.CreatedDateSortOrder = "CreatedDateAsc";
                    notes = notes.OrderByDescending(a => a.CreatedDate);
                    break;



                default:
                    notes = notes.OrderBy(a => a.NoteID);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(notes.ToPagedList(pageNumber, pageSize));
        }


        // GET: Notes/Details/5
        [Route("/Notes/Details/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NoteID == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }


        public ActionResult ReadNote(int id)
        {
            noteRepositories.GetNoteByID(id);
            noteRepositories.ReadedNote(id);
            return View();
        }



        public IActionResult AddTopic(int id) 
        {
            List<TopicforNoteViewModel> topics = topicRepositories.GetTopics().Select(a => new TopicforNoteViewModel { TopicID = a.TopicID, TopicName = a.TopicName, IsSelected=false }).ToList();
            List<NoteTopic> noteTopics = _context.NoteTopics.Where(a => a.NoteId == id).ToList();


            foreach (var topictoselect in noteTopics)
            {
                foreach (var mytopics in topics)
                {
                    if (topictoselect.TopicId == mytopics.TopicID)
                    {
                        mytopics.IsSelected = true;
                    }
                }
            }

            TopicsforNotesViewModel topic = new TopicsforNotesViewModel();
            topic.topicsfornote = topics;
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(30);
            Response.Cookies.Append("NoteId", id.ToString(), options);
            return View(topic);
        }

        [HttpPost]
        public IActionResult AddTopic(TopicsforNotesViewModel model)
        {
            int articleId = int.Parse(Request.Cookies["NoteId"]);
            List<TopicforNoteViewModel> selectedTopics = model.topicsfornote.Where(x => x.IsSelected).ToList<TopicforNoteViewModel>();
            List<NoteTopic> noteTopics = _context.NoteTopics.Where(a => a.NoteId == articleId).ToList();
            _context.NoteTopics.RemoveRange(noteTopics);
            NoteTopic articleTag;
            foreach (var item in selectedTopics)
            {


                articleTag = new NoteTopic();
                articleTag.NoteId = articleId;
                articleTag.TopicId = item.TopicID;
                _context.NoteTopics.Add(articleTag);
                _context.SaveChanges();

            }
            Response.Cookies.Delete("NoteId");
            return RedirectToAction("Index", "Home");
        }




        // GET: Notes/Create
        //[Route("/Notlar/Ekle")]
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email");
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("NoteID,Title,Content,ReadingCount,ReadingTime,UserID,CreatedDate,IsActive,ModifiedDate")]*/ Note note)
        {
            note.UserID = noteRepositories.GetUser(Request.Cookies["EMail"]).UserID;

            //string content = HttpContext.Request.Form["Content"];
            if (ModelState.IsValid)
            {
                //note.Content = content;


                int noteid = noteRepositories.GetNotes().OrderByDescending(a => a.CreatedDate).First().NoteID;

                _context.Add(note);
                noteRepositories.AddNote(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email", note.UserID);
            return View(note);
        }

        // GET: Notes/Edit/5
        //[Route("/Notlar/Edit/{id:int}")]

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes.FindAsync(id);


            if (note == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email", note.UserID);
            return View(note);
        }



        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoteID,Title,Content,ReadingCount,ReadingTime,UserID,CreatedDate,IsActive,ModifiedDate")] Note note)
        {


            if (id != note.NoteID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    noteRepositories.UpdateEditedNote(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.NoteID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email", note.UserID);
            return View(note);
        }

        // GET: Notes/Delete/5
        //[Route("/Notlar/Sil/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NoteID == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.NoteID == id);
        }
    }
}
