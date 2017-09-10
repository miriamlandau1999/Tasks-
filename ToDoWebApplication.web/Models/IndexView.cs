using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoWebApplication.data;

namespace ToDoWebApplication.web.Models
{
    public class IndexView
    {
        public IEnumerable<ToDo> ToDos { get; set; }
        public IEnumerable<Category> Categories { get;set;}

    }
}