using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Trunk
{
 public class Item
 {
   private int _id;
   private string _name;


   public Item (string name, int Id = 0)
   {
    _id = Id;
    _name = name;
    }


    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }
    public string SetName(string name)
    {
      _name = name;
    }

    public static List<Item> GetALL()
    {
      List<Item> allItems = new List<Item>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new DB.SqlCommand("SELECT * from items;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemName = rdr.GetString(1);
        Item newItem = new Item(itemName, itemId);
        allItems.Add(newItem);
      }

      if (rdr !=null)
      {
        rdr.Close();
      }
      if (conn !=null)
      {
        conn.Close();
      }
      return allItems;
    }

  }
}
