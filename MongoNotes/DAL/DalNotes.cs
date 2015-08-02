using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using mongoNotes.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace mongoNotes.DAL
{
    public class DalNotes
    {
        //private bool disposed = false;
        private string dbName = "myMongoApp";
        private string collectionName = "Notes";
        DAL dal = new DAL();
        //MongoUrl Url;

        private List<Note> ListCollections = new List<Note>(); 

        public DalNotes()
        {            
        }

        public List<Note> GetAllNotes()
        {
            var collection = GetNotesCollection();

            if (!collection.Equals(null))
            {
                var list = collection.FindAll().ToList<Note>();

                return list;
            }

            return new List<Note>();
        }

        public Note GetNoteForEdit(string id)
        {
            var list = GetNotesCollection().FindAll().ToList<Note>();
            var noteForEdit = list.Where(x => x.Id.ToString().Equals(id)).First();

            return noteForEdit;
        }

        public MongoCollection<Note> GetNotesCollection()
        {
            try
            {
                List<Note> listNotes = new List<Note>();
                var db = dal.MongoConnection(dbName);
                var collection = db.GetCollection<Note>(collectionName);

                return collection;
            }
            catch(TimeoutException tmex)
            {
                return null;
            }            
        }

        // Creates a Note and inserts it into the collection in MongoDB.
        public void CreateNote(Note note)
        {
            MongoCollection<Note> collection = GetNotesCollection();

            try
            {
                collection.Insert(note);
            }
            catch (MongoCommandException ex)
            {
                string msg = ex.Message;
            }
        }

        public void SaveNote(Note note)
        {
            //MongoCollection<Note> collection = GetNotesCollection();
            
            //Expression<Func<Note, bool>> criteria = x => x.Id ==  

            try
            {
               
            }
            catch (MongoCommandException ex)
            {
                string msg = ex.Message;
            }
        }

    }
}