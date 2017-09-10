using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoWebApplication.data;
using ToDoWebApplication.web.Models;

namespace ToDoWebApplication.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? CategoryId)
            
        {
            int? categoryId;
            if(CategoryId == null || CategoryId == 0)
            {
               categoryId = 0;
            }
            else
            {
                categoryId = CategoryId;
            }
            ToDoManager manager = new ToDoManager(Properties.Settings.Default.ConStr);
            IndexView iv = new IndexView();
            iv.Categories = manager.GetCategories();
            iv.ToDos = manager.GetToDos(categoryId);
                       
            return View(iv);
        }
        public ActionResult ToDo(ToDo toDo)
        {
            ToDoManager manager = new ToDoManager(Properties.Settings.Default.ConStr);
            TodoView tdv = new TodoView();
            tdv.ToDo = toDo;
            return View(tdv);
        }
        

    }
}