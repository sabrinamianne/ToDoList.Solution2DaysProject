using System.Collections.Generic;


namespace ToDoList.Models
{
  public class Item // class
  {
    private string _description; // field
    private static List<Item>_instances = new List<Item>{}; //list

    public Item (string description) // constructor
    {
      _description = description;
      _instances.Add(this); //what is this 
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
  }
}
