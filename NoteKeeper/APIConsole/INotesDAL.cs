using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace APIConsole
{
    public interface INotesDAL
    {
        Note Create(string note);
        Note Update(int id, string note);
        List<Note> Read(Expression<Func<Note, bool>> predicate = null);
        List<Note> ReadAll();
        Note Delete(int id);
    }
}