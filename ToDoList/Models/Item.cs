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
    private int _categoryId;
    // private static List<Item> _instances = new List<Item>{}; //list

    public Item (string description, DateTime duedate, int categoryId, int id=0) // constructor
    {
      _description = description;
      _duedate = duedate;
      _categoryId = categoryId;
      // _instances.Add(this); //what is this
      _id = id;
    }

    public int GetCategoryId()
    {
      return _categoryId;
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
        int itemCategoryId = rdr.GetInt32(2);
        DateTime itemDueDate = rdr.GetDateTime(3);
        Item newItem = new Item (itemDescription,itemCategoryId,itemDueDate);
        allItems.Add(newItem);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allItems;

    }



        public static List<Item> Sort()
        {
          List<Item> allItems = new List<Item>{ };

          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM items ORDER BY duedate DESC;";
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

      bool idEquality = this.GetId() == newItem.GetId();
      bool descriptionEquality = this.GetDescription() == newItem.GetDescription();
      bool categoryEquality = this.GetCategoryId() == newItem.GetCategoryId();
      return (idEquality && descriptionEquality && categoryEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO items (description, category_id, duedate) VALUES (@ItemDescription,  @category_id, @ItemDueDate);";
      MySqlParameter description = new MySqlParameter();
      MySqlParameter duedate = new MySqlParameter();
      MySqlParameter categoryId = new MySqlParameter();
      description.ParameterName = "@ItemDescription";
      duedate.ParameterName = "@ItemDueDate";
      categoryId.ParameterName = "@category_id";
      description.Value = this._description;
      duedate.Value = this._duedate;
      categoryId.Value = this._categoryId;
      cmd.Parameters.Add(description);
      cmd.Parameters.Add(duedate);
       cmd.Parameters.Add(categoryId);
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
    cmd.CommandText = @"SELECT * FROM items WHERE id = (@searchId);";
    MySqlParameter thisId = new MySqlParameter();
    searchId.ParameterName = "@searchId";
    searchId.Value = id;
    cmd.Parameters.Add(searchId);
    var rdr = cmd.ExecuteReader() as MySqlDataReader;
    int itemId=0;
    string itemDescription ="";
    int itemCategoryId = 0;
    DateTime itemDueDate = new DateTime();

    while(rdr.Read())
    {
      itemId = rdr.GetInt32(0);
      itemDescription = rdr.GetString(1);
      itemCategoryId = rdr.GetInt32(2);
      itemDueDate = rdr.GetDateTime(3);
    }
    Item fountItem = new Item (itemDescription,itemDueDate,itemCategoryId,itemId);

    conn.Close();
    if(conn != null)
    {
      conn.Dispose();
    }
    return fountItem;
    }

    public void Edit (string newDescription)
    {
      MySqlConnection conn = DB.Connection();
      conn Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE items SET description = @newDescription WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter description = new MySqlParameter();
      description.ParameterName = "@newDescription";
      description.Value = newDescription;
      cmd.Parameters.Add(description);
      cmd.ExecuteNonQuery();
      _description = newDescription;

      conn.Close();
      if (conn!=null)
      {
        conn.Dispose();
      }



    }

    public int GetCategoryId()
    {
      return 89;
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
