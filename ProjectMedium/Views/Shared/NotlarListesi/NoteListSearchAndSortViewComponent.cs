using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMedium.Models.DataAccess;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkibimizDB.Views.Shared.Components.Login
{
   
    public class NoteListSearchAndSortViewComponent : ViewComponent
    {
        private readonly NoteRepositories noteRepositories;
        //public NotesController(MediumDbContext context)
        //{
        //    noteRepositories = new NoteRepositories(context);
        //    return noteRepositories;

        //}


        public IViewComponentResult Invoke(string searchString, string sortOrder, string currentFilter, int? page)
        {

           

                var notes = noteRepositories.GetNotes();
    
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



            if (!String.IsNullOrEmpty(sortOrder = ""))
            {

            }


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

            return View(notes);

        
    }
    }
}
