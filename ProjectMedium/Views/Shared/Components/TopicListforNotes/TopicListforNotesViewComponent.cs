using Microsoft.AspNetCore.Mvc;
using ProjectMedium.Models.DataAccess;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Views.Shared.Components.TopicListforNotes
{
    public class TopicListforNotesViewComponent: ViewComponent
    {
        TopicRepositories topicRep;

        public TopicListforNotesViewComponent(MediumDbContext ctx)
        {
            topicRep = new TopicRepositories(ctx);

        }

        public IViewComponentResult Invoke()
        {
            List<Topic> topics = topicRep.GetTopics();

            return View(model: topics);
        }
    }
}
