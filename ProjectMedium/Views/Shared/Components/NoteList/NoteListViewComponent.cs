using Microsoft.AspNetCore.Mvc;
using ProjectMedium.Models.DataAccess;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Views.Shared.Components.FoodGetList
{
    public class NoteListViewComponent : ViewComponent
    {
        NoteRepositories noteReps;

        public NoteListViewComponent(MediumDbContext ctx)
        {
            noteReps = new NoteRepositories(ctx);
        }

        public IViewComponentResult Invoke()
        {
            List<Note> notes = noteReps.GetNotesasList();

            return View(model: notes);
        }

    }
}
