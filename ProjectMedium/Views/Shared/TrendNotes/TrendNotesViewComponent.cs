using Microsoft.AspNetCore.Mvc;
using ProjectMedium.Models.DataAccess;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Views.Shared.TrendNotes
{
    public class TrendNotesViewComponent: ViewComponent
        {
            NoteRepositories noteRep;

            public TrendNotesViewComponent(MediumDbContext ctx)
            {
                 noteRep = new NoteRepositories(ctx);

            }

            public IViewComponentResult Invoke()
            {
                List<Note> notes = noteRep.GetTop6Note();

                return View(model: notes);
            }
        }
}
