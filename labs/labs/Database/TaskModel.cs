using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace labs.Database
{
    [Table ("Tasks")]
    public class TaskModel
    {
        [PrimaryKey,AutoIncrement,NotNull]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateOfCreating { get; set; }

        public DateTime DateOfFinishing { get; set; }

        public bool IsDone { get; set; }

        public int Mark { get; set; }

    }
}
