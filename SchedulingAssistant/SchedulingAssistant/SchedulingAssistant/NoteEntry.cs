using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SchedulingAssistant
{
    public class NoteEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
