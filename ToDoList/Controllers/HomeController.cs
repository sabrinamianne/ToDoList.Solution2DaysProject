using Microsoft.AspNetCore.Mvc;


namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {

      return View();
    }

  }
}

// Item myItem = new Item();
// myItem.SetDescription();

// public void setDescription(string description) {
// this.
// }

//  return View("Index.cshtml", starterItem);
