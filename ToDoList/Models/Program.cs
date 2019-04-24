using System;
using System.Collections.Generic;

namespace ToDoList.Models {
  public class Program
  {
    public static void Main()
    {
      Console.WriteLine ("Welcome to the To Do List!");
      Console.WriteLine ("Would you like to add an item to your list or view your list? (Add/View)");
      string answer = Console.ReadLine();
      if(answer == "Add")
      {
        Console.WriteLine ("Please enter the description for the new item");
        string userNewItem = Console.ReadLine();
        Item newItem = new Item(userNewItem);
       Console.WriteLine(userNewItem + " has been added to your list. Would you like to add an item to your list or view your list? (Add/View");
       Main();
      }

      else if(answer == "View")
      {
        List<Item> allItems = Item.GetAll();
        for (int i =0; i < allItems.Count; i++)
        {
         Console.WriteLine(allItems[i].GetDescription());
        }
        Main();

      }

    }
  }
}
