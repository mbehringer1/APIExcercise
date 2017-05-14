using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace APIConsole
{
    /// <summary>
    /// Using LiteDB as an embedded database
    /// </summary>
    class NotesDAL : INotesDAL
    {
        /// <summary>
        /// The database name
        /// </summary>
        private const string dbName = "embed.db";
        /// <summary>
        /// The table name
        /// </summary>
        private const string tblName = "notes";

        /// <summary>
        /// Creates the specified note.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        public Note Create(string note)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var notes = db.GetCollection<Note>(tblName);
                var newNote = new Note
                {
                    Body = note
                };
                notes.Insert(newNote);
                return newNote;
            }
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="note">The note.</param>
        public Note Update(int id, string note)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public List<Note> Read(Expression<Func<Note, bool>> predicate = null)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var notes = db.GetCollection<Note>(tblName);
                return notes.Find(predicate).ToList();
            }
        }

        /// <summary>
        /// Reads all.
        /// </summary>
        /// <returns></returns>
        public List<Note> ReadAll()
        {
            using (var db = new LiteDatabase(dbName))
            {
                return db.GetCollection<Note>(tblName).FindAll().ToList();
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public Note Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
