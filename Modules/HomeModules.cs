using Nancy;
using ToDoList;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/tasks"] = _ => {
        List<Task> allTasks = Task.GetAll();
        return View["tasks.cshtml", allTasks];
      };

      Get["/tasks/new"] = _ => {
        return View["add_new_task"];
      };

      Post["/tasks/added"] = _ => {
        Task newTask = new Task (Request.Form["description"]);
        newTask.Save();
        return View["task_created.cshtml", newTask];
      };

      Get["/tasks/{id}"] = parameters => {
        Task selectedTask = Task.Find(parameters.id);
        return View["task_details.cshtml", selectedTask];
      };

      Get["/tasks/cleared"] = _ => {
        Task.DeleteAll();
        return View["tasks_deleted.cshtml"];
      };
    }
  }
}
