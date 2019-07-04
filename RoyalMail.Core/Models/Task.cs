using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalMail.Core.Models
{
    public class Task
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDetail { get; set; }
        public bool IsComlete { get; set; }
    }
}
