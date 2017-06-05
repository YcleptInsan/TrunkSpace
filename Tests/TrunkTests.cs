using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Trunk
{
  public class TrunkTest : IDisposable
  {
    public TrunkTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=trunk_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Ararange , Act
      int result = Item.GetAll().Count;

      Assert.Equal(0,result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreSame()
    {
      Item firstItem = new Item("Concert Tickets");
      Item secondItem = new Item("Concert Tickets");

      Assert.Equal(firstItem, secondItem);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Item testItem = new Item("Concert Tickets");

      //Act
      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item>{testItem};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Item testItem = new Item("Concert Tickets");

      testItem.Save();
      Item savedItem = Item.GetAll()[0];

      int testId = testItem.GetId();
      int result = savedItem.GetId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsItemsInDatabase()
    {
      Item testItem = new Item ("Concert Tickets");
      testItem.Save();

      Item foundItem = Item.Find(testItem.GetId());

      Assert.Equal(testItem, foundItem);
    }
    public void Dispose()
    {
      Item.DeleteAll();
    }
  }
}
