using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIConsole
{
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// Gets or sets the notes dal.
        /// </summary>
        /// <value>
        /// The notes dal.
        /// </value>
        private INotesDAL NotesDAL { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController" /> class.
        /// </summary>
        /// <param name="notesDAL">The notes dal.</param>
        public NotesController(INotesDAL notesDAL)
        {
            NotesDAL = notesDAL;
        }

        /// <summary>
        /// Gets the specified note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="query">The query.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        [HttpGet("{id?}")]
        public List<Note> Get(int id, string query, bool ignoreCase = false)
        {
            List<Note> result = new List<Note>();
            if (id != 0)
            {
                result = NotesDAL.Read(n => n.Id == id);
            }
            else if (!string.IsNullOrWhiteSpace(query))
            {
                if (ignoreCase)
                {
                    //just a quirk of LiteDB
                    var caseIgnoredList = NotesDAL.ReadAll().Where(w => w.Body.ToUpper().Contains(query.ToUpper())).ToList();
                    result = caseIgnoredList;
                }
                else
                {
                    result = NotesDAL.Read(n => n.Body.Contains(query));
                }
            }
            else
            {
                result = NotesDAL.ReadAll();
            }
            return result;
        }
        
        /// <summary>
        /// Posts the specified note.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPost]
        public Note Post(string value)
        {
            NotesDAL nd = new NotesDAL();
            var result = nd.Create(value);
            return result;
        }
    }
}
