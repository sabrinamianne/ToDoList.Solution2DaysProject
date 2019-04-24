using System;
using System.Collections.Generic;
 namespace ToDoList.Models {
   public class Program
   {
     public static void Main()
     {
       Console.WriteLine("Welcome to the To Do List");
       Console.WriteLine("Would you like to add an item to your list or view your list? (Add/View)");
       string userAnswer = Console.ReadLine();
       if(userAnswer == "Add")
       {
         Console.WriteLine ("Please enter the description for the new item.");
         string answer = Console.ReadLine();
         Item newItem = new Item(answer);
         Console.WriteLine (answer +" has been added to your list.");
          Main();
       }


       else if (userAnswer == "View")
       {
         List<Item> myItems = Item.GetAll();
         for (int i = 0; i < myItems.Count; i++)
         {
           Console.WriteLine(i+1 + ". " + myItems[i].GetDescription());
         }
         Main();
       }
     }
   }
 }
