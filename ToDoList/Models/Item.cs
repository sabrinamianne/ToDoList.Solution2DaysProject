using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Item // class
  {
    private string _description; // field

    private DateTime _duedate;
    private int _id;
    // private static List<Item> _instances = new List<Item>{}; //list

    public Item (string description, DateTime duedate, int id=0) // constructor
    {
      _description = description;
      _duedate = duedate;
      // _instances.Add(this); //what is this
      _id = id;
    }


    public string GetDescription()
    {
      return _description;
    }

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }




        public DateTime GetDueDate()
        {
          return _duedate;
        }

        public void SetDueDate(DateTime newDueDate)
        {
          _duedate = newDueDate;
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
        DateTime itemDueDate = rdr.GetDateTime(2);
        Item newItem = new Item (itemDescription,itemDueDate);
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

        // bool idEquality = (this.GetId() == newItem.GetId());
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

      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public int GetId()
    {
      return _id;
    }
    //
    public static Item Find (int id)
    {

    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM items WHERE id = @thisId;";
    MySqlParameter thisId = new MySqlParameter();
    thisId.ParameterName = "@thisId";
    thisId.Value = id;
    cmd.Parameters.Add(thisId);
    var rdr = cmd.ExecuteReader() as MySqlDataReader;
    int itemId=0;
    string itemDescription ="";
    DateTime itemDueDate = new DateTime();

    while(rdr.Read())
    {
      itemId = rdr.GetInt32(0);
      itemDescription = rdr.GetString(1);
      itemDueDate = rdr.GetDateTime(2);
    }
    Item fountItem = new Item (itemDescription,itemDueDate, itemId);

    conn.Close();
    if(conn != null)
    {
      conn.Dispose();
    }
    return fountItem;
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
