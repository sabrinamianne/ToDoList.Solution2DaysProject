using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Item // class
  {
    private string _description; // field
    // private int _id;
    // private static List<Item> _instances = new List<Item>{}; //list

    public Item (string description) // constructor
    {
      _description = description;
      // _instances.Add(this); //what is this
      // _id = _instances.Count;
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
      List<Item> allItems = new List<Item>{ };

      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        Item newItem = new Item (itemDescription);
        allItems.Add(newItem);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allItems;

    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM items;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
    public override bool Equals(System.Object otherItem)
    {
      if (!(otherItem is Item))
      {
        return false;
      }
      else
      {
        Item newItem = (Item) otherItem;
        bool descriptionEquality = (this.GetDescription() == newItem.GetDescription());
        return (descriptionEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO items (description) VALUES (@ItemDescription);";
      MySqlParameter description = new MySqlParameter();
      description.ParameterName = "@ItemDescription";
      description.Value = this._description;
      cmd.Parameters.Add(description);
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public int GetId()
    {
      return 0;
    }
    //
    public static Item Find (int searchId)
    {

    Item dummyItem = new Item("dummy item");
    return dummyItem;
    }

    // public void DeleteItem ()
    // {
    //   for (int i =0; i< _instances.Count; i++)
    //   {
    //     if (_instances[i].GetId() == _id)
    //     {
    //       _instances.Remove(_instances[i]);
    //     }
    //   }
    // }




  }
}
