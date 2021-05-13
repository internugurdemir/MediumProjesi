using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMedium.Models.DataAccess.Entitites;

namespace ProjectMedium.Models.DataAccess.Repositories
{
    class NoteRepositories
    {
        MediumDbContext context;
        public NoteRepositories(MediumDbContext ctx)
        {
            context = ctx;
            //boostDbContext = new BoostDbContext();
        }

        public NoteRepositories()
        {
        }

        public Note AddNote(Note note)
        {
            if (note.Title.Length < 2 || note.Content.Length<2)
            {
                throw new Exception("Başlık ve içerik en az 2 karakter olmalıdır");
            }
            note.ReadingCount = 0;
            note.IsActive = true;
            note.CreatedDate = DateTime.Now;

            CheckNote(note);

            context.Notes.Add(note);
            context.SaveChanges();
            return note;
        }

        private void CheckNote(Note note)
        {
            uint length = (uint)note.Content.Length;
            uint averagemin = length / 750;
            if (note.ReadingTime < 1)
            {
                if (averagemin == 0)
                {
                    averagemin = 1;
                }
            }
            note.ReadingTime = (ushort)averagemin;
         


        }
        private int CheckNoteV3BySemih(Note note)
        {
            char[] seperator = { };

            int wordsCount = note.Content.Split(seperator, StringSplitOptions.RemoveEmptyEntries).Length;

            if (wordsCount < 300)
            {
                return 1;
            }

            return wordsCount / 300;

        }

        public List<Note> SearchNotes(string searchString)
        {

            List<Note> notes = context.Notes.Where(n => n.Content.Contains(searchString) ||
                                               n.Title.Contains(searchString) ||
                                               n.User.FullName.Contains(searchString)).ToList();

            return notes;
        }

        public IEnumerable<Note> GetNotes()
        {
            return context.Notes.ToList();
        }
        public List<Note> GetNotesasList()
        {
            return context.Notes.ToList();
        }
        //public List<Note> GetNoteList()
        //{
        //    return context.Notes.ToList();
        //}

        public User GetUser(string usermail)
        {
            var user = context.Users.Where(a => a.Email == usermail).FirstOrDefault();
            return user;

        }
        public List<Note> GetTop6Note()
        {
            return context.Notes.OrderByDescending(a => a.ReadingCount).Take(6).ToList();

        }  
        public List<Note> GetMostReadedNotes()
        {
            return context.Notes.OrderByDescending(a => a.ReadingCount).ToList();

        }

        #region IEnumerable vs ?
        //public List<Note> GetNotesbySet()
        //{
        //    return context.Set<Note>().ToList();
        //} 
        #endregion
        public Note GetNoteByID(int id)
        {
            Note note = new Note();
            note = context.Notes.Where(a => a.NoteID == id).SingleOrDefault();
            return note;
        }
        public List<Note> GetNoteByTopicID(int id)
        {
            List<NoteTopic> noteTopics = context.NoteTopics.Include(a => a.Note).Where(a => a.TopicId == id).ToList();
            List<Note> notlar = new List<Note>();
            Note not;
            foreach (var item in noteTopics)
            {
                not = new Note();
                not.NoteID = item.Note.NoteID;
                not.CreatedDate = item.Note.CreatedDate;
                not.IsActive = item.Note.IsActive;
                not.ModifiedDate = item.Note.ModifiedDate;
                not.NoteTopics = item.Note.NoteTopics;
                not.Title = item.Note.Title;
                not.Content = item.Note.Content;
                not.ReadingCount = item.Note.ReadingCount;
                not.ReadingTime = item.Note.ReadingTime;

            }
            return notlar;
        }
        public List<Note> GetNoteByUserID(int id)
        {
            List<Note> notes = context.Notes.Include(a => a.NoteID).Where(a => a.User.UserID == id).ToList();
            List<Note> notlar = new List<Note>();
            Note not;
            foreach (var item in notes)
            {
                not = new Note();
                not.NoteID = item.NoteID;
                not.CreatedDate = item.CreatedDate;
                not.IsActive = item.IsActive;
                not.ModifiedDate = item.ModifiedDate;
                not.NoteTopics = item.NoteTopics;
                not.Title = item.Title;
                not.Content = item.Content;
                not.ReadingCount = item.ReadingCount;
                not.ReadingTime = item.ReadingTime;

            }
            return notlar;
        }
        public void DeleteNote(int id)
        {
            Note note = context.Notes.Where(a => a.NoteID == id).SingleOrDefault();
            context.Notes.Remove(note);
        }
        public void UpdateNote(Note note)
        {
            //context.Entry(aboutUser).State = EntityState.Modified;
            note.ReadingCount = 0;
            note.IsActive = note.IsActive;
            note.CreatedDate = DateTime.Now;

            CheckNote(note);

            context.Notes.Add(note);
            context.SaveChanges();
        }

            public void UpdateEditedNote(Note updatenote)
        {
            
            Note note = GetNoteByID(updatenote.NoteID);
            note.Title = updatenote.Title;
            note.Content = updatenote.Content;
            note.IsActive = updatenote.IsActive;
            note.ReadingCount = updatenote.ReadingCount;
            CheckNote(updatenote);
            note.IsActive = note.IsActive;
            note.ModifiedDate = DateTime.Now;


            //context.Entry(updatenote).State = EntityState.Modified;
            //kayıt için

            context.SaveChanges();
        }

        public List<Note> ListwithStr(string p)
        {
            return context.Set<Note>().Include(p).ToList();
        }
        public List<Note> Listwithfilter(Expression<Func<Note,bool>> filter)
        {
            return context.Set<Note>().Where(filter).ToList();
        }
        public void ReadedNote(int id)
        {
            Note note = context.Notes.Where(a => a.NoteID == id).SingleOrDefault();
            note.ReadingCount++;
            context.SaveChanges();
        }
        //Internet https://www.youtube.com/watch?v=q6-ROeM4wSw&list=PLKnjBHu2xXNOld1njNVQ5fk0e12oqiWc8&index=52


        public void NoteAddbyint(Note ct)
        {
            context.Notes.Add(ct);
            context.SaveChanges();
        }
   
        public void NoteRemoveByint(Note ct)
        {
            context.Notes.Remove(ct);
            context.SaveChanges();
        }
        public void NoteUpdatebyint(Note ct)
        {
            context.Notes.Update(ct);
            context.SaveChanges();
        }


        public void GetNoteByint(int id)
        {
            context.Notes.Find(id);
        }
        public List<Note> NoteListByint(int id)
        {
            return context.Notes.Where(a => a.UserID == id).ToList();
        }

    }
}
