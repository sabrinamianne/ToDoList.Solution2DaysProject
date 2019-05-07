using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
      Category newCategory = new Category(categoryName);
      List<Category> allCategories = Category.GetAll();
      return View("Index", allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Item> categoryItems = selectedCategory.GetItems();
      model.Add("category", selectedCategory);
      model.Add("items", categoryItems);
      return View(model);
    }

    [HttpPost("/categories/{categoryId}/items")]
    public ActionResult Create(int categoryId, string itemDescription, DateTime dueDate  )
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Item newItem = new Item(itemDescription, dueDate);
      newItem.Save();
      foundCategory.AddItem(newItem);
      List<Item> categoryItems = foundCategory.GetItems();
      model.Add("items", categoryItems);
      model.Add("category", foundCategory);
      return View("Show", model);
    }


    [HttpGet("/categories/{categoryId}/itemssort")]
    public ActionResult Sort(int categoryId, string itemDescription, DateTime dueDate  )
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      // Item newItem = new Item(itemDescription, dueDate);
      // newItem.Save();
      // foundCategory.AddItem(newItem);
      List<Item> sortedItems = Item.Sort();
      model.Add("items", sortedItems);
      model.Add("category", foundCategory);
      return View("Show", model);
    }

    [HttpPost("/categories/{categoryId}/items/{itemId}/deleteitem")]
    public ActionResult ShowId (int categoryId, int itemId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Item item = Item.Find(itemId);
      // item.DeleteItem();
      foundCategory.ClearItem(item);
      List<Item> categoryItems = foundCategory.GetItems();
      model.Add("items", categoryItems);
      model.Add("category", foundCategory);
      return View("Show", model);
    }

    [HttpGet("/search_by_category")]
    public ActionResult SearchByCategory()
    {
      return View();
    }


    [HttpPost("/search_by_category")]
    public ActionResult Index(string artist)
    {
      List<Category> filteredcategories = Category.FilterAll(artist);
      return View(filteredcategories);
    }

    [HttpPost("/categories/{categoryId}/delete")]
    public ActionResult Delete(int categoryId)

    {
      Category foundCategory = Category.Find(categoryId);
      foundCategory.Delete();
      return RedirectToAction("Index");
    }



  }
}
