using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMedium.Models.DataAccess.Entitites;

namespace ProjectMedium.Models.DataAccess.Repositories
{
    public class TopicRepositories
    {
        MediumDbContext context;

        public TopicRepositories(MediumDbContext ctx)
        {
            context = ctx;
            //boostDbContext = new BoostDbContext();
        }

        public void AddTopic(Topic topic)
        {
            checkTopic(topic);
            context.Topics.Add(topic);
        }

        private void checkTopic(Topic topic)
        {
          
            foreach (var item in context.Topics)
            {
                if (topic.TopicName == item.TopicName)
                {
                    topic.TopicName = "Errorbydem12";
                }
            }

        }

        public List<Topic> GetTopics()
        {

            return context.Topics.ToList();
        }
        public List<Topic> GetTopicsForNotes()
        {

            return context.Topics.ToList();
        }
        public Topic GetTopicByID(int id)
        {
            return context.Topics.Find(id);
        }
        public void DeleteTopic(int topicID)
        {
            Topic topic = context.Topics.Find(topicID);
            context.Topics.Remove(topic);
            context.SaveChanges();

        }

        public void UpdateNote(Topic topic)
        {
            //context.Entry(aboutUser).State = EntityState.Modified;
            context.SaveChanges();
        }




    }
}
