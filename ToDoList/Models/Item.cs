using System.Collections.Generic;
using System;

namespace ToDoList.Models
{
  public class Item // class
  {
    private string _description; // field
    private int _id;
    private static List<Item> _instances = new List<Item>{}; //list

    public Item (string description) // constructor
    {
      _description = description;
      _instances.Add(this); //what is this
      _id = _instances.Count;
    }


    public string GetDescription()
    {
      return _description;
    }

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<Item> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public int GetId()
    {
      return _id;
    }

    public static Item Find (int searchId)
    {
      for (int i = 0; i < _instances.Count; i++) {
        Console.WriteLine("Item " + _instances[i].GetDescription() + " " + _instances[i].GetId());
      }
      return _instances[searchId-1];
    }


  }
}
