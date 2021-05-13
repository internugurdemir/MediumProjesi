using Microsoft.AspNetCore.Mvc;
using ProjectMedium.Models.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Views.Shared.Components.FoodGetList
{
    public class NoteListByTopicViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            NoteRepositories noteRepositories = new NoteRepositories();
            var noteList = noteRepositories.GetNotes();
            //var noteList = noteRepositories.Listwithfilter(x=>x.NoteTopics.==id);
            return View(noteList);

        }

    }
}
