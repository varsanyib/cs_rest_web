using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRequest_CS.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public bool Completed { get; set; }

        public Todo(string title, string details, bool completed)
        {
            Title = title;
            Details = details;
            Completed = completed;
        }

        public Todo(int id, string title, string details, bool completed)
        {
            Id = id;
            Title = title;
            Details = details;
            Completed = completed;
        }
    }
}
