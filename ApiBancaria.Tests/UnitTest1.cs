using Microsoft.AspNetCore.Mvc.Diagnostics;
using Xunit;

namespace ApiBancaria.Tests;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
         conta contatest = new conta();
         contatest.deposit(50m);
         contatest.deposit(50m);
         contatest.processarfila(); 
         Assert.Equal(100m, contatest.balance);

         

    }
     
     [Fact]
    public void test2()
    {
         conta contatest2 = new conta();
        contatest2.processarfila();
        Assert.Equal(0m, contatest2.balance);
    }
  
}   