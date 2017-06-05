using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Trunk
{
  public class TrunkTest : IDisposable
  {
    public TrunkTest
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=trunk_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Ararange , Act
      int result = Item.GetALL().Count;

      Assert.Equal(0,result);
    }

    public void Dispose()
    {
      Item.DeleteAll();
    }
  }
}
