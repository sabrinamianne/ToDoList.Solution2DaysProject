using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      
      return View(allCategories);
    }



    [Produces("text/html")]
    [Route("/favorite_photos")]
    public ActionResult FavoritePhotos()
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
