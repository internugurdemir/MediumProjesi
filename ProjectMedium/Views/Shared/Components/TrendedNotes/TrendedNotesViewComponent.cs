using Microsoft.AspNetCore.Mvc;
using ProjectMedium.Models.DataAccess;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Views.Shared.Components.TrendedNotes
{
    public class TrendedNotesViewComponent:ViewComponent
    {
        NoteRepositories noteReps;

        public TrendedNotesViewComponent(MediumDbContext ctx)
        {
            noteReps = new NoteRepositories(ctx);

        }

        public IViewComponentResult Invoke()
        {
            List<Note> notes = noteReps.GetTop6Note();

            return View(model: notes);
        }

    }

}
