
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    private string _name;
    private int _id;
    private List<Item> _items;


    public Category(string categoryName)
    {
      _name = categoryName;
      _instances.Add(this);
      _id = _instances.Count;
      _items = new List<Item>{};

    }

    public void AddItem(Item item)
    {
      _items.Add(item);
    }

    public void ClearItem(Item item)
    {
      _items.Remove(item);
    }

    // public static void ClearAll()
    // {
    //
    //   _instances.Clear();
    // }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Category> GetAll()
    {
      List<Category> allCategories = new List<Category> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM categories;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int CategoryId = rdr.GetInt32(0);
        string CategoryName = rdr.GetString(1);
        Category newCategory = new Category(CategoryName);
        allCategories.Add(newCategory);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCategories;
    }

    public List<Item> GetItems()
    {
      return _items;
    }

    public static Category Find(int id)
    {
      return _instances[id-1];
    }

    public static List<Category> FilterAll(string categoryFilter)
    {
     List<Category> filteredcategories = new List<Category>();

      foreach(Category category in _instances)

      {
        if(category.GetName().Contains(categoryFilter))
        {
          filteredcategories.Add(category);
        }
      }

      return filteredcategories ;
    }


    public static void ClearAll()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM categories;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }

    public void Delete ()
    {
      for (int i =0; i< _instances.Count; i++)
      {
        if (_instances[i].GetId() == _id)
        {
          _instances.Remove(_instances[i]);
        }
      }
    }


  }
}
